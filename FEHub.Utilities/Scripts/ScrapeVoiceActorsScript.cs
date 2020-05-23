//-----------------------------------------------------------------------------
// <copyright file="ScrapeVoiceActorsScript.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using FEHub.Utilities.Helpers;
using FEHub.Utilities.Scripts.Base;

using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json.Linq;

namespace FEHub.Utilities.Scripts
{
    internal sealed class ScrapeVoiceActorsScript : BaseScript
    {
        #region Fields
        private readonly string _targetDirectory;
        #endregion

        #region Constructors
        public ScrapeVoiceActorsScript(string targetDirectory)
        {
            this._targetDirectory = targetDirectory;
        }
        #endregion

        #region Methods
        public override async Task RunAsync()
        {
            var voiceActors = await this.FetchAsync();
            this.WriteToFile(voiceActors);
        }

        private async Task<List<JToken>> FetchAsync()
        {
            var queryParameters = new Dictionary<string, string>()
            {
                ["fields"] = string.Join(",",
                    "VoiceActors._pageName = Id",
                    "VoiceActors.Name",
                    "VoiceActors.NameJPJA",
                    "VoiceActors.Language"
                ),
                ["tables"] = "VoiceActors",
            };

            var voiceActors = await CargoQueryHelpers.GetAsync(queryParameters);

            return voiceActors;
        }

        private void WriteToFile(List<JToken> voiceActors)
        {
            var outputFile = @$"{this._targetDirectory}\VoiceActors_{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}.txt";

            using var fileStream = File.Open(outputFile, FileMode.Create, FileAccess.Write, FileShare.None);
            using var streamWriter = new StreamWriter(fileStream);
            using var csvWriter = new CsvWriter(streamWriter, new CsvConfiguration(CultureInfo.GetCultureInfo("en-US")) { Delimiter = "\t" });

            csvWriter.WriteRecords(
                voiceActors
                    .Select(x => new VoiceActorRecord(x))
            );
        }
        #endregion

        #region Classes
        private sealed class VoiceActorRecord
        {
            #region Constructors
            public VoiceActorRecord(JToken voiceActor)
            {
                this.Name = voiceActor["Name"].Value<string>();
                this.NameJPJA = voiceActor["NameJPJA"].Value<string>();
                this.Language = voiceActor["Language"].Value<string>();
            }
            #endregion

            #region Properties
            public string Name { get; set; }
            public string NameJPJA { get; set; }
            public string Language { get; set; }
            #endregion
        }
        #endregion
    }
}
