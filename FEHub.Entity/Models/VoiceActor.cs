using System;
using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Interfaces;
using FEHub.Entity.Models;
using FEHub.Entity.Properties;

using Bogus;
using Bogus.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEHub.Entity.Models
{
    public sealed class VoiceActor : ITrackable
    {
        [Display(
            Name = nameof(Resources.VoiceActor_Id_Name),
            Description = nameof(Resources.VoiceActor_Id_Description),
            ResourceType = typeof(Resources)
        )]
        public int Id { get; set; }

        [Display(
            Name = nameof(Resources.VoiceActor_CreatedAt_Name),
            Description = nameof(Resources.VoiceActor_CreatedAt_Description),
            ResourceType = typeof(Resources)
        )]
        public DateTime CreatedAt { get; set; }

        [Display(
            Name = nameof(Resources.VoiceActor_CreatedBy_Name),
            Description = nameof(Resources.VoiceActor_CreatedBy_Description),
            ResourceType = typeof(Resources)
        )]
        public string CreatedBy { get; set; }

        [Display(
            Name = nameof(Resources.VoiceActor_ModifiedAt_Name),
            Description = nameof(Resources.VoiceActor_ModifiedAt_Description),
            ResourceType = typeof(Resources)
        )]
        public DateTime ModifiedAt { get; set; }

        [Display(
            Name = nameof(Resources.VoiceActor_ModifiedBy_Name),
            Description = nameof(Resources.VoiceActor_ModifiedBy_Description),
            ResourceType = typeof(Resources)
        )]
        public string ModifiedBy { get; set; }

        [Display(
            Name = nameof(Resources.VoiceActor_Version_Name),
            Description = nameof(Resources.VoiceActor_Version_Description),
            ResourceType = typeof(Resources)
        )]
        public int Version { get; set; }

        [Display(
            Name = nameof(Resources.VoiceActor_Name_Name),
            Description = nameof(Resources.VoiceActor_Name_Description),
            ResourceType = typeof(Resources)
        )]
        public string Name { get; set; }

        [Display(
            Name = nameof(Resources.VoiceActor_NameKanji_Name),
            Description = nameof(Resources.VoiceActor_NameKanji_Description),
            ResourceType = typeof(Resources)
        )]
        public string NameKanji { get; set; }
    }

    internal sealed class VoiceActorTypeConfiguration : IEntityTypeConfiguration<VoiceActor>
    {
        private const string TABLE_NAME = "VoiceActors";

        public void Configure(EntityTypeBuilder<VoiceActor> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TABLE_NAME)
                .HasKey(x => x.Id);

            entityTypeBuilder
                .Property(x => x.CreatedBy)
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
                .Property(x => x.NameKanji)
                .HasMaxLength(100);
        }
    }
}

namespace FEHub.Entity.Common.Helpers
{
    public static partial class FakeHelpers
    {
        public static Faker<VoiceActor> VoiceActor(
            int? id = null,
            DateTime? createdAt = null,
            string createdBy = null,
            DateTime? modifiedAt = null,
            string modifiedBy = null,
            int? version = null,
            string name = null,
            string nameKanji = Constants.Faker.NullableStringDefault
        )
        {
            var voiceActorFaker = new Faker<VoiceActor>()
                .RuleFor(x => x.Id, (faker) => id ?? faker.Random.Int(1))
                .RuleFor(x => x.CreatedAt, (faker) => createdAt ?? faker.Date.Past())
                .RuleFor(x => x.CreatedBy, (faker) => createdBy ?? faker.Random.Utf16String())
                .RuleFor(x => x.ModifiedAt, (faker) => modifiedAt ?? faker.Date.Past())
                .RuleFor(x => x.ModifiedBy, (faker) => modifiedBy ?? faker.Random.Utf16String())
                .RuleFor(x => x.Version, (faker) => version ?? faker.Random.Int(1))
                .RuleFor(x => x.Name, (faker) => name ?? faker.Random.Utf16String())
                .RuleFor(x => x.NameKanji, (faker) => (nameKanji == Constants.Faker.NullableStringDefault) ? faker.Random.Utf16String().OrNull(faker) : nameKanji);

            return voiceActorFaker;
        }
    }
}