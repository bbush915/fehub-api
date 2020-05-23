//-----------------------------------------------------------------------------
// <copyright file="Elements.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations
{
    /// <summary>
    ///     Defines constants representing the different elements.
    /// </summary>
    public enum Elements
    {
        // NOTE(Bryan) - Legendary Heroes

        [Display(
            Name = nameof(Resources.Element_Fire_Name),
            Description = nameof(Resources.Element_Fire_Description),
            ResourceType = typeof(Resources)
        )]
        FIRE = 1,

        [Display(
            Name = nameof(Resources.Element_Water_Name),
            Description = nameof(Resources.Element_Water_Description),
            ResourceType = typeof(Resources)
        )]
        WATER = 2,

        [Display(
            Name = nameof(Resources.Element_Wind_Name),
            Description = nameof(Resources.Element_Wind_Description),
            ResourceType = typeof(Resources)
        )]
        WIND = 3,

        [Display(
            Name = nameof(Resources.Element_Earth_Name),
            Description = nameof(Resources.Element_Earth_Description),
            ResourceType = typeof(Resources)
        )]
        EARTH = 4,

        // NOTE(Bryan) - Mythic Heroes

        [Display(
            Name = nameof(Resources.Element_Light_Name),
            Description = nameof(Resources.Element_Light_Description),
            ResourceType = typeof(Resources)
        )]
        LIGHT = 5,

        [Display(
            Name = nameof(Resources.Element_Dark_Name),
            Description = nameof(Resources.Element_Dark_Description),
            ResourceType = typeof(Resources)
        )]
        DARK = 6,

        [Display(
            Name = nameof(Resources.Element_Anima_Name),
            Description = nameof(Resources.Element_Anima_Description),
            ResourceType = typeof(Resources)
        )]
        ASTRA = 7,

        [Display(
            Name = nameof(Resources.Element_Astra_Name),
            Description = nameof(Resources.Element_Astra_Description),
            ResourceType = typeof(Resources)
        )]
        ANIMA = 8,
    };
}
