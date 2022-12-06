using FEHub.Api.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL.Inputs;

internal sealed class GqlHeroValues : InputObjectGraphType<HeroValues>
{
    public GqlHeroValues()
    {
        this.Name = nameof(HeroValues);

        this.Field(nameof(HeroValues.BVID).ToLowerInvariant(), x => x.BVID);
        this.Field(nameof(HeroValues.BaseHitPoints), x => x.BaseHitPoints);
        this.Field(nameof(HeroValues.HitPointsGrowthRate), x => x.HitPointsGrowthRate);
        this.Field(nameof(HeroValues.BaseAttack), x => x.BaseAttack);
        this.Field(nameof(HeroValues.AttackGrowthRate), x => x.AttackGrowthRate);
        this.Field(nameof(HeroValues.BaseSpeed), x => x.BaseSpeed);
        this.Field(nameof(HeroValues.SpeedGrowthRate), x => x.SpeedGrowthRate);
        this.Field(nameof(HeroValues.BaseDefense), x => x.BaseDefense);
        this.Field(nameof(HeroValues.DefenseGrowthRate), x => x.DefenseGrowthRate);
        this.Field(nameof(HeroValues.BaseResistance), x => x.BaseResistance);
        this.Field(nameof(HeroValues.ResistanceGrowthRate), x => x.ResistanceGrowthRate);
    }
}
