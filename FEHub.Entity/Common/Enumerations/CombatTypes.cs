//-----------------------------------------------------------------------------
// <copyright file="CombatTypes.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations
{
    /// <summary>
    ///     Defines constants representing the different combat types.
    /// </summary>
    public enum CombatTypes
    {
        [Display(
            Name = nameof(Resources.CombatType_Melee_Name),
            Description = nameof(Resources.CombatType_Melee_Description),
            ResourceType = typeof(Resources)
        )]
        MELEE = 1,

        [Display(
            Name = nameof(Resources.CombatType_Ranged_Name),
            Description = nameof(Resources.CombatType_Ranged_Description),
            ResourceType = typeof(Resources)
        )]
        RANGED = 2,
    };
}
