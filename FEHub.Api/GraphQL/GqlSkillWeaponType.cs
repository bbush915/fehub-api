//-----------------------------------------------------------------------------
// <copyright file="GqlSkillWeaponType.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Entity.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL
{
    internal sealed class GqlSkillWeaponType : ObjectGraphType<SkillWeaponType>
    {
        #region Constructors
        public GqlSkillWeaponType()
        {
            this.Name = nameof(SkillWeaponType);

            this.Field(nameof(SkillWeaponType.Color), x => (int)x.Color);
            this.Field(nameof(SkillWeaponType.Id), x => x.Id);
            this.Field(nameof(SkillWeaponType.SkillId), x => x.SkillId);
            this.Field(nameof(SkillWeaponType.Weapon), x => (int)x.Weapon);
        }
        #endregion
    }
}
