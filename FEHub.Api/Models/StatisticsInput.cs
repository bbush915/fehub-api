//-----------------------------------------------------------------------------
// <copyright file="StatisticsInput.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;

using FEHub.Entity.Common.Enumerations;

namespace FEHub.Api.Models
{
    public struct StatisticsInput
    {
        public Guid HeroId { get; set; }

        public SummonerSupportRanks? SummonerSupportRank { get; set; }

        public int Rarity { get; set; }
        public int Level { get; set; }
        public int Merges { get; set; }
        public int Dragonflowers { get; set; }

        public Statistics? Asset { get; set; }
        public Statistics? Flaw { get; set; }

        public bool IncludeSkillBonuses { get; set; }
        public Guid? WeaponId { get; set; }
        public Guid? PassiveAId { get; set; }
        public Guid? SacredSealId { get; set; }
    }
}
