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

internal sealed class ScrapeHeroesScript : BaseScript
{
    private readonly string _targetDirectory;

    public ScrapeHeroesScript(string targetDirectory)
    {
        this._targetDirectory = targetDirectory;
    }

    public override async Task RunAsync()
    {
        var heroes = await this.FetchAsync();
        this.WriteToFile(heroes);
    }

    private async Task<List<JToken>> FetchAsync()
    {
        var queryParameters = new Dictionary<string, string>()
        {
            ["fields"] = string.Join(",",
                "Units._pageName = Id",
                "Units.Name",
                "Units.Title",
                "Units.Person",
                "Units.Origin",
                "Units.TagID",
                "Units.Gender",
                "Units.WeaponType",
                "Units.MoveType",
                "Units.GrowthMod",
                "Units.Artist",
                "Units.ActorEN",
                "Units.ActorJP",
                "Units.AdditionDate",
                "Units.ReleaseDate",
                "Units.Properties",
                "Units.Description",
                "UnitStats.Lv1HP5",
                "UnitStats.Lv1Atk5",
                "UnitStats.Lv1Spd5",
                "UnitStats.Lv1Def5",
                "UnitStats.Lv1Res5",
                "UnitStats.HPGR3",
                "UnitStats.AtkGR3 ",
                "UnitStats.SpdGR3 ",
                "UnitStats.DefGR3 ",
                "UnitStats.ResGR3 ",
                "HeroBVIDs.BVID"
            ),
            ["tables"] = string.Join(",",
                "Units",
                "UnitStats",
                "HeroBVIDs"
            ),
            ["join_on"] = string.Join(",",
                "Units._pageName = UnitStats._pageName",
                "Units._pageName = HeroBVIDs.Hero"
            )
        };

        var heroes = await CargoQueryHelpers.GetAsync(queryParameters);

        return heroes;
    }

    private void WriteToFile(List<JToken> heroes)
    {
        var outputFile = @$"{this._targetDirectory}\Heroes_{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}.txt";

        using var fileStream = File.Open(outputFile, FileMode.Create, FileAccess.Write, FileShare.None);
        using var streamWriter = new StreamWriter(fileStream);
        using var csvWriter = new CsvWriter(streamWriter, new CsvConfiguration(CultureInfo.GetCultureInfo("en-US")) { Delimiter = "\t" });

        csvWriter.WriteRecords(
            heroes
                .Select(x => new HeroRecord(x))
                .Where(x => !x.Properties.Split(',').Contains("enemy"))
        );
    }

    private sealed class HeroRecord
    {
        public HeroRecord(JToken hero)
        {
            this.Name = hero["Name"].Value<string>();
            this.Title = hero["Title"].Value<string>();
            this.Person = hero["Person"].Value<string>();
            this.Origin = hero["Origin"].Value<string>();
            this.TagID = hero["TagID"].Value<string>();
            this.Gender = hero["Gender"].Value<string>();
            this.WeaponType = hero["WeaponType"].Value<string>();
            this.MovementType = hero["MoveType"].Value<string>();
            this.GrowthMod = hero["GrowthMod"].Value<string>();
            this.Artist = hero["Artist"].Value<string>();
            this.ActorEN = hero["ActorEN"].Value<string>();
            this.ActorJP = hero["ActorJP"].Value<string>();
            this.AdditionDate = hero["AdditionDate"].Value<string>();
            this.ReleaseDate = hero["ReleaseDate"].Value<string>();
            this.Description = WikiHelpers.Sanitize(hero["Description"].Value<string>());
            this.Properties = hero["Properties"].Value<string>();
            this.BVID = hero["BVID"].Value<string>();
            this.Lv1HP5 = hero["Lv1HP5"].Value<int>();
            this.Lv1Atk5 = hero["Lv1Atk5"].Value<int>();
            this.Lv1Spd5 = hero["Lv1Spd5"].Value<int>();
            this.Lv1Def5 = hero["Lv1Def5"].Value<int>();
            this.Lv1Res5 = hero["Lv1Res5"].Value<int>();
            this.HPGR3 = hero["HPGR3"].Value<int>();
            this.AtkGR3 = hero["AtkGR3"].Value<int>();
            this.SpdGR3 = hero["SpdGR3"].Value<int>();
            this.DefGR3 = hero["DefGR3"].Value<int>();
            this.ResGR3 = hero["ResGR3"].Value<int>();
        }

        public string Name { get; set; }
        public string Title { get; set; }
        public string Person { get; set; }
        public string Origin { get; set; }
        public string TagID { get; set; }
        public string Gender { get; set; }
        public string WeaponType { get; set; }
        public string MovementType { get; set; }
        public string GrowthMod { get; set; }
        public string Artist { get; set; }
        public string ActorEN { get; set; }
        public string ActorJP { get; set; }
        public string AdditionDate { get; set; }
        public string ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Properties { get; set; }
        public string BVID { get; set; }
        public int Lv1HP5 { get; set; }
        public int Lv1Atk5 { get; set; }
        public int Lv1Spd5 { get; set; }
        public int Lv1Def5 { get; set; }
        public int Lv1Res5 { get; set; }
        public int HPGR3 { get; set; }
        public int AtkGR3 { get; set; }
        public int SpdGR3 { get; set; }
        public int DefGR3 { get; set; }
        public int ResGR3 { get; set; }
    }
}
