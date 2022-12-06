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

internal sealed class ScrapeSkillsScript : BaseScript
{
    private readonly string _targetDirectory;

    public ScrapeSkillsScript(string targetDirectory)
    {
        this._targetDirectory = targetDirectory;
    }

    public override async Task RunAsync()
    {
        var skills = await this.FetchAsync();
        this.WriteToFile(skills);
    }

    private async Task<List<JToken>> FetchAsync()
    {
        var queryParameters = new Dictionary<string, string>()
        {
            ["fields"] = string.Join(",",
                "Skills._pageName = Id",
                "Skills.GroupName",
                "Skills.Name",
                "Skills.WikiName",
                "Skills.TagID",
                "Skills.Scategory",
                "Skills.UseRange",
                "Skills.RefinePath",
                "Skills.Description",
                "Skills.Required",
                "Skills.Next",
                "Skills.PromotionRarity",
                "Skills.PromotionTier",
                "Skills.Exclusive",
                "Skills.SP",
                "Skills.CanUseMove",
                "Skills.CanUseWeapon",
                "Skills.Might",
                "Skills.StatModifiers",
                "Skills.Cooldown",
                "Skills.WeaponEffectiveness",
                "Skills.SkillBuildCost",
                "Skills.Properties"
            ),
            ["tables"] = "Skills",
        };

        var skills = await CargoQueryHelpers.GetAsync(queryParameters);

        return skills;
    }

    private void WriteToFile(List<JToken> skills)
    {
        var outputFile = @$"{this._targetDirectory}\Skills_{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}.txt";

        using var fileStream = File.Open(outputFile, FileMode.Create, FileAccess.Write, FileShare.None);
        using var streamWriter = new StreamWriter(fileStream);
        using var csvWriter = new CsvWriter(streamWriter, new CsvConfiguration(CultureInfo.GetCultureInfo("en-US")) { Delimiter = "\t" });

        csvWriter.WriteRecords(
            skills
                .Select(x => new SkillRecord(x))
        );
    }

    private sealed class SkillRecord
    {
        public SkillRecord(JToken skill)
        {
            this.GroupName = skill["GroupName"].Value<string>();
            this.Name = skill["Name"].Value<string>();
            this.WikiName = skill["WikiName"].Value<string>();
            this.TagID = skill["TagID"].Value<string>();
            this.UseRange = skill["UseRange"].Value<string>();
            this.Scategory = skill["Scategory"].Value<string>();
            this.RefinePath = skill["RefinePath"].Value<string>();
            this.Description = WikiHelpers.Sanitize(skill["Description"].Value<string>());
            this.Required = skill["Required"].Value<string>();
            this.Next = skill["Next"].Value<string>();
            this.PromotionRarity = skill["PromotionRarity"].Value<string>();
            this.PromotionTier = skill["PromotionTier"].Value<string>();
            this.Exclusive = skill["Exclusive"].Value<string>();
            this.SP = skill["SP"].Value<string>();
            this.CanUseMove = skill["CanUseMove"].Value<string>();
            this.CanUseWeapon = skill["CanUseWeapon"].Value<string>();
            this.Might = skill["Might"].Value<string>();
            this.StatModifiers = skill["StatModifiers"].Value<string>();
            this.Cooldown = skill["Cooldown"].Value<string>();
            this.WeaponEffectiveness = skill["WeaponEffectiveness"].Value<string>();
            this.SkillBuildCost = skill["SkillBuildCost"].Value<string>();
            this.Properties = skill["Properties"].Value<string>();
        }

        public string GroupName { get; set; }
        public string Name { get; set; }
        public string WikiName { get; set; }
        public string TagID { get; set; }
        public string Scategory { get; set; }
        public string UseRange { get; set; }
        public string RefinePath { get; set; }
        public string Description { get; set; }
        public string Required { get; set; }
        public string Next { get; set; }
        public string PromotionRarity { get; set; }
        public string PromotionTier { get; set; }
        public string Exclusive { get; set; }
        public string SP { get; set; }
        public string CanUseMove { get; set; }
        public string CanUseWeapon { get; set; }
        public string Might { get; set; }
        public string StatModifiers { get; set; }
        public string Cooldown { get; set; }
        public string WeaponEffectiveness { get; set; }
        public string SkillBuildCost { get; set; }
        public string Properties { get; set; }
    }
}
