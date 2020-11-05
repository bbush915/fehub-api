//-----------------------------------------------------------------------------
// <copyright file="StatisticValueContext.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Entity.Common.Enumerations;

namespace FEHub.Api.Models
{
    public struct StatisticValueContext
    {
        public HeroValues Hero { get; set; }

        public int Rarity { get; set; }
        public int Level { get; set; }
        public int Merges { get; set; }
        public int Dragonflowers { get; set; }

        public Statistics? Asset { get; set; }
        public Statistics? Flaw { get; set; }

        public bool IncludeSkillBonuses { get; set; }
        public SkillValues? Weapon { get; set; }
        public SkillValues? PassiveA { get; set; }
        public SkillValues? SacredSeal { get; set; }

        public SummonerSupportRanks? SummonerSupportRank { get; set; }
    }
}
