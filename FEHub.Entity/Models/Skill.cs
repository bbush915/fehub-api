//-----------------------------------------------------------------------------
// <copyright file="Skill.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Interfaces;
using FEHub.Entity.Properties;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEHub.Entity.Models
{
    [Display(
        Name = nameof(Resources.Skill_Name),
        Description = nameof(Resources.Skill_Description),
        ResourceType = typeof(Resources)
    )]
    public class Skill : ITrackable
    {
        #region Constructors
        public Skill()
        {
            this.SkillMovementTypes = new List<SkillMovementType>();
            this.SkillWeaponEffectivenesses = new List<SkillWeaponEffectiveness>();
            this.SkillWeaponTypes = new List<SkillWeaponType>();
        }
        #endregion

        #region Properties
        [Display(
            Name = nameof(Resources.Skill_Id_Name),
            Description = nameof(Resources.Skill_Id_Description),
            ResourceType = typeof(Resources)
        )]
        public Guid Id { get; set; }

        [Display(
            Name = nameof(Resources.Skill_CreatedAt_Name),
            Description = nameof(Resources.Skill_CreatedAt_Description),
            ResourceType = typeof(Resources)
        )]
        public DateTime CreatedAt { get; set; }

        [Display(
            Name = nameof(Resources.Skill_CreatedBy_Name),
            Description = nameof(Resources.Skill_CreatedBy_Description),
            ResourceType = typeof(Resources)
        )]
        public string CreatedBy { get; set; }

        [Display(
            Name = nameof(Resources.Skill_ModifiedAt_Name),
            Description = nameof(Resources.Skill_ModifiedAt_Description),
            ResourceType = typeof(Resources)
        )]
        public DateTime ModifiedAt { get; set; }

        [Display(
            Name = nameof(Resources.Skill_ModifiedBy_Name),
            Description = nameof(Resources.Skill_ModifiedBy_Description),
            ResourceType = typeof(Resources)
        )]
        public string ModifiedBy { get; set; }

        [Display(
            Name = nameof(Resources.Skill_Version_Name),
            Description = nameof(Resources.Skill_Version_Description),
            ResourceType = typeof(Resources)
        )]
        public int Version { get; set; }

        [Display(
            Name = nameof(Resources.Skill_Name_Name),
            Description = nameof(Resources.Skill_Name_Description),
            ResourceType = typeof(Resources)
        )]
        public string Name { get; set; }

        [Display(
            Name = nameof(Resources.Skill_GroupName_Name),
            Description = nameof(Resources.Skill_GroupName_Description),
            ResourceType = typeof(Resources)
        )]
        public string GroupName { get; set; }

        [Display(
            Name = nameof(Resources.Skill_Description_Name),
            Description = nameof(Resources.Skill_Description_Description),
            ResourceType = typeof(Resources)
        )]
        public string Description { get; set; }

        [Display(
            Name = nameof(Resources.Skill_IsExclusive_Name),
            Description = nameof(Resources.Skill_IsExclusive_Description),
            ResourceType = typeof(Resources)
        )]
        public bool IsExclusive { get; set; }

        [Display(
            Name = nameof(Resources.Skill_SkillPoints_Name),
            Description = nameof(Resources.Skill_SkillPoints_Description),
            ResourceType = typeof(Resources)
        )]
        public int SkillPoints { get; set; }

        [Display(
            Name = nameof(Resources.Skill_SkillType_Name),
            Description = nameof(Resources.Skill_SkillType_Description),
            ResourceType = typeof(Resources)
        )]
        public SkillTypes SkillType { get; set; }

        [Display(
            Name = nameof(Resources.Skill_WeaponRefineType_Name),
            Description = nameof(Resources.Skill_WeaponRefineType_Description),
            ResourceType = typeof(Resources)
        )]
        public WeaponRefineTypes? WeaponRefineType { get; set; }

        [Display(
            Name = nameof(Resources.Skill_Might_Name),
            Description = nameof(Resources.Skill_Might_Description),
            ResourceType = typeof(Resources)
        )]
        public int? Might { get; set; }

        [Display(
            Name = nameof(Resources.Skill_Range_Name),
            Description = nameof(Resources.Skill_Range_Description),
            ResourceType = typeof(Resources)
        )]
        public int? Range { get; set; }

        [Display(
            Name = nameof(Resources.Skill_Cooldown_Name),
            Description = nameof(Resources.Skill_Cooldown_Description),
            ResourceType = typeof(Resources)
        )]
        public int? Cooldown { get; set; }

        [Display(
            Name = nameof(Resources.Skill_HitPointsModifier_Name),
            Description = nameof(Resources.Skill_HitPointsModifier_Description),
            ResourceType = typeof(Resources)
        )]
        public int? HitPointsModifier { get; set; }

        [Display(
            Name = nameof(Resources.Skill_AttackModifier_Name),
            Description = nameof(Resources.Skill_AttackModifier_Description),
            ResourceType = typeof(Resources)
        )]
        public int? AttackModifier { get; set; }

        [Display(
            Name = nameof(Resources.Skill_SpeedModifier_Name),
            Description = nameof(Resources.Skill_SpeedModifier_Description),
            ResourceType = typeof(Resources)
        )]
        public int? SpeedModifier { get; set; }

        [Display(
            Name = nameof(Resources.Skill_DefenseModifier_Name),
            Description = nameof(Resources.Skill_DefenseModifier_Description),
            ResourceType = typeof(Resources)
        )]
        public int? DefenseModifier { get; set; }

        [Display(
            Name = nameof(Resources.Skill_ResistanceModifier_Name),
            Description = nameof(Resources.Skill_ResistanceModifier_Description),
            ResourceType = typeof(Resources)
        )]
        public int? ResistanceModifier { get; set; }

        [Display(
            Name = nameof(Resources.Skill_Tag_Name),
            Description = nameof(Resources.Skill_Tag_Description),
            ResourceType = typeof(Resources)
        )]
        public string Tag { get; set; }

        [Display(
            Name = nameof(Resources.Skill_SkillMovementTypes_Name),
            Description = nameof(Resources.Skill_SkillMovementTypes_Description),
            ResourceType = typeof(Resources)
        )]
        public virtual List<SkillMovementType> SkillMovementTypes { get; set; }

        [Display(
            Name = nameof(Resources.Skill_SkillWeaponEffectivenesses_Name),
            Description = nameof(Resources.Skill_SkillWeaponEffectivenesses_Description),
            ResourceType = typeof(Resources)
        )]
        public virtual List<SkillWeaponEffectiveness> SkillWeaponEffectivenesses { get; set; }

        [Display(
            Name = nameof(Resources.Skill_SkillWeaponTypes_Name),
            Description = nameof(Resources.Skill_SkillWeaponTypes_Description),
            ResourceType = typeof(Resources)
        )]
        public virtual List<SkillWeaponType> SkillWeaponTypes { get; set; }
        #endregion
    }

    internal sealed class SkillTypeConfiguration : IEntityTypeConfiguration<Skill>
    {
        #region Fields
        private const string TABLE_NAME = "Skills";
        #endregion

        #region Methods
        public void Configure(EntityTypeBuilder<Skill> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TABLE_NAME)
                .HasKey(x => x.Id);

            entityTypeBuilder
                .Property(x => x.CreatedBy)
                .IsRequired()
                .HasMaxLength(100);

            entityTypeBuilder
                .Property(x => x.Description)
                .HasMaxLength(1000);

            entityTypeBuilder
                .Property(x => x.GroupName)
                .IsRequired()
                .HasMaxLength(100);

            entityTypeBuilder
                .Property(x => x.ModifiedBy)
                .IsRequired()
                .HasMaxLength(100);

            entityTypeBuilder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            entityTypeBuilder
                .HasMany(x => x.SkillMovementTypes)
                .WithOne()
                .HasForeignKey(x => x.SkillId);

            entityTypeBuilder
                .Property(x => x.SkillType)
                .HasConversion<int>();

            entityTypeBuilder
                .HasMany(x => x.SkillWeaponEffectivenesses)
                .WithOne()
                .HasForeignKey(x => x.SkillId);

            entityTypeBuilder
                .HasMany(x => x.SkillWeaponTypes)
                .WithOne()
                .HasForeignKey(x => x.SkillId);

            entityTypeBuilder
                .Property(x => x.Tag)
                .IsRequired()
                .HasMaxLength(100);

            entityTypeBuilder
                .Property(x => x.WeaponRefineType)
                .HasConversion<int?>();
        }
        #endregion
    }
}
