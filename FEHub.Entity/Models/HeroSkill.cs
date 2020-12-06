//-----------------------------------------------------------------------------
// <copyright file="HeroSkill.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Models;
using FEHub.Entity.Properties;

using Bogus;
using Bogus.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEHub.Entity.Models
{
    [Display(
        Name = nameof(Resources.HeroSkill_Name),
        Description = nameof(Resources.HeroSkill_Description),
        ResourceType = typeof(Resources)
    )]
    public sealed class HeroSkill
    {
        [Display(
            Name = nameof(Resources.HeroSkill_Id_Name),
            Description = nameof(Resources.HeroSkill_Id_Description),
            ResourceType = typeof(Resources)
        )]
        public int Id { get; set; }

        [Display(
            Name = nameof(Resources.HeroSkill_HeroId_Name),
            Description = nameof(Resources.HeroSkill_HeroId_Description),
            ResourceType = typeof(Resources)
        )]
        public Guid HeroId { get; set; }

        [Display(
            Name = nameof(Resources.HeroSkill_SkillId_Name),
            Description = nameof(Resources.HeroSkill_SkillId_Description),
            ResourceType = typeof(Resources)
        )]
        public Guid SkillId { get; set; }

        [Display(
            Name = nameof(Resources.HeroSkill_SkillPosition_Name),
            Description = nameof(Resources.HeroSkill_SkillPosition_Description),
            ResourceType = typeof(Resources)
        )]
        public int SkillPosition { get; set; }

        [Display(
            Name = nameof(Resources.HeroSkill_DefaultRarity_Name),
            Description = nameof(Resources.HeroSkill_DefaultRarity_Description),
            ResourceType = typeof(Resources)
        )]
        public int? DefaultRarity { get; set; }

        [Display(
            Name = nameof(Resources.HeroSkill_UnlockRarity_Name),
            Description = nameof(Resources.HeroSkill_UnlockRarity_Description),
            ResourceType = typeof(Resources)
        )]
        public int UnlockRarity { get; set; }

        [Display(
            Name = nameof(Resources.HeroSkill_Skill_Name),
            Description = nameof(Resources.HeroSkill_Skill_Description),
            ResourceType = typeof(Resources)
        )]
        public Skill Skill { get; set; }
    }

    internal sealed class HeroSkillTypeConfiguration : IEntityTypeConfiguration<HeroSkill>
    {
        private const string TABLE_NAME = "HeroSkills";

        public void Configure(EntityTypeBuilder<HeroSkill> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TABLE_NAME)
                .HasKey(x => x.Id);

            entityTypeBuilder
                .HasOne(x => x.Skill)
                .WithMany()
                .HasForeignKey(x => x.SkillId);
        }
    }
}

namespace FEHub.Entity.Common.Helpers
{
    public static partial class FakeHelpers
    {
        public static Faker<HeroSkill> HeroSkill(
            int? id = null,
            Guid? heroId = null,
            Guid? skillId = null,
            int? skillPosition = null,
            int? defaultRarity = Constants.Faker.NullableIntDefault,
            int? unlockRarity = null
        )
        {
            var heroSkillFaker = new Faker<HeroSkill>()
                .RuleFor(x => x.Id, (faker) => id ?? faker.Random.Int(1))
                .RuleFor(x => x.HeroId, () => heroId ?? Guid.NewGuid())
                .RuleFor(x => x.SkillId, () => skillId ?? Guid.NewGuid())
                .RuleFor(x => x.SkillPosition, (faker) => skillPosition ?? faker.Random.Int(1, 5))
                .RuleFor(x => x.DefaultRarity, (faker) => (defaultRarity == Constants.Faker.NullableIntDefault) ? faker.Random.Int(1, 5).OrNull(faker) : defaultRarity)
                .RuleFor(x => x.UnlockRarity, (faker) => unlockRarity ?? faker.Random.Int(1, 5));

            return heroSkillFaker;
        }
    }
}