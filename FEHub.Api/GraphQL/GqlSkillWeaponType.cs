using FEHub.Entity.Common.Helpers;
using FEHub.Entity.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL;

internal sealed class GqlSkillWeaponType : ObjectGraphType<SkillWeaponType>
{
    public GqlSkillWeaponType()
    {
        this.Name = nameof(SkillWeaponType);
        this.Description = DisplayHelpers.GetDescription<SkillWeaponType>();

        this
            .Field(nameof(SkillWeaponType.Color), x => (int)x.Color)
            .Description(DisplayHelpers.GetDescription<SkillWeaponType>(nameof(SkillWeaponType.Color)));

        this
            .Field(nameof(SkillWeaponType.Id), x => x.Id)
            .Description(DisplayHelpers.GetDescription<SkillWeaponType>(nameof(SkillWeaponType.Id)));

        this
            .Field(nameof(SkillWeaponType.SkillId), x => x.SkillId)
            .Description(DisplayHelpers.GetDescription<SkillWeaponType>(nameof(SkillWeaponType.SkillId)));

        this
            .Field(nameof(SkillWeaponType.Weapon), x => (int)x.Weapon)
            .Description(DisplayHelpers.GetDescription<SkillWeaponType>(nameof(SkillWeaponType.Weapon)));
    }
}
