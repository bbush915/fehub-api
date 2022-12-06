using System;
using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Models;
using FEHub.Entity.Properties;

using Bogus;
using Bogus.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEHub.Entity.Models
{
    [Display(
        Name = nameof(Resources.SkillWeaponEffectiveness_Name),
        Description = nameof(Resources.SkillWeaponEffectiveness_Description),
        ResourceType = typeof(Resources)
    )]
    public sealed class SkillWeaponEffectiveness
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

    internal sealed class SkillWeaponEffectivenessTypeConfiguration : IEntityTypeConfiguration<SkillWeaponEffectiveness>
    {
        private const string TABLE_NAME = "SkillWeaponEffectivenesses";

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
    }
}

namespace FEHub.Entity.Common.Helpers
{
    public static partial class FakeHelpers
    {
        public static Faker<SkillWeaponEffectiveness> SkillWeaponEffectiveness(
            int? id = null,
            Guid? skillId = null,
            WeaponEffectivenessTypes? weaponEffectivenessType = null,
            DamageTypes? damageType = (DamageTypes)Constants.Faker.NullableIntDefault,
            MovementTypes? movementType = (MovementTypes)Constants.Faker.NullableIntDefault,
            Weapons? weapon = (Weapons)Constants.Faker.NullableIntDefault
        )
        {
            var skillWeaponeffectivenessFaker = new Faker<SkillWeaponEffectiveness>()
                .RuleFor(x => x.Id, (faker) => id ?? faker.Random.Int(1))
                .RuleFor(x => x.SkillId, () => skillId ?? Guid.NewGuid())
                .RuleFor(x => x.WeaponEffectivenessType, (faker) => weaponEffectivenessType ?? faker.PickRandom<WeaponEffectivenessTypes>())
                .RuleFor(x => x.DamageType, (faker) => (damageType == (DamageTypes)Constants.Faker.NullableIntDefault) ? faker.PickRandom<DamageTypes>().OrNull(faker) : damageType)
                .RuleFor(x => x.MovementType, (faker) => (movementType == (MovementTypes)Constants.Faker.NullableIntDefault) ? faker.PickRandom<MovementTypes>().OrNull(faker) : movementType)
                .RuleFor(x => x.Weapon, (faker) => (weapon == (Weapons)Constants.Faker.NullableIntDefault) ? faker.PickRandom<Weapons>().OrNull(faker) : weapon);

            return skillWeaponeffectivenessFaker;
        }
    }
}