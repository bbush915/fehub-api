//-----------------------------------------------------------------------------
// <copyright file="ScrapeArtistsScript.cs">
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
    internal sealed class ScrapeArtistsScript : BaseScript
    {
        #region Fields
        private readonly string _targetDirectory;
        #endregion


        #region Constructors
        public ScrapeArtistsScript(string targetDirectory)
        {
            this._targetDirectory = targetDirectory;
        }
        #endregion

        #region Methods
        public override async Task RunAsync()
        {
            var artists = await this.FetchAsync();
            this.WriteToFile(artists);
        }

        private async Task<List<JToken>> FetchAsync()
        {
            var queryParameters = new Dictionary<string, string>()
            {
                ["fields"] = string.Join(",",
                    "Artists._pageName = Id",
                    "Artists.NameUSEN",
                    "Artists.Name",
                    "Artists.Company"
                ),
                ["tables"] = "Artists",
            };

            var artists = await CargoQueryHelpers.GetAsync(queryParameters);

            return artists;
        }

        private void WriteToFile(List<JToken> artists)
        {
            var outputFile = @$"{this._targetDirectory}\Artists_{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}.txt";

            using var fileStream = File.Open(outputFile, FileMode.Create, FileAccess.Write, FileShare.None);
            using var streamWriter = new StreamWriter(fileStream);
            using var csvWriter = new CsvWriter(streamWriter, new CsvConfiguration(CultureInfo.GetCultureInfo("en-US")) { Delimiter = "\t" });

            csvWriter.WriteRecords(
                artists
                    .Select(x => new ArtistRecord(x))
            );
        }
        #endregion

        #region Classes
        private sealed class ArtistRecord
        {
            #region Constructors
            public ArtistRecord(JToken artist)
            {
                this.NameUSEN = artist["NameUSEN"].Value<string>();
                this.Name = artist["Name"].Value<string>();
                this.Company = artist["Company"].Value<string>();
            }
            #endregion

            #region Properties
            public string NameUSEN { get; set; }
            public string Name { get; set; }
            public string Company { get; set; }
            #endregion
        }
        #endregion
    }
}
