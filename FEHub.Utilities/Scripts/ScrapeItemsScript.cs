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

namespace FEHub.Utilities.Scripts;

internal sealed class ScrapeItemsScript : BaseScript
{
    private readonly string _targetDirectory;

    public ScrapeItemsScript(string targetDirectory)
    {
        this._targetDirectory = targetDirectory;
    }

    public override async Task RunAsync()
    {
        var items = await this.FetchAsync();
        this.WriteToFile(items);
    }

    private async Task<List<JToken>> FetchAsync()
    {
        var queryParameters = new Dictionary<string, string>()
        {
            ["fields"] = string.Join(",",
                "Items._pageName = Id",
                "Items.Name",
                "Items.Description"
            ),
            ["tables"] = "Items",
        };

        var items = await CargoQueryHelpers.GetAsync(queryParameters);

        return items;
    }

    private void WriteToFile(List<JToken> items)
    {
        var outputFile = @$"{this._targetDirectory}\Items_{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}.txt";

        using var fileStream = File.Open(outputFile, FileMode.Create, FileAccess.Write, FileShare.None);
        using var streamWriter = new StreamWriter(fileStream);
        using var csvWriter = new CsvWriter(streamWriter, new CsvConfiguration(CultureInfo.GetCultureInfo("en-US")) { Delimiter = "\t" });

        csvWriter.WriteRecords(
            items
                .Select(x => new ItemRecord(x))
        );
    }

    private sealed class ItemRecord
    {
        public ItemRecord(JToken item)
        {
            this.Name = item["Name"].Value<string>();
            this.Description = WikiHelpers.Sanitize(item["Description"].Value<string>());
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
