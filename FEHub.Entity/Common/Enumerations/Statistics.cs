//-----------------------------------------------------------------------------
// <copyright file="Statistics.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations
{
    /// <summary>
    ///     Defines constants representing the different statistics.
    /// </summary>
    public enum Statistics
    {
        [Display(
            Name = nameof(Resources.Statistic_HitPoints_Name),
            Description = nameof(Resources.Statistic_HitPoints_Description),
            ShortName = nameof(Resources.Statistic_HitPoints_ShortName),
            ResourceType = typeof(Resources)
        )]
        HIT_POINTS = 1,

        [Display(
            Name = nameof(Resources.Statistic_Attack_Name),
            Description = nameof(Resources.Statistic_Attack_Description),
            ShortName = nameof(Resources.Statistic_Attack_ShortName),
            ResourceType = typeof(Resources)
        )]
        ATTACK = 2,

        [Display(
            Name = nameof(Resources.Statistic_Speed_Name),
            Description = nameof(Resources.Statistic_Speed_Description),
            ShortName = nameof(Resources.Statistic_Speed_ShortName),
            ResourceType = typeof(Resources)
        )]
        SPEED = 3,

        [Display(
            Name = nameof(Resources.Statistic_Defense_Name),
            Description = nameof(Resources.Statistic_Defense_Description),
            ShortName = nameof(Resources.Statistic_Defense_ShortName),
            ResourceType = typeof(Resources)
        )]
        DEFENSE = 4,

        [Display(
            Name = nameof(Resources.Statistic_Resistance_Name),
            Description = nameof(Resources.Statistic_Resistance_Description),
            ShortName = nameof(Resources.Statistic_Resistance_ShortName),
            ResourceType = typeof(Resources)
        )]
        RESISTANCE = 5,
    };
}
