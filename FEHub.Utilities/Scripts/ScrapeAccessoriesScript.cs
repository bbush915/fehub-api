//-----------------------------------------------------------------------------
// <copyright file="ScrapeAccessoriesScript.cs">
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
    internal sealed class ScrapeAccessoriesScript : BaseScript
    {
        #region Fields
        private readonly string _targetDirectory;
        #endregion

        #region Constructors
        public ScrapeAccessoriesScript(string targetDirectory)
        {
            this._targetDirectory = targetDirectory;
        }
        #endregion

        #region Methods
        public override async Task RunAsync()
        {
            var accessories = await this.FetchAsync();
            this.WriteToFile(accessories);
        }

        private async Task<List<JToken>> FetchAsync()
        {
            var queryParameters = new Dictionary<string, string>()
            {
                ["fields"] = string.Join(",",
                    "Accessories._pageName = Id",
                    "Accessories.Name",
                    "Accessories.Description",
                    "Accessories.Type",
                    "Accessories.TagID"
                ),
                ["tables"] = "Accessories",
            };

            var accessories = await CargoQueryHelpers.GetAsync(queryParameters);

            return accessories;
        }

        private void WriteToFile(List<JToken> accessories)
        {
            var outputFile = @$"{this._targetDirectory}\Accessories_{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}.txt";

            using var fileStream = File.Open(outputFile, FileMode.Create, FileAccess.Write, FileShare.None);
            using var streamWriter = new StreamWriter(fileStream);
            using var csvWriter = new CsvWriter(streamWriter, new CsvConfiguration(CultureInfo.GetCultureInfo("en-US")) { Delimiter = "\t" });

            csvWriter.WriteRecords(
                accessories
                    .Select(x => new AccessoryRecord(x))
            );
        }
        #endregion

        #region Classes
        private sealed class AccessoryRecord
        {
            #region Constructors
            public AccessoryRecord(JToken accessory)
            {
                this.Name = accessory["Name"].Value<string>();
                this.Description = WikiHelpers.Sanitize(accessory["Description"].Value<string>());
                this.Type = accessory["Type"].Value<string>();
                this.TagID = accessory["TagID"].Value<string>();
            }
            #endregion

            #region Properties
            public string Name { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public string TagID { get; set; }
            #endregion
        }
        #endregion
    }
}
