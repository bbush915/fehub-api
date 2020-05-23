//-----------------------------------------------------------------------------
// <copyright file="MovementTypes.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations
{
    /// <summary>
    ///     Defines constants representing the different movement types.
    /// </summary>
    public enum MovementTypes
    {
        [Display(
            Name = nameof(Resources.MovementType_Armored_Name),
            Description = nameof(Resources.MovementType_Armored_Description),
            ResourceType = typeof(Resources)
        )]
        ARMORED = 1,

        [Display(
            Name = nameof(Resources.MovementType_Cavalry_Name),
            Description = nameof(Resources.MovementType_Cavalry_Description),
            ResourceType = typeof(Resources)
        )]
        CAVALRY = 2,

        [Display(
            Name = nameof(Resources.MovementType_Flying_Name),
            Description = nameof(Resources.MovementType_Flying_Description),
            ResourceType = typeof(Resources)
        )]
        FLYING = 3,

        [Display(
            Name = nameof(Resources.MovementType_Infantry_Name),
            Description = nameof(Resources.MovementType_Infantry_Description),
            ResourceType = typeof(Resources)
        )]
        INFANTRY = 4,
    };
}
