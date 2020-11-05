//-----------------------------------------------------------------------------
// <copyright file="GqlSkillWeaponEffectiveness.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Entity.Common.Helpers;
using FEHub.Entity.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL
{
    internal sealed class GqlSkillWeaponEffectiveness : ObjectGraphType<SkillWeaponEffectiveness>
    {
        public GqlSkillWeaponEffectiveness()
        {
            this.Name = nameof(SkillWeaponEffectiveness);
            this.Description = DisplayHelpers.GetDescription<SkillWeaponEffectiveness>();

            this
                .Field(nameof(SkillWeaponEffectiveness.DamageType), x => (int?)x.DamageType, nullable: true)
                .Description(DisplayHelpers.GetDescription<SkillWeaponEffectiveness>(nameof(SkillWeaponEffectiveness.DamageType)));

            this
                .Field(nameof(SkillWeaponEffectiveness.Id), x => x.Id)
                .Description(DisplayHelpers.GetDescription<SkillWeaponEffectiveness>(nameof(SkillWeaponEffectiveness.Id)));

            this
                .Field(nameof(SkillWeaponEffectiveness.MovementType), x => (int?)x.MovementType, nullable: true)
                .Description(DisplayHelpers.GetDescription<SkillWeaponEffectiveness>(nameof(SkillWeaponEffectiveness.MovementType)));

            this
                .Field(nameof(SkillWeaponEffectiveness.SkillId), x => x.SkillId)
                .Description(DisplayHelpers.GetDescription<SkillWeaponEffectiveness>(nameof(SkillWeaponEffectiveness.SkillId)));

            this
                .Field(nameof(SkillWeaponEffectiveness.Weapon), x => (int?)x.Weapon, nullable: true)
                .Description(DisplayHelpers.GetDescription<SkillWeaponEffectiveness>(nameof(SkillWeaponEffectiveness.Weapon)));

            this
                .Field(nameof(SkillWeaponEffectiveness.WeaponEffectivenessType), x => (int)x.WeaponEffectivenessType)
                .Description(DisplayHelpers.GetDescription<SkillWeaponEffectiveness>(nameof(SkillWeaponEffectiveness.WeaponEffectivenessType)));
        }
    }
}
