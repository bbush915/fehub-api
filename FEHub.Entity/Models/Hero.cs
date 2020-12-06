//-----------------------------------------------------------------------------
// <copyright file="Hero.cs">
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
        Name = nameof(Resources.Hero_Name),
        Description = nameof(Resources.Hero_Description),
        ResourceType = typeof(Resources)
    )]
    public sealed class Hero : ITrackable
    {
        public Hero()
        {
            this.HeroSkills = new List<HeroSkill>();
            this.HeroVoiceActors = new List<HeroVoiceActor>();
        }

        [Display(
            Name = nameof(Resources.Hero_Id_Name),
            Description = nameof(Resources.Hero_Id_Description),
            ResourceType = typeof(Resources)
        )]
        public Guid Id { get; set; }

        [Display(
            Name = nameof(Resources.Hero_CreatedAt_Name),
            Description = nameof(Resources.Hero_CreatedAt_Description),
            ResourceType = typeof(Resources)
        )]
        public DateTime CreatedAt { get; set; }

        [Display(
            Name = nameof(Resources.Hero_CreatedBy_Name),
            Description = nameof(Resources.Hero_CreatedBy_Description),
            ResourceType = typeof(Resources)
        )]
        public string CreatedBy { get; set; }

        [Display(
            Name = nameof(Resources.Hero_ModifiedAt_Name),
            Description = nameof(Resources.Hero_ModifiedAt_Description),
            ResourceType = typeof(Resources)
        )]
        public DateTime ModifiedAt { get; set; }

        [Display(
            Name = nameof(Resources.Hero_ModifiedBy_Name),
            Description = nameof(Resources.Hero_ModifiedBy_Description),
            ResourceType = typeof(Resources)
        )]
        public string ModifiedBy { get; set; }

        [Display(
            Name = nameof(Resources.Hero_Version_Name),
            Description = nameof(Resources.Hero_Version_Description),
            ResourceType = typeof(Resources)
        )]
        public int Version { get; set; }

        [Display(
            Name = nameof(Resources.Hero_Name_Name),
            Description = nameof(Resources.Hero_Name_Description),
            ResourceType = typeof(Resources)
        )]
        public string Name { get; set; }

        [Display(
            Name = nameof(Resources.Hero_Title_Name),
            Description = nameof(Resources.Hero_Title_Description),
            ResourceType = typeof(Resources)
        )]
        public string Title { get; set; }

        [Display(
            Name = nameof(Resources.Hero_Description_Name),
            Description = nameof(Resources.Hero_Description_Description),
            ResourceType = typeof(Resources)
        )]
        public string Description { get; set; }

        [Display(
            Name = nameof(Resources.Hero_Origin_Name),
            Description = nameof(Resources.Hero_Origin_Description),
            ResourceType = typeof(Resources)
        )]
        public string Origin { get; set; }

        [Display(
            Name = nameof(Resources.Hero_Gender_Name),
            Description = nameof(Resources.Hero_Gender_Description),
            ResourceType = typeof(Resources)
        )]
        public Genders Gender { get; set; }

        [Display(
            Name = nameof(Resources.Hero_AdditionDate_Name),
            Description = nameof(Resources.Hero_AdditionDate_Description),
            ResourceType = typeof(Resources)
        )]
        public DateTime AdditionDate { get; set; }

        [Display(
            Name = nameof(Resources.Hero_ReleaseDate_Name),
            Description = nameof(Resources.Hero_ReleaseDate_Description),
            ResourceType = typeof(Resources)
        )]
        public DateTime ReleaseDate { get; set; }

        [Display(
            Name = nameof(Resources.Hero_ArtistId_Name),
            Description = nameof(Resources.Hero_ArtistId_Description),
            ResourceType = typeof(Resources)
        )]
        public int ArtistId { get; set; }

        [Display(
            Name = nameof(Resources.Hero_IsLegendaryHero_Name),
            Description = nameof(Resources.Hero_IsLegendaryHero_Description),
            ResourceType = typeof(Resources)
        )]
        public bool IsLegendaryHero { get; set; }

        [Display(
            Name = nameof(Resources.Hero_IsMythicHero_Name),
            Description = nameof(Resources.Hero_IsMythicHero_Description),
            ResourceType = typeof(Resources)
        )]
        public bool IsMythicHero { get; set; }

        [Display(
            Name = nameof(Resources.Hero_Element_Name),
            Description = nameof(Resources.Hero_Element_Description),
            ResourceType = typeof(Resources)
        )]
        public Elements? Element { get; set; }

        [Display(
            Name = nameof(Resources.Hero_LegendaryHeroBoostType_Name),
            Description = nameof(Resources.Hero_LegendaryHeroBoostType_Description),
            ResourceType = typeof(Resources)
        )]
        public LegendaryHeroBoostTypes? LegendaryHeroBoostType { get; set; }

        [Display(
            Name = nameof(Resources.Hero_MythicHeroBoostType_Name),
            Description = nameof(Resources.Hero_MythicHeroBoostType_Description),
            ResourceType = typeof(Resources)
        )]
        public MythicHeroBoostTypes? MythicHeroBoostType { get; set; }

        [Display(
            Name = nameof(Resources.Hero_IsDuoHero_Name),
            Description = nameof(Resources.Hero_IsDuoHero_Description),
            ResourceType = typeof(Resources)
        )]
        public bool IsDuoHero { get; set; }

        [Display(
            Name = nameof(Resources.Hero_IsResplendentHero_Name),
            Description = nameof(Resources.Hero_IsResplendentHero_Description),
            ResourceType = typeof(Resources)
        )]
        public bool IsResplendentHero { get; set; }

        [Display(
            Name = nameof(Resources.Hero_Color_Name),
            Description = nameof(Resources.Hero_Color_Description),
            ResourceType = typeof(Resources)
        )]
        public Colors Color { get; set; }

        [Display(
            Name = nameof(Resources.Hero_Weapon_Name),
            Description = nameof(Resources.Hero_Weapon_Description),
            ResourceType = typeof(Resources)
        )]
        public Weapons Weapon { get; set; }

        [Display(
            Name = nameof(Resources.Hero_MovementType_Name),
            Description = nameof(Resources.Hero_MovementType_Description),
            ResourceType = typeof(Resources)
        )]
        public MovementTypes MovementType { get; set; }

        [Display(
            Name = nameof(Resources.Hero_BVID_Name),
            Description = nameof(Resources.Hero_BVID_Description),
            ResourceType = typeof(Resources)
        )]
        public int BVID { get; set; }

        [Display(
            Name = nameof(Resources.Hero_BaseHitPoints_Name),
            Description = nameof(Resources.Hero_BaseHitPoints_Description),
            ResourceType = typeof(Resources)
        )]
        public int BaseHitPoints { get; set; }

        [Display(
            Name = nameof(Resources.Hero_HitPointsGrowthRate_Name),
            Description = nameof(Resources.Hero_HitPointsGrowthRate_Description),
            ResourceType = typeof(Resources)
        )]
        public int HitPointsGrowthRate { get; set; }

        [Display(
            Name = nameof(Resources.Hero_BaseAttack_Name),
            Description = nameof(Resources.Hero_BaseAttack_Description),
            ResourceType = typeof(Resources)
        )]
        public int BaseAttack { get; set; }

        [Display(
            Name = nameof(Resources.Hero_AttackGrowthRate_Name),
            Description = nameof(Resources.Hero_AttackGrowthRate_Description),
            ResourceType = typeof(Resources)
        )]
        public int AttackGrowthRate { get; set; }

        [Display(
            Name = nameof(Resources.Hero_BaseSpeed_Name),
            Description = nameof(Resources.Hero_BaseSpeed_Description),
            ResourceType = typeof(Resources)
        )]
        public int BaseSpeed { get; set; }

        [Display(
            Name = nameof(Resources.Hero_SpeedGrowthRate_Name),
            Description = nameof(Resources.Hero_SpeedGrowthRate_Description),
            ResourceType = typeof(Resources)
        )]
        public int SpeedGrowthRate { get; set; }

        [Display(
            Name = nameof(Resources.Hero_BaseDefense_Name),
            Description = nameof(Resources.Hero_BaseDefense_Description),
            ResourceType = typeof(Resources)
        )]
        public int BaseDefense { get; set; }

        [Display(
            Name = nameof(Resources.Hero_DefenseGrowthRate_Name),
            Description = nameof(Resources.Hero_DefenseGrowthRate_Description),
            ResourceType = typeof(Resources)
        )]
        public int DefenseGrowthRate { get; set; }

        [Display(
            Name = nameof(Resources.Hero_BaseResistance_Name),
            Description = nameof(Resources.Hero_BaseResistance_Description),
            ResourceType = typeof(Resources)
        )]
        public int BaseResistance { get; set; }

        [Display(
            Name = nameof(Resources.Hero_ResistanceGrowthRate_Name),
            Description = nameof(Resources.Hero_ResistanceGrowthRate_Description),
            ResourceType = typeof(Resources)
        )]
        public int ResistanceGrowthRate { get; set; }

        [Display(
            Name = nameof(Resources.Hero_Tag_Name),
            Description = nameof(Resources.Hero_Tag_Description),
            ResourceType = typeof(Resources)
        )]
        public string Tag { get; set; }

        [Display(
            Name = nameof(Resources.Hero_Artist_Name),
            Description = nameof(Resources.Hero_Artist_Description),
            ResourceType = typeof(Resources)
        )]
        public Artist Artist { get; set; }

        [Display(
            Name = nameof(Resources.Hero_HeroSkills_Name),
            Description = nameof(Resources.Hero_HeroSkills_Description),
            ResourceType = typeof(Resources)
        )]
        public List<HeroSkill> HeroSkills { get; set; }

        [Display(
            Name = nameof(Resources.Hero_HeroVoiceActors_Name),
            Description = nameof(Resources.Hero_HeroVoiceActors_Description),
            ResourceType = typeof(Resources)
        )]
        public List<HeroVoiceActor> HeroVoiceActors { get; set; }

        public DamageTypes GetDamageType()
        {
            switch (this.Weapon)
            {
                case Weapons.SWORD:
                case Weapons.LANCE:
                case Weapons.AXE:
                case Weapons.BOW:
                case Weapons.DAGGER:
                case Weapons.BEASTSTONE:
                    {
                        return DamageTypes.PHYSICAL;
                    }

                case Weapons.TOME:
                case Weapons.STAFF:
                case Weapons.DRAGONSTONE:
                    {
                        return DamageTypes.MAGICAL;
                    }

                default:
                    {
                        throw new Exception($"Unexpected weapon encountered: [{this.Weapon}]");
                    }
            }
        }

        public CombatTypes GetCombatType()
        {
            switch (this.Weapon)
            {
                case Weapons.SWORD:
                case Weapons.LANCE:
                case Weapons.AXE:
                case Weapons.DRAGONSTONE:
                case Weapons.BEASTSTONE:
                    {
                        return CombatTypes.MELEE;
                    }

                case Weapons.BOW:
                case Weapons.DAGGER:
                case Weapons.TOME:
                case Weapons.STAFF:
                    {
                        return CombatTypes.RANGED;
                    }

                default:
                    {
                        throw new Exception($"Unexpected weapon encountered: [{this.Weapon}]");
                    }
            }
        }
    }

    internal sealed class HeroTypeConfiguration : IEntityTypeConfiguration<Hero>
    {
        private const string TABLE_NAME = "Heroes";

        public void Configure(EntityTypeBuilder<Hero> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TABLE_NAME)
                .HasKey(x => x.Id);

            entityTypeBuilder
                .Property(x => x.AdditionDate)
                .HasColumnType("date");

            entityTypeBuilder
                .HasOne(x => x.Artist)
                .WithMany()
                .HasForeignKey(x => x.ArtistId);

            entityTypeBuilder
                .Property(x => x.Color)
                .HasConversion<int>();

            entityTypeBuilder
                .Property(x => x.CreatedBy)
                .IsRequired()
                .HasMaxLength(100);

            entityTypeBuilder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(250);

            entityTypeBuilder
                .Property(x => x.Element)
                .HasConversion<int?>();

            entityTypeBuilder
                .Property(x => x.Gender)
                .HasConversion<int>();

            entityTypeBuilder
                .HasMany(x => x.HeroSkills)
                .WithOne()
                .HasForeignKey(x => x.HeroId);

            entityTypeBuilder
                .HasMany(x => x.HeroVoiceActors)
                .WithOne()
                .HasForeignKey(x => x.HeroId);

            entityTypeBuilder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            entityTypeBuilder
                .Property(x => x.LegendaryHeroBoostType)
                .HasConversion<int?>();

            entityTypeBuilder
                .Property(x => x.ModifiedBy)
                .IsRequired()
                .HasMaxLength(100);

            entityTypeBuilder
                .Property(x => x.MovementType)
                .HasConversion<int>();

            entityTypeBuilder
                .Property(x => x.MythicHeroBoostType)
                .HasConversion<int?>();

            entityTypeBuilder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            entityTypeBuilder
                .Property(x => x.Origin)
                .IsRequired()
                .HasMaxLength(100);

            entityTypeBuilder
                .Property(x => x.ReleaseDate)
                .HasColumnType("date");

            entityTypeBuilder
                .Property(x => x.Tag)
                .IsRequired()
                .HasMaxLength(100);

            entityTypeBuilder
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

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
        public static Faker<Hero> Hero(
            Guid? id = null,
            DateTime? createdAt = null,
            string createdBy = null,
            DateTime? modifiedAt = null,
            string modifiedBy = null,
            int? version = null,
            string name = null,
            string title = null,
            string description = null,
            string origin = null,
            Genders? gender = null,
            DateTime? additionDate = null,
            DateTime? releasseDate = null,
            int? artistId = null,
            bool? isLegendaryHero = null,
            bool? isMythicHero = null,
            Elements? element = (Elements)Constants.Faker.NullableIntDefault,
            LegendaryHeroBoostTypes? legendaryHeroBoostType = (LegendaryHeroBoostTypes)Constants.Faker.NullableIntDefault,
            MythicHeroBoostTypes? mythicHeroBoostType = (MythicHeroBoostTypes)Constants.Faker.NullableIntDefault,
            bool? isDuoHero = null,
            bool? isResplendentHero = null,
            Colors? color = null,
            Weapons? weapon = null,
            MovementTypes? movementType = null,
            int? bvid = null,
            int? baseHitPoints = null,
            int? hitPointsGrowthRate = null,
            int? baseAttack = null,
            int? attackGrowthRate = null,
            int? baseSpeed = null,
            int? speedGrowthRate = null,
            int? baseDefense = null,
            int? defenseGrowthRate = null,
            int? baseResistance = null,
            int? resistanceGrowthRate = null,
            string tag = null
        )
        {
            var heroFaker = new Faker<Hero>()
                .RuleFor(x => x.Id, () => id ?? Guid.NewGuid())
                .RuleFor(x => x.CreatedAt, (faker) => createdAt ?? faker.Date.Past())
                .RuleFor(x => x.CreatedBy, (faker) => createdBy ?? faker.Random.Utf16String())
                .RuleFor(x => x.ModifiedAt, (faker) => modifiedAt ?? faker.Date.Past())
                .RuleFor(x => x.ModifiedBy, (faker) => modifiedBy ?? faker.Random.Utf16String())
                .RuleFor(x => x.Version, (faker) => version ?? faker.Random.Int(1))
                .RuleFor(x => x.Name, (faker) => name ?? faker.Random.Utf16String())
                .RuleFor(x => x.Title, (faker) => title ?? faker.Random.Utf16String())
                .RuleFor(x => x.Description, (faker) => description ?? faker.Random.Utf16String())
                .RuleFor(x => x.Origin, (faker) => origin ?? faker.Random.Utf16String())
                .RuleFor(x => x.Gender, (faker) => gender ?? faker.PickRandom<Genders>())
                .RuleFor(x => x.AdditionDate, (faker) => additionDate ?? faker.Date.Past())
                .RuleFor(x => x.ReleaseDate, (faker) => releasseDate ?? faker.Date.Past())
                .RuleFor(x => x.ArtistId, (faker) => artistId ?? faker.Random.Int(1))
                .RuleFor(x => x.IsLegendaryHero, (faker) => isLegendaryHero ?? faker.Random.Bool())
                .RuleFor(x => x.IsMythicHero, (faker) => isMythicHero ?? faker.Random.Bool())
                .RuleFor(x => x.Element, (faker) => (element == (Elements)Constants.Faker.NullableIntDefault) ? faker.PickRandom<Elements>().OrNull(faker) : element)
                .RuleFor(x => x.LegendaryHeroBoostType, (faker) => (legendaryHeroBoostType == (LegendaryHeroBoostTypes)Constants.Faker.NullableIntDefault) ? faker.PickRandom<LegendaryHeroBoostTypes>().OrNull(faker) : legendaryHeroBoostType)
                .RuleFor(x => x.MythicHeroBoostType, (faker) => (mythicHeroBoostType == (MythicHeroBoostTypes)Constants.Faker.NullableIntDefault) ? faker.PickRandom<MythicHeroBoostTypes>().OrNull(faker) : mythicHeroBoostType)
                .RuleFor(x => x.IsDuoHero, (faker) => isDuoHero ?? faker.Random.Bool())
                .RuleFor(x => x.IsResplendentHero, (faker) => isResplendentHero ?? faker.Random.Bool())
                .RuleFor(x => x.Color, (faker) => color ?? faker.PickRandom<Colors>())
                .RuleFor(x => x.Weapon, (faker) => weapon ?? faker.PickRandom<Weapons>())
                .RuleFor(x => x.MovementType, (faker) => movementType ?? faker.PickRandom<MovementTypes>())
                .RuleFor(x => x.BVID, (faker) => bvid ?? faker.Random.Int(0, 255))
                .RuleFor(x => x.BaseHitPoints, (faker) => baseHitPoints ?? faker.Random.Int(0, 30))
                .RuleFor(x => x.HitPointsGrowthRate, (faker) => hitPointsGrowthRate ?? faker.Random.Int(0, 100))
                .RuleFor(x => x.BaseAttack, (faker) => baseAttack ?? faker.Random.Int(0, 30))
                .RuleFor(x => x.AttackGrowthRate, (faker) => attackGrowthRate ?? faker.Random.Int(0, 100))
                .RuleFor(x => x.BaseSpeed, (faker) => baseSpeed ?? faker.Random.Int(0, 30))
                .RuleFor(x => x.SpeedGrowthRate, (faker) => speedGrowthRate ?? faker.Random.Int(0, 100))
                .RuleFor(x => x.BaseDefense, (faker) => baseDefense ?? faker.Random.Int(0, 30))
                .RuleFor(x => x.DefenseGrowthRate, (faker) => defenseGrowthRate ?? faker.Random.Int(0, 100))
                .RuleFor(x => x.BaseResistance, (faker) => baseResistance ?? faker.Random.Int(0, 30))
                .RuleFor(x => x.ResistanceGrowthRate, (faker) => resistanceGrowthRate ?? faker.Random.Int(0, 100));

            return heroFaker;
        }
    }
}