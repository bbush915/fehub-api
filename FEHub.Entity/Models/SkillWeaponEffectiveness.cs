//-----------------------------------------------------------------------------
// <copyright file="SkillWeaponEffectiveness.cs">
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
        Name = nameof(Resources.SkillWeaponEffectiveness_Name),
        Description = nameof(Resources.SkillWeaponEffectiveness_Description),
        ResourceType = typeof(Resources)
    )]
    public class SkillWeaponEffectiveness
    {
        [Display(
            Name = nameof(Resources.SkillWeaponEffectiveness_Id_Name),
            Description = nameof(Resources.SkillWeaponEffectiveness_Id_Description),
            ResourceType = typeof(Resources)
        )]
        public int Id { get; set; }

        [Display(
            Name = nameof(Resources.SkillWeaponEffectiveness_SkillId_Name),
            Description = nameof(Resources.SkillWeaponEffectiveness_SkillId_Description),
            ResourceType = typeof(Resources)
        )]
        public Guid SkillId { get; set; }

        [Display(
            Name = nameof(Resources.SkillWeaponEffectiveness_WeaponEffectivenessType_Name),
            Description = nameof(Resources.SkillWeaponEffectiveness_WeaponEffectivenessType_Description),
            ResourceType = typeof(Resources)
        )]
        public WeaponEffectivenessTypes WeaponEffectivenessType { get; set; }

        [Display(
            Name = nameof(Resources.SkillWeaponEffectiveness_DamageType_Name),
            Description = nameof(Resources.SkillWeaponEffectiveness_DamageType_Description),
            ResourceType = typeof(Resources)
        )]
        public DamageTypes? DamageType { get; set; }

        [Display(
            Name = nameof(Resources.SkillWeaponEffectiveness_MovementType_Name),
            Description = nameof(Resources.SkillWeaponEffectiveness_MovementType_Description),
            ResourceType = typeof(Resources)
        )]
        public MovementTypes? MovementType { get; set; }

        [Display(
            Name = nameof(Resources.SkillWeaponEffectiveness_Weapon_Name),
            Description = nameof(Resources.SkillWeaponEffectiveness_Weapon_Description),
            ResourceType = typeof(Resources)
        )]
        public Weapons? Weapon { get; set; }
    }

    internal sealed class SkillWeaponEffectivenessEffectivenessConfiguration : IEntityTypeConfiguration<SkillWeaponEffectiveness>
    {
        #region Fields
        private const string TABLE_NAME = "SkillWeaponEffectivenesses";
        #endregion

        #region Methods
        public void Configure(EntityTypeBuilder<SkillWeaponEffectiveness> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TABLE_NAME)
                .HasKey(x => x.Id);

            entityTypeBuilder
                .Property(x => x.DamageType)
                .HasConversion<int?>();

            entityTypeBuilder
                .Property(x => x.MovementType)
                .HasConversion<int?>();

            entityTypeBuilder
                .Property(x => x.Weapon)
                .HasConversion<int?>();

            entityTypeBuilder
                .Property(x => x.WeaponEffectivenessType)
                .HasConversion<int>();
        }
        #endregion
    }
}
