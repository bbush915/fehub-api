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
using FEHub.Entity.Models;
using FEHub.Entity.Properties;

using Bogus;
using Bogus.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEHub.Entity.Models
{
    [Display(
        Name = nameof(Resources.Skill_Name),
        Description = nameof(Resources.Skill_Description),
        ResourceType = typeof(Resources)
    )]
    public sealed class Skill : ITrackable
    {
        public Skill()
        {
            this.SkillMovementTypes = new List<SkillMovementType>();
            this.SkillWeaponEffectivenesses = new List<SkillWeaponEffectiveness>();
            this.SkillWeaponTypes = new List<SkillWeaponType>();
        }

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
            Name = nameof(Resources.Skill_IsAvailableAsSacredSeal_Name),
            Description = nameof(Resources.Skill_IsAvailableAsSacredSeal_Description),
            ResourceType = typeof(Resources)
        )]
        public bool IsAvailableAsSacredSeal { get; set; }

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
        public List<SkillMovementType> SkillMovementTypes { get; set; }

        [Display(
            Name = nameof(Resources.Skill_SkillWeaponEffectivenesses_Name),
            Description = nameof(Resources.Skill_SkillWeaponEffectivenesses_Description),
            ResourceType = typeof(Resources)
        )]
        public List<SkillWeaponEffectiveness> SkillWeaponEffectivenesses { get; set; }

        [Display(
            Name = nameof(Resources.Skill_SkillWeaponTypes_Name),
            Description = nameof(Resources.Skill_SkillWeaponTypes_Description),
            ResourceType = typeof(Resources)
        )]
        public List<SkillWeaponType> SkillWeaponTypes { get; set; }
    }

    internal sealed class SkillTypeConfiguration : IEntityTypeConfiguration<Skill>
    {
        private const string TABLE_NAME = "Skills";

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
    }
}

namespace FEHub.Entity.Common.Helpers
{
    public static partial class FakeHelpers
    {
        public static Faker<Skill> Skill(
            Guid? id = null,
            DateTime? createdAt = null,
            string createdBy = null,
            DateTime? modifiedAt = null,
            string modifiedBy = null,
            int? version = null,
            string name = null,
            string groupName = null,
            string description = Constants.Faker.NullableStringDefault,
            bool? isExclusive = null,
            bool? isAvailableAsSacredSeal = null,
            int? skillPoints = null,
            SkillTypes? skillType = null,
            WeaponRefineTypes? weaponRefineType = (WeaponRefineTypes)Constants.Faker.NullableIntDefault,
            int? might = Constants.Faker.NullableIntDefault,
            int? range = Constants.Faker.NullableIntDefault,
            int? cooldown = Constants.Faker.NullableIntDefault,
            int? hitPointsModifier = Constants.Faker.NullableIntDefault,
            int? attackModifier = Constants.Faker.NullableIntDefault,
            int? speedModifier = Constants.Faker.NullableIntDefault,
            int? defenseModifier = Constants.Faker.NullableIntDefault,
            int? resistanceModifier = Constants.Faker.NullableIntDefault,
            string tag = null
        )
        {
            var skillFaker = new Faker<Skill>()
                .RuleFor(x => x.Id, () => id ?? Guid.NewGuid())
                .RuleFor(x => x.CreatedAt, (faker) => createdAt ?? faker.Date.Past())
                .RuleFor(x => x.CreatedBy, (faker) => createdBy ?? faker.Random.Utf16String())
                .RuleFor(x => x.ModifiedAt, (faker) => modifiedAt ?? faker.Date.Past())
                .RuleFor(x => x.ModifiedBy, (faker) => modifiedBy ?? faker.Random.Utf16String())
                .RuleFor(x => x.Version, (faker) => version ?? faker.Random.Int(1))
                .RuleFor(x => x.Name, (faker) => name ?? faker.Random.Utf16String())
                .RuleFor(x => x.GroupName, (faker) => groupName ?? faker.Random.Utf16String())
                .RuleFor(x => x.Description, (faker) => (description == Constants.Faker.NullableStringDefault) ? faker.Random.Utf16String().OrNull(faker) : description)
                .RuleFor(x => x.IsExclusive, (faker) => isExclusive ?? faker.Random.Bool())
                .RuleFor(x => x.IsAvailableAsSacredSeal, (faker) => isAvailableAsSacredSeal ?? faker.Random.Bool())
                .RuleFor(x => x.SkillPoints, (faker) => version ?? faker.Random.Int(0, 500))
                .RuleFor(x => x.SkillType, (faker) => skillType ?? faker.PickRandom<SkillTypes>())
                .RuleFor(x => x.WeaponRefineType, (faker) => (weaponRefineType == (WeaponRefineTypes)Constants.Faker.NullableIntDefault) ? faker.PickRandom<WeaponRefineTypes>().OrNull(faker) : weaponRefineType)
                .RuleFor(x => x.Might, (faker) => (might == Constants.Faker.NullableIntDefault) ? faker.Random.Int(0, 20).OrNull(faker) : might)
                .RuleFor(x => x.Range, (faker) => (range == Constants.Faker.NullableIntDefault) ? faker.Random.Int(1, 2).OrNull(faker) : range)
                .RuleFor(x => x.Cooldown, (faker) => (cooldown == Constants.Faker.NullableIntDefault) ? faker.Random.Int(-1, 10).OrNull(faker) : might)
                .RuleFor(x => x.HitPointsModifier, (faker) => (hitPointsModifier == Constants.Faker.NullableIntDefault) ? faker.Random.Int(0, 20).OrNull(faker) : hitPointsModifier)
                .RuleFor(x => x.AttackModifier, (faker) => (attackModifier == Constants.Faker.NullableIntDefault) ? faker.Random.Int(0, 20).OrNull(faker) : attackModifier)
                .RuleFor(x => x.SpeedModifier, (faker) => (speedModifier == Constants.Faker.NullableIntDefault) ? faker.Random.Int(0, 20).OrNull(faker) : speedModifier)
                .RuleFor(x => x.DefenseModifier, (faker) => (defenseModifier == Constants.Faker.NullableIntDefault) ? faker.Random.Int(0, 20).OrNull(faker) : defenseModifier)
                .RuleFor(x => x.ResistanceModifier, (faker) => (resistanceModifier == Constants.Faker.NullableIntDefault) ? faker.Random.Int(0, 20).OrNull(faker) : resistanceModifier)
                .RuleFor(x => x.Tag, (faker) => tag ?? faker.Random.Utf16String());

            return skillFaker;
        }
    }
}