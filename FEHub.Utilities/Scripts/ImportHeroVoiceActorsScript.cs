//-----------------------------------------------------------------------------
// <copyright file="ImportHeroVoiceActorsScript.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using FEHub.Entity;
using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Models;
using FEHub.Utilities.Scripts.Base;

using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace FEHub.Utilities.Scripts
{
    internal sealed class ImportHeroVoiceActorsScript : BaseScript, IDisposable
    {
        private readonly FehContext _dbContext;

        private readonly string _sourceFiile;

        private readonly Dictionary<string, Hero> _heroMap;
        private readonly Dictionary<string, VoiceActor> _voiceActorMap;

        public ImportHeroVoiceActorsScript(FehContext dbContext, string sourceFile)
        {
            this._dbContext = dbContext;

            this._sourceFiile = sourceFile;

            this._heroMap = this._dbContext
                .Heroes
                .ToDictionaryAsync(
                    x => x.Tag,
                    y => y
                )
                .Result;

            this._voiceActorMap = this._dbContext
                .VoiceActors
                .ToDictionaryAsync(
                    x => x.Name,
                    y => y
                )
                .Result;
        }

        public override async Task RunAsync()
        {
            var heroVoiceActors = this.Fetch();
            await this.ImportAsync(heroVoiceActors);
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }

        private List<HeroVoiceActor> Fetch()
        {
            var heroVoiceActors = new List<HeroVoiceActor>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var excelPackage = new ExcelPackage(new FileInfo(this._sourceFiile)))
            {
                var worksheet = excelPackage.Workbook.Worksheets["HeroVoiceActors"];

                for (var i = 2; i <= worksheet.Dimension.End.Row; ++i)
                {
                    var heroVoiceActor = new HeroVoiceActor()
                    {
                        Language = (Languages)Enum.Parse(typeof(Languages), worksheet.Cells[i, 4].GetValue<string>()),
                        Sort = worksheet.Cells[i, 3].GetValue<int>(),
                    };

                    var hero = this._heroMap[
                        worksheet.Cells[i, 1].GetValue<string>()
                    ];

                    heroVoiceActor.HeroId = hero.Id;

                    var voiceActor = this._voiceActorMap[
                        worksheet.Cells[i, 2].GetValue<string>()
                    ];

                    heroVoiceActor.VoiceActorId = voiceActor.Id;

                    heroVoiceActors.Add(heroVoiceActor);
                }
            }

            return heroVoiceActors;
        }

        private async Task ImportAsync(List<HeroVoiceActor> heroVoiceActors)
        {
            foreach (var heroVoiceActor in heroVoiceActors)
            {
                var existingHeroVoiceActor = await this._dbContext
                    .HeroVoiceActors
                    .SingleOrDefaultAsync(
                        x =>
                            (x.HeroId == heroVoiceActor.HeroId) &&
                            (x.VoiceActorId == heroVoiceActor.VoiceActorId) &&
                            (x.Language == heroVoiceActor.Language)
                    );

                if (existingHeroVoiceActor == null)
                {
                    await this._dbContext
                        .HeroVoiceActors
                        .AddAsync(heroVoiceActor);
                }
            }

            await this._dbContext.SaveChangesAsync();
        }
    }
}
