//-----------------------------------------------------------------------------
// <copyright file="SkillWeaponType.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Properties;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEHub.Entity.Models
{
    [Display(
        Name = nameof(Resources.SkillWeaponType_Name),
        Description = nameof(Resources.SkillWeaponType_Description),
        ResourceType = typeof(Resources)
    )]
    public class SkillWeaponType
    {
        [Display(
            Name = nameof(Resources.SkillWeaponType_Id_Name),
            Description = nameof(Resources.SkillWeaponType_Id_Description),
            ResourceType = typeof(Resources)
        )]
        public int Id { get; set; }

        [Display(
            Name = nameof(Resources.SkillWeaponType_SkillId_Name),
            Description = nameof(Resources.SkillWeaponType_SkillId_Description),
            ResourceType = typeof(Resources)
        )]
        public Guid SkillId { get; set; }

        [Display(
            Name = nameof(Resources.SkillWeaponType_Color_Name),
            Description = nameof(Resources.SkillWeaponType_Color_Description),
            ResourceType = typeof(Resources)
        )]
        public Colors Color { get; set; }

        [Display(
            Name = nameof(Resources.SkillWeaponType_Weapon_Name),
            Description = nameof(Resources.SkillWeaponType_Weapon_Description),
            ResourceType = typeof(Resources)
        )]
        public Weapons Weapon { get; set; }
    }

    internal sealed class SkillWeaponTypeTypeConfiguration : IEntityTypeConfiguration<SkillWeaponType>
    {
        #region Fields
        private const string TABLE_NAME = "SkillWeaponTypes";
        #endregion

        #region Methods
        public void Configure(EntityTypeBuilder<SkillWeaponType> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TABLE_NAME)
                .HasKey(x => x.Id);

            entityTypeBuilder
                .Property(x => x.Color)
                .HasConversion<int>();

            entityTypeBuilder
                .Property(x => x.Weapon)
                .HasConversion<int>();
        }
        #endregion
    }
}
