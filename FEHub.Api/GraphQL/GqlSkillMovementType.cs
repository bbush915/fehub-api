//-----------------------------------------------------------------------------
// <copyright file="GqlSkillMovementType.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Entity.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL
{
    internal sealed class GqlSkillMovementType : ObjectGraphType<SkillMovementType>
    {
        #region Constructors
        public GqlSkillMovementType()
        {
            this.Name = nameof(SkillMovementType);

            this.Field(nameof(SkillMovementType.Id), x => x.Id);
            this.Field(nameof(SkillMovementType.MovementType), x => (int)x.MovementType);
            this.Field(nameof(SkillMovementType.SkillId), x => x.SkillId);
        }
        #endregion
    }
}
