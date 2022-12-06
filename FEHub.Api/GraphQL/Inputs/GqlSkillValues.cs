using FEHub.Api.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL.Inputs;

internal sealed class GqlSkillValues : InputObjectGraphType<SkillValues>
{
    public GqlSkillValues()
    {
        this.Name = nameof(SkillValues);

        this.Field(nameof(SkillValues.HitPointsModifier), x => x.HitPointsModifier);
        this.Field(nameof(SkillValues.AttackModifier), x => x.AttackModifier);
        this.Field(nameof(SkillValues.SpeedModifier), x => x.SpeedModifier);
        this.Field(nameof(SkillValues.DefenseModifier), x => x.DefenseModifier);
        this.Field(nameof(SkillValues.ResistanceModifier), x => x.ResistanceModifier);
    }
}
