//-----------------------------------------------------------------------------
// <copyright file="ImportSkillsScript.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
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
    internal sealed class ImportSkillsScript : BaseScript, IDisposable
    {
        #region Fields
        private readonly FehContext _dbContext;

        private readonly string _sourceFiile;
        #endregion

        #region Constructors
        public ImportSkillsScript(FehContextFactory dbContextFactory, string sourceFile)
        {
            this._dbContext = dbContextFactory.CreateDbContext();

            this._sourceFiile = sourceFile;
        }
        #endregion

        #region Methods
        public override async Task RunAsync()
        {
            var skills = this.Fetch();
            await this.ImportAsync(skills);
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }

        private List<Skill> Fetch()
        {
            var skills = new List<Skill>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var excelPackage = new ExcelPackage(new FileInfo(this._sourceFiile)))
            {
                var worksheet = excelPackage.Workbook.Worksheets["Skills"];

                for (var i = 2; i <= worksheet.Dimension.End.Row; ++i)
                {
                    var skill = new Skill()
                    {
                        Name = worksheet.Cells[i, 4].GetValue<string>(),
                        Description = worksheet.Cells[i, 5].GetValue<string>(),
                        GroupName = worksheet.Cells[i, 6].GetValue<string>(),
                        IsExclusive = worksheet.Cells[i, 7].GetValue<bool>(),
                        SkillType = (SkillTypes)Enum.Parse(typeof(SkillTypes), worksheet.Cells[i, 2].GetValue<string>()),
                        WeaponRefineType = string.IsNullOrEmpty(worksheet.Cells[i, 3].GetValue<string>()) ? (WeaponRefineTypes?)null : (WeaponRefineTypes)Enum.Parse(typeof(WeaponRefineTypes), worksheet.Cells[i, 3].GetValue<string>()),
                        Might = worksheet.Cells[i, 8].GetValue<int?>(),
                        Range = worksheet.Cells[i, 9].GetValue<int?>(),
                        Cooldown = worksheet.Cells[i, 10].GetValue<int?>(),
                        HitPointsModifier = worksheet.Cells[i, 15].GetValue<int?>(),
                        AttackModifier = worksheet.Cells[i, 16].GetValue<int?>(),
                        SpeedModifier = worksheet.Cells[i, 17].GetValue<int?>(),
                        DefenseModifier = worksheet.Cells[i, 18].GetValue<int?>(),
                        ResistanceModifier = worksheet.Cells[i, 19].GetValue<int?>(),
                        SkillPoints = worksheet.Cells[i, 11].GetValue<int>(),
                        Tag = worksheet.Cells[i, 1].GetValue<string>(),
                    };

                    skill.SkillMovementTypes = this.GetSkillMovementTypes(
                        value: worksheet.Cells[i, 12].GetValue<string>()
                    );

                    skill.SkillWeaponTypes = this.GetSkillWeaponTypes(
                        value: worksheet.Cells[i, 13].GetValue<string>()
                    );

                    skill.SkillWeaponEffectivenesses = this.GetSkillWeaponEffectivenesses(
                        value: worksheet.Cells[i, 14].GetValue<string>()
                    );

                    skill.Id = GuidHelpers.Create(skill.Tag);

                    skills.Add(skill);
                }
            }

            return skills;
        }

        private List<SkillMovementType> GetSkillMovementTypes(string value)
        {
            var movementTypeNames = value.Split(',');

            var skillMovementTypes = new List<SkillMovementType>();

            foreach (var movementTypeName in movementTypeNames)
            {
                var skillMovementType = new SkillMovementType()
                {
                    MovementType = (MovementTypes)Enum.Parse(typeof(MovementTypes), movementTypeName),
                };

                skillMovementTypes.Add(skillMovementType);
            }

            return skillMovementTypes;
        }

        private List<SkillWeaponType> GetSkillWeaponTypes(string value)
        {
            var weaponTypeNames = value.Split(',');

            var skillWeaponTypes = new List<SkillWeaponType>();

            foreach (var weaponTypeName in weaponTypeNames)
            {
                var colorName = weaponTypeName.Substring(0, weaponTypeName.IndexOf(' '));
                var weaponName = weaponTypeName.Substring(weaponTypeName.IndexOf(' ') + 1);

                var skillWeaponType = new SkillWeaponType()
                {
                    Color = (Colors)Enum.Parse(typeof(Colors), colorName),
                    Weapon = (Weapons)Enum.Parse(typeof(Weapons), weaponName),
                };

                skillWeaponTypes.Add(skillWeaponType);
            }

            return skillWeaponTypes;
        }

        private List<SkillWeaponEffectiveness> GetSkillWeaponEffectivenesses(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new List<SkillWeaponEffectiveness>();
            }

            var weaponEffectivenessNames = value.Split(',');

            var skillWeaponEffectivenesses = new List<SkillWeaponEffectiveness>();

            foreach (var weaponEffectivenessName in weaponEffectivenessNames)
            {
                var isMovementType = Enum.GetNames(typeof(MovementTypes)).Contains(weaponEffectivenessName);
                var isWeapon = Enum.GetNames(typeof(Weapons)).Contains(weaponEffectivenessName);
                var isDamageType = Enum.GetNames(typeof(DamageTypes)).Contains(weaponEffectivenessName);

                var skillWeaponEffectiveness = new SkillWeaponEffectiveness();

                if (isMovementType)
                {
                    skillWeaponEffectiveness.WeaponEffectivenessType = WeaponEffectivenessTypes.MOVEMENT_TYPE;
                    skillWeaponEffectiveness.MovementType = (MovementTypes)Enum.Parse(typeof(MovementTypes), weaponEffectivenessName);
                }
                else if (isWeapon)
                {
                    skillWeaponEffectiveness.WeaponEffectivenessType = WeaponEffectivenessTypes.WEAPON;
                    skillWeaponEffectiveness.Weapon = (Weapons)Enum.Parse(typeof(Weapons), weaponEffectivenessName);
                }
                else if (isDamageType)
                {
                    skillWeaponEffectiveness.WeaponEffectivenessType = WeaponEffectivenessTypes.DAMAGE_TYPE;
                    skillWeaponEffectiveness.DamageType = (DamageTypes)Enum.Parse(typeof(DamageTypes), weaponEffectivenessName);
                }

                skillWeaponEffectivenesses.Add(skillWeaponEffectiveness);
            }

            return skillWeaponEffectivenesses;
        }

        private async Task ImportAsync(List<Skill> skills)
        {
            foreach (var skill in skills)
            {
                var existingSkill = await this._dbContext
                    .Skills
                    .SingleOrDefaultAsync(x => x.Tag == skill.Tag);

                if (existingSkill == null)
                {
                    await this._dbContext
                        .Skills
                        .AddAsync(skill);
                }
            }

            await this._dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
