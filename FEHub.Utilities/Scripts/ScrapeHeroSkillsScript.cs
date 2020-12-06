//-----------------------------------------------------------------------------
// <copyright file="ScrapeHeroSkillsScript.cs">
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
    internal sealed class ScrapeHeroSkillsScript : BaseScript
    {
        private readonly string _targetDirectory;

        public ScrapeHeroSkillsScript(string targetDirectory)
        {
            this._targetDirectory = targetDirectory;
        }

        public override async Task RunAsync()
        {
            var heroSkills = await this.FetchAsync();
            this.WriteToFile(heroSkills);
        }

        private async Task<List<JToken>> FetchAsync()
        {
            var queryParameters = new Dictionary<string, string>()
            {
                ["fields"] = string.Join(",",
                    "Units._pageName = Id",
                    "Units.TagID",
                    "Units.Properties",
                    "UnitSkills.skill",
                    "UnitSkills.skillPos",
                    "UnitSkills.defaultRarity",
                    "UnitSkills.unlockRarity"
                ),
                ["tables"] = string.Join(",",
                    "Units",
                    "UnitSkills"
                ),
                ["join_on"] = "Units._pageName = UnitSkills._pageName"
            };

            var heroSkills = await CargoQueryHelpers.GetAsync(queryParameters);

            return heroSkills;
        }

        private void WriteToFile(List<JToken> heroSkills)
        {
            var outputFile = @$"{this._targetDirectory}\HeroSkills_{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}.txt";

            using var fileStream = File.Open(outputFile, FileMode.Create, FileAccess.Write, FileShare.None);
            using var streamWriter = new StreamWriter(fileStream);
            using var csvWriter = new CsvWriter(streamWriter, new CsvConfiguration(CultureInfo.GetCultureInfo("en-US")) { Delimiter = "\t" });

            csvWriter.WriteRecords(
                heroSkills
                    .Select(x => new HeroSkillRecord(x))
                    .Where(x => !x.HeroProperties.Split(',').Contains("enemy"))
            );
        }

        private sealed class HeroSkillRecord
        {
            public HeroSkillRecord(JToken heroSkill)
            {
                this.HeroTagID = heroSkill["TagID"].Value<string>();
                this.HeroProperties = heroSkill["Properties"].Value<string>();
                this.SkillName = heroSkill["skill"].Value<string>();
                this.SkillPos = heroSkill["skillPos"].Value<string>();
                this.DefaultRarity = heroSkill["defaultRarity"].Value<string>();
                this.UnlockRarity = heroSkill["unlockRarity"].Value<string>();
            }

            public string HeroTagID { get; set; }
            public string HeroProperties { get; set; }
            public string SkillName { get; set; }
            public string SkillPos { get; set; }
            public string DefaultRarity { get; set; }
            public string UnlockRarity { get; set; }
        }
    }
}
