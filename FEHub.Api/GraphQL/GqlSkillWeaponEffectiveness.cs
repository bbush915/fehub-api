//-----------------------------------------------------------------------------
// <copyright file="GqlSkillWeaponEffectiveness.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Entity.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL
{
    internal sealed class GqlSkillWeaponEffectiveness : ObjectGraphType<SkillWeaponEffectiveness>
    {
        #region Constructors
        public GqlSkillWeaponEffectiveness()
        {
            this.Name = nameof(SkillWeaponEffectiveness);

            this.Field(nameof(SkillWeaponEffectiveness.DamageType), x => (int?)x.DamageType, nullable: true);
            this.Field(nameof(SkillWeaponEffectiveness.Id), x => x.Id);
            this.Field(nameof(SkillWeaponEffectiveness.MovementType), x => (int?)x.MovementType, nullable: true);
            this.Field(nameof(SkillWeaponEffectiveness.SkillId), x => x.SkillId);
            this.Field(nameof(SkillWeaponEffectiveness.Weapon), x => (int?)x.Weapon, nullable: true);
            this.Field(nameof(SkillWeaponEffectiveness.WeaponEffectivenessType), x => (int)x.WeaponEffectivenessType);
        }
        #endregion
    }
}
