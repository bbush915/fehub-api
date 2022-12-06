using FEHub.Entity.Common.Helpers;
using FEHub.Entity.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL;

internal sealed class GqlSkillMovementType : ObjectGraphType<SkillMovementType>
{
    public GqlSkillMovementType()
    {
        this.Name = nameof(SkillMovementType);
        this.Description = DisplayHelpers.GetDescription<SkillMovementType>();

        this
            .Field(nameof(SkillMovementType.Id), x => x.Id)
            .Description(DisplayHelpers.GetDescription<SkillMovementType>(nameof(SkillMovementType.Id)));

        this
            .Field(nameof(SkillMovementType.MovementType), x => (int)x.MovementType)
            .Description(DisplayHelpers.GetDescription<SkillMovementType>(nameof(SkillMovementType.MovementType)));

        this
            .Field(nameof(SkillMovementType.SkillId), x => x.SkillId)
            .Description(DisplayHelpers.GetDescription<SkillMovementType>(nameof(SkillMovementType.SkillId)));
    }
}
