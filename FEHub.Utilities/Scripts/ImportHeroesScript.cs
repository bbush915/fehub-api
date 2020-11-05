//-----------------------------------------------------------------------------
// <copyright file="ImportHeroesScript.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using FEHub.Entity;
using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Models;
using FEHub.Utilities.Helpers;
using FEHub.Utilities.Scripts.Base;

using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace FEHub.Utilities.Scripts
{
    internal sealed class ImportHeroesScript : BaseScript, IDisposable
    {
        #region Fields
        private readonly FehContext _dbContext;

        private readonly string _sourceFiile;

        private readonly Dictionary<string, Artist> _artistMap;
        #endregion

        #region Constructors
        public ImportHeroesScript(FehContext dbContext, string sourceFile)
        {
            this._dbContext = dbContext;

            this._sourceFiile = sourceFile;

            this._artistMap = this._dbContext
                .Artists
                .ToDictionaryAsync(
                    x => x.Name.ToLower(),
                    y => y
                )
                .Result;
        }
        #endregion

        #region Methods
        public override async Task RunAsync()
        {
            var heroes = this.Fetch();
            await this.ImportAsync(heroes);
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }

        private List<Hero> Fetch()
        {
            var heroes = new List<Hero>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var excelPackage = new ExcelPackage(new FileInfo(this._sourceFiile)))
            {
                var worksheet = excelPackage.Workbook.Worksheets["Heroes"];

                for (var i = 2; i <= worksheet.Dimension.End.Row; ++i)
                {
                    var hero = new Hero()
                    {
                        Name = worksheet.Cells[i, 7].GetValue<string>(),
                        Title = worksheet.Cells[i, 8].GetValue<string>(),
                        Description = worksheet.Cells[i, 9].GetValue<string>(),
                        Gender = (Genders)Enum.Parse(typeof(Genders), worksheet.Cells[i, 2].GetValue<string>()),
                        Origin = worksheet.Cells[i, 10].GetValue<string>(),
                        AdditionDate = worksheet.Cells[i, 11].GetValue<DateTime>(),
                        ReleaseDate = worksheet.Cells[i, 12].GetValue<DateTime>(),
                        Color = (Colors)Enum.Parse(typeof(Colors), worksheet.Cells[i, 3].GetValue<string>()),
                        Weapon = (Weapons)Enum.Parse(typeof(Weapons), worksheet.Cells[i, 4].GetValue<string>()),
                        MovementType = (MovementTypes)Enum.Parse(typeof(MovementTypes), worksheet.Cells[i, 5].GetValue<string>()),
                        BVID = int.Parse(worksheet.Cells[i, 13].GetValue<string>(), NumberStyles.HexNumber),
                        BaseHitPoints = worksheet.Cells[i, 14].GetValue<int>() - 2,
                        HitPointsGrowthRate = worksheet.Cells[i, 15].GetValue<int>(),
                        BaseAttack = worksheet.Cells[i, 16].GetValue<int>() - 2,
                        AttackGrowthRate = worksheet.Cells[i, 17].GetValue<int>(),
                        BaseSpeed = worksheet.Cells[i, 18].GetValue<int>() - 2,
                        SpeedGrowthRate = worksheet.Cells[i, 19].GetValue<int>(),
                        BaseDefense = worksheet.Cells[i, 20].GetValue<int>() - 2,
                        DefenseGrowthRate = worksheet.Cells[i, 21].GetValue<int>(),
                        BaseResistance = worksheet.Cells[i, 22].GetValue<int>() - 2,
                        ResistanceGrowthRate = worksheet.Cells[i, 23].GetValue<int>(),
                        IsDuoHero = worksheet.Cells[i, 24].GetValue<bool>(),
                        IsLegendaryHero = worksheet.Cells[i, 25].GetValue<bool>(),
                        IsMythicHero = worksheet.Cells[i, 26].GetValue<bool>(),
                        IsResplendentHero = worksheet.Cells[i, 27].GetValue<bool>(),
                        Element = string.IsNullOrEmpty(worksheet.Cells[i, 28].GetValue<string>()) ? (Elements?)null :  (Elements)Enum.Parse(typeof(Elements), worksheet.Cells[i, 28].GetValue<string>()),
                        LegendaryHeroBoostType = string.IsNullOrEmpty(worksheet.Cells[i, 29].GetValue<string>()) ? (LegendaryHeroBoostTypes?)null :  (LegendaryHeroBoostTypes)Enum.Parse(typeof(LegendaryHeroBoostTypes), worksheet.Cells[i, 29].GetValue<string>()),
                        MythicHeroBoostType = string.IsNullOrEmpty(worksheet.Cells[i, 30].GetValue<string>()) ? (MythicHeroBoostTypes?)null : (MythicHeroBoostTypes)Enum.Parse(typeof(MythicHeroBoostTypes), worksheet.Cells[i, 30].GetValue<string>()),
                        Tag = worksheet.Cells[i, 1].GetValue<string>(),
                    };

                    var artist = this._artistMap[
                        worksheet.Cells[i, 6].GetValue<string>().ToLower()
                    ];

                    hero.ArtistId = artist.Id;

                    hero.Id = GuidHelpers.Create(hero.Tag);

                    heroes.Add(hero);
                }
            }

            return heroes;
        }

        private async Task ImportAsync(List<Hero> heroes)
        {
            foreach (var hero in heroes)
            {
                var existingHero = await this._dbContext
                    .Heroes
                    .SingleOrDefaultAsync(x => x.Tag == hero.Tag);

                if (existingHero == null)
                {
                    await this._dbContext
                        .Heroes
                        .AddAsync(hero);
                }
            }

            await this._dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
