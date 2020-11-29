//-----------------------------------------------------------------------------
// <copyright file="GqlStatisticValueContext.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Api.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL.Inputs
{
    internal sealed class GqlStatisticValueContext : InputObjectGraphType<StatisticValueContext>
    {
        public GqlStatisticValueContext()
        {
            this.Name = nameof(StatisticValueContext);

            this.Field(nameof(StatisticValueContext.Hero), x => x.Hero, type: typeof(GqlHeroValues));
            this.Field(nameof(StatisticValueContext.SummonerSupportRank), x => (int?)x.SummonerSupportRank, nullable: true);
            this.Field(nameof(StatisticValueContext.Rarity), x => x.Rarity);
            this.Field(nameof(StatisticValueContext.Level), x => x.Level);
            this.Field(nameof(StatisticValueContext.Merges), x => x.Merges);
            this.Field(nameof(StatisticValueContext.Dragonflowers), x => x.Dragonflowers);
            this.Field(nameof(StatisticValueContext.Asset), x => (int?)x.Asset, nullable: true);
            this.Field(nameof(StatisticValueContext.Flaw), x => (int?)x.Flaw, nullable: true);
            this.Field(nameof(StatisticValueContext.IncludeSkillBonuses), x => x.IncludeSkillBonuses);
            this.Field(nameof(StatisticValueContext.Weapon), x => x.Weapon, type: typeof(GqlSkillValues), nullable: true);
            this.Field(nameof(StatisticValueContext.PassiveA), x => x.PassiveA, type: typeof(GqlSkillValues), nullable: true);
            this.Field(nameof(StatisticValueContext.SacredSeal), x => x.SacredSeal, type: typeof(GqlSkillValues), nullable: true);
        }
    }
}
