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

internal sealed class ScrapeSacredSealCostsScript : BaseScript
{
    private readonly string _targetDirectory;

    public ScrapeSacredSealCostsScript(string targetDirectory)
    {
        this._targetDirectory = targetDirectory;
    }

    public override async Task RunAsync()
    {
        var sacredSealCosts = await this.FetchAsync();
        this.WriteToFile(sacredSealCosts);
    }

    private async Task<List<JToken>> FetchAsync()
    {
        var queryParameters = new Dictionary<string, string>()
        {
            ["fields"] = string.Join(",",
                "SacredSealCosts._pageName = Id",
                "SacredSealCosts.Skill",
                "SacredSealCosts.BadgeColor",
                "SacredSealCosts.BadgeCost",
                "SacredSealCosts.GreatBadgeCost",
                "SacredSealCosts.SacredCoinCost"
            ),
            ["tables"] = "SacredSealCosts",
        };

        var sacredSealCosts = await CargoQueryHelpers.GetAsync(queryParameters);

        return sacredSealCosts;
    }

    private void WriteToFile(List<JToken> sacredSealCosts)
    {
        var outputFile = @$"{this._targetDirectory}\SacredSealCosts_{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}.txt";

        using var fileStream = File.Open(outputFile, FileMode.Create, FileAccess.Write, FileShare.None);
        using var streamWriter = new StreamWriter(fileStream);
        using var csvWriter = new CsvWriter(streamWriter, new CsvConfiguration(CultureInfo.GetCultureInfo("en-US")) { Delimiter = "\t" });

        csvWriter.WriteRecords(
            sacredSealCosts
                .Select(x => new SacredSealCostRecord(x))
        );
    }

    private sealed class SacredSealCostRecord
    {
        public SacredSealCostRecord(JToken sacredSealCost)
        {
            this.Skill = sacredSealCost["Skill"].Value<string>();
            this.BadgeColor = string.IsNullOrEmpty(sacredSealCost["BadgeColor"].Value<string>()) ? null : sacredSealCost["BadgeColor"].Value<string>();
            this.BadgeCost = string.IsNullOrEmpty(sacredSealCost["BadgeCost"].Value<string>()) ? (int?)null : sacredSealCost["BadgeCost"].Value<int>();
            this.GreatBadgeCost = string.IsNullOrEmpty(sacredSealCost["GreatBadgeCost"].Value<string>()) ? (int?)null : sacredSealCost["GreatBadgeCost"].Value<int>();
            this.SacredCoinCost = string.IsNullOrEmpty(sacredSealCost["SacredCoinCost"].Value<string>()) ? (int?)null : sacredSealCost["SacredCoinCost"].Value<int>();
        }

        public string Skill { get; set; }
        public string BadgeColor { get; set; }
        public int? BadgeCost { get; set; }
        public int? GreatBadgeCost { get; set; }
        public int? SacredCoinCost { get; set; }
    }
}
