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
        Name = nameof(Resources.SkillWeaponType_Name),
        Description = nameof(Resources.SkillWeaponType_Description),
        ResourceType = typeof(Resources)
    )]
    public sealed class SkillWeaponType
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
        private const string TABLE_NAME = "SkillWeaponTypes";

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
    }
}

namespace FEHub.Entity.Common.Helpers
{
    public static partial class FakeHelpers
    {
        public static Faker<SkillWeaponType> SkillWeaponType(
            int? id = null,
            Guid? skillId = null,
            Colors? color = null,
            Weapons? weapon = null
        )
        {
            var skillWeaponTypeFaker = new Faker<SkillWeaponType>()
                .RuleFor(x => x.Id, (faker) => id ?? faker.Random.Int(1))
                .RuleFor(x => x.SkillId, () => skillId ?? Guid.NewGuid())
                .RuleFor(x => x.Color, (faker) => color ?? faker.PickRandom<Colors>())
                .RuleFor(x => x.Weapon, (faker) => weapon ?? faker.PickRandom<Weapons>());

            return skillWeaponTypeFaker;
        }
    }
}