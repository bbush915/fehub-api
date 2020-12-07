//-----------------------------------------------------------------------------
// <copyright file="StatisticService.Test.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Collections.Generic;

using FEHub.Api.Models;
using FEHub.Api.Services;
using FEHub.Entity.Common.Enumerations;

using Xunit;

namespace FEHub.Tests.Unit.Api.Services
{
    public sealed class StatisticServiceTests
    {
        public static IEnumerable<object[]> Data => new List<object[]>()
        {
            // Baseline
            new object[]
            {
                new StatisticValueContext()
                {
                    Hero = new HeroValues()
                    {
                        BVID = 0,
                        BaseHitPoints = 0,
                        HitPointsGrowthRate = 0,
                        BaseAttack = 0,
                        AttackGrowthRate = 0,
                        BaseSpeed = 0,
                        SpeedGrowthRate = 0,
                        BaseDefense = 0,
                        DefenseGrowthRate = 0,
                        BaseResistance = 0,
                        ResistanceGrowthRate = 0
                    },

                    SummonerSupportRank = null,

                    Rarity = 1,
                    Level = 1,
                    Merges = 0,
                    Dragonflowers = 0,

                    Asset = null,
                    Flaw = null,

                    IncludeSkillBonuses = false,
                    Weapon = null,
                    PassiveA = null,
                    SacredSeal = null
                },
                new StatisticValues()
                {
                    HitPoints = 0,
                    Attack = 0,
                    Speed = 0,
                    Defense = 0,
                    Resistance = 0
                }
            },
            // Alfonse - Prince of Askr: Lv. 40, Df: 1
            new object[]
            {
                new StatisticValueContext()
                {
                    Hero = new HeroValues()
                    {
                        BVID = 23,
                        BaseHitPoints = 17,
                        HitPointsGrowthRate = 55,
                        BaseAttack = 7,
                        AttackGrowthRate = 60,
                        BaseSpeed = 4,
                        SpeedGrowthRate = 45,
                        BaseDefense = 6,
                        DefenseGrowthRate = 55,
                        BaseResistance = 3,
                        ResistanceGrowthRate = 40
                    },

                    SummonerSupportRank = null,

                    Rarity = 5,
                    Level = 40,
                    Merges = 0,
                    Dragonflowers = 1,

                    Asset = null,
                    Flaw = null,

                    IncludeSkillBonuses = true,
                    Weapon = new SkillValues()
                    {
                        HitPointsModifier = 0,
                        AttackModifier = 16,
                        SpeedModifier = 0,
                        DefenseModifier = 0,
                        ResistanceModifier = 0
                    },
                    PassiveA = new SkillValues()
                    {
                        HitPointsModifier = 0,
                        AttackModifier = 0,
                        SpeedModifier = 0,
                        DefenseModifier = 0,
                        ResistanceModifier = 0
                    },
                    SacredSeal = null
                },
                new StatisticValues()
                {
                    HitPoints = 44,
                    Attack = 51,
                    Speed = 25,
                    Defense = 32,
                    Resistance = 22
                }
            },
            // Robin - High Deliverer: Lv. 10, +Atk, -Spd
            new object[]
            {
                new StatisticValueContext()
                {
                    Hero = new HeroValues()
                    {
                        BVID = 67,
                        BaseHitPoints = 16,
                        HitPointsGrowthRate = 50,
                        BaseAttack = 5,
                        AttackGrowthRate = 50,
                        BaseSpeed = 5,
                        SpeedGrowthRate = 50,
                        BaseDefense = 5,
                        DefenseGrowthRate = 50,
                        BaseResistance = 3,
                        ResistanceGrowthRate = 40
                    },

                    SummonerSupportRank = null,

                    Rarity = 4,
                    Level = 10,
                    Merges = 0,
                    Dragonflowers = 0,

                    Asset = Statistics.ATTACK,
                    Flaw = Statistics.SPEED,

                    IncludeSkillBonuses = true,
                    Weapon = new SkillValues()
                    {
                        HitPointsModifier = 0,
                        AttackModifier = 7,
                        SpeedModifier = 0,
                        DefenseModifier = 0,
                        ResistanceModifier = 0
                    },
                    PassiveA = null,
                    SacredSeal = null
                },
                new StatisticValues()
                {
                    HitPoints = 20,
                    Attack = 21,
                    Speed = 12,
                    Defense = 11,
                    Resistance = 7
                }
            },
            // Reinhardt - Thunder's Fist: Lv. 40+4, +Atk
            new object[]
            {
                new StatisticValueContext()
                {
                    Hero = new HeroValues()
                    {
                        BVID = 162,
                        BaseHitPoints = 14,
                        HitPointsGrowthRate = 50,
                        BaseAttack = 6,
                        AttackGrowthRate = 55,
                        BaseSpeed = 4,
                        SpeedGrowthRate = 40,
                        BaseDefense = 3,
                        DefenseGrowthRate = 50,
                        BaseResistance = 6,
                        ResistanceGrowthRate = 40
                    },

                    SummonerSupportRank = null,

                    Rarity = 5,
                    Level = 40,
                    Merges = 4,
                    Dragonflowers = 0,

                    Asset = Statistics.ATTACK,
                    Flaw = Statistics.SPEED,

                    IncludeSkillBonuses = true,
                    Weapon = new SkillValues()
                    {
                        HitPointsModifier = 0,
                        AttackModifier = 9,
                        SpeedModifier = -5,
                        DefenseModifier = 0,
                        ResistanceModifier = 0
                    },
                    PassiveA = new SkillValues()
                    {
                        HitPointsModifier = 0,
                        AttackModifier = 0,
                        SpeedModifier = 0,
                        DefenseModifier = 0,
                        ResistanceModifier = 0
                    },
                    SacredSeal = null
                },
                new StatisticValues()
                {
                    HitPoints = 40,
                    Attack = 46,
                    Speed = 19,
                    Defense = 28,
                    Resistance = 27
                }
            },
            // Effie - Army of One: Lv. 40+3, +Def
            new object[]
            {
                new StatisticValueContext()
                {
                    Hero = new HeroValues()
                    {
                        BVID = 171,
                        BaseHitPoints = 20,
                        HitPointsGrowthRate = 65,
                        BaseAttack = 10,
                        AttackGrowthRate = 65,
                        BaseSpeed = 3,
                        SpeedGrowthRate = 40,
                        BaseDefense = 9,
                        DefenseGrowthRate = 50,
                        BaseResistance = 2,
                        ResistanceGrowthRate = 45
                    },

                    SummonerSupportRank = null,

                    Rarity = 5,
                    Level = 40,
                    Merges = 3,
                    Dragonflowers = 0,

                    Asset = Statistics.DEFENSE,
                    Flaw = Statistics.HIT_POINTS,

                    IncludeSkillBonuses = true,
                    Weapon = new SkillValues()
                    {
                        HitPointsModifier = 5,
                        AttackModifier = 18,
                        SpeedModifier = 0,
                        DefenseModifier = 0,
                        ResistanceModifier = 0
                    },
                    PassiveA = new SkillValues()
                    {
                        HitPointsModifier = 0,
                        AttackModifier = 0,
                        SpeedModifier = 0,
                        DefenseModifier = 0,
                        ResistanceModifier = 0
                    },
                    SacredSeal = null
                },
                new StatisticValues()
                {
                    HitPoints = 57,
                    Attack = 59,
                    Speed = 23,
                    Defense = 37,
                    Resistance = 24
                }
            },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void GetValues(StatisticValueContext context, StatisticValues expectedValues)
        {
            // Arrange

            var statisticService = new StatisticService();

            // Act

            var actualValues = statisticService.GetValues(context);

            // Assert

            Assert.Equal(expectedValues.HitPoints, actualValues.HitPoints);
            Assert.Equal(expectedValues.Attack, actualValues.Attack);
            Assert.Equal(expectedValues.Speed, actualValues.Speed);
            Assert.Equal(expectedValues.Defense, actualValues.Defense);
            Assert.Equal(expectedValues.Resistance, actualValues.Resistance);
        }
    }
}
