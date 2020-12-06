//-----------------------------------------------------------------------------
// <copyright file="HeroVoiceActor.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Models;
using FEHub.Entity.Properties;

using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEHub.Entity.Models
{
    [Display(
        Name = nameof(Resources.HeroVoiceActor_Name),
        Description = nameof(Resources.HeroVoiceActor_Description),
        ResourceType = typeof(Resources)
    )]
    public sealed class HeroVoiceActor
    {
        [Display(
            Name = nameof(Resources.HeroVoiceActor_Id_Name),
            Description = nameof(Resources.HeroVoiceActor_Id_Description),
            ResourceType = typeof(Resources)
        )]
        public int Id { get; set; }

        [Display(
            Name = nameof(Resources.HeroVoiceActor_HeroId_Name),
            Description = nameof(Resources.HeroVoiceActor_HeroId_Description),
            ResourceType = typeof(Resources)
        )]
        public Guid HeroId { get; set; }

        [Display(
            Name = nameof(Resources.HeroVoiceActor_VoiceActorId_Name),
            Description = nameof(Resources.HeroVoiceActor_VoiceActorId_Description),
            ResourceType = typeof(Resources)
        )]
        public int VoiceActorId { get; set; }

        [Display(
            Name = nameof(Resources.HeroVoiceActor_Language_Name),
            Description = nameof(Resources.HeroVoiceActor_Language_Description),
            ResourceType = typeof(Resources)
        )]
        public Languages Language { get; set; }

        [Display(
            Name = nameof(Resources.HeroVoiceActor_Sort_Name),
            Description = nameof(Resources.HeroVoiceActor_Sort_Description),
            ResourceType = typeof(Resources)
        )]
        public int Sort { get; set; }

        [Display(
            Name = nameof(Resources.HeroVoiceActor_VoiceActor_Name),
            Description = nameof(Resources.HeroVoiceActor_VoiceActor_Description),
            ResourceType = typeof(Resources)
        )]
        public VoiceActor VoiceActor { get; set; }
    }

    internal sealed class HeroVoiceActorTypeConfiguration : IEntityTypeConfiguration<HeroVoiceActor>
    {
        private const string TABLE_NAME = "HeroVoiceActors";

        public void Configure(EntityTypeBuilder<HeroVoiceActor> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TABLE_NAME)
                .HasKey(x => x.Id);

            entityTypeBuilder
                .Property(x => x.Language)
                .HasConversion<int>();

            entityTypeBuilder
                .HasOne(x => x.VoiceActor)
                .WithMany()
                .HasForeignKey(x => x.VoiceActorId);
        }
    }
}

namespace FEHub.Entity.Common.Helpers
{
    public static partial class FakeHelpers
    {
        public static Faker<HeroVoiceActor> HeroVoiceActor(
            int? id = null,
            Guid? heroId = null,
            int? voiceActorId = null,
            Languages? language = null,
            int? sort = null
        )
        {
            var heroVoiceActorFaker = new Faker<HeroVoiceActor>()
                .RuleFor(x => x.Id, (faker) => id ?? faker.Random.Int(1))
                .RuleFor(x => x.HeroId, () => heroId ?? Guid.NewGuid())
                .RuleFor(x => x.VoiceActorId, (faker) => voiceActorId ?? faker.Random.Int(1))
                .RuleFor(x => x.Language, (faker) => language ?? faker.PickRandom<Languages>())
                .RuleFor(x => x.Sort, (faker) => sort ?? faker.Random.Int(1));

            return heroVoiceActorFaker;
        }
    }
}