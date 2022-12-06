using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using FEHub.Entity;
using FEHub.Entity.Models;
using FEHub.Utilities.Scripts.Base;

using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace FEHub.Utilities.Scripts;

internal sealed class ImportHeroSkillsScript : BaseScript, IDisposable
{
    private readonly FehContext _dbContext;

    private readonly string _sourceFiile;

    private readonly Dictionary<string, Hero> _heroMap;
    private readonly Dictionary<string, Skill> _skillMap;

    public ImportHeroSkillsScript(FehContext dbContext, string sourceFile)
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

        this._skillMap = this._dbContext
            .Skills
            .ToDictionaryAsync(
                x => x.Tag,
                y => y
            )
            .Result;
    }

    public override async Task RunAsync()
    {
        var heroSkills = this.Fetch();
        await this.ImportAsync(heroSkills);
    }

    public void Dispose()
    {
        this._dbContext.Dispose();
    }

    private List<HeroSkill> Fetch()
    {
        var heroSkills = new List<HeroSkill>();

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (var excelPackage = new ExcelPackage(new FileInfo(this._sourceFiile)))
        {
            var worksheet = excelPackage.Workbook.Worksheets["HeroSkills"];

            for (var i = 2; i <= worksheet.Dimension.End.Row; ++i)
            {
                 var heroSkill = new HeroSkill()
                {
                    SkillPosition = worksheet.Cells[i, 3].GetValue<int>(),
                    DefaultRarity = worksheet.Cells[i, 4].GetValue<int?>(),
                    UnlockRarity = worksheet.Cells[i, 5].GetValue<int>()
                };

                var hero = this._heroMap[
                    worksheet.Cells[i, 1].GetValue<string>()
                ];

                heroSkill.HeroId = hero.Id;

                var skill = this._skillMap[
                    worksheet.Cells[i, 2].GetValue<string>()
                ];

                heroSkill.SkillId = skill.Id;

                heroSkills.Add(heroSkill);
            }
        }

        return heroSkills;
    }

    private async Task ImportAsync(List<HeroSkill> heroSkills)
    {
        foreach (var heroSkill in heroSkills)
        {
            var existingHeroSkill = await this._dbContext
                .HeroSkills
                .SingleOrDefaultAsync(
                    x =>
                        (x.HeroId == heroSkill.HeroId) &&
                        (x.SkillId == heroSkill.SkillId)
                );

            if (existingHeroSkill == null)
            {
                await this._dbContext
                    .HeroSkills
                    .AddAsync(heroSkill);
            }
        }

        await this._dbContext.SaveChangesAsync();
    }
}
