//-----------------------------------------------------------------------------
// <copyright file="AllySupportRanks.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations
{
    /// <summary>
    ///     Defines constants representing the different ally support ranks.
    /// </summary>
    public enum AllySupportRanks
    {
        [Display(
            Name = nameof(Resources.AllySupportRank_C_Name),
            Description = nameof(Resources.AllySupportRank_C_Description),
            ResourceType = typeof(Resources)
        )]
        C = 1,

        [Display(
            Name = nameof(Resources.AllySupportRank_B_Name),
            Description = nameof(Resources.AllySupportRank_B_Description),
            ResourceType = typeof(Resources)
        )]
        B = 2,

        [Display(
            Name = nameof(Resources.AllySupportRank_A_Name),
            Description = nameof(Resources.AllySupportRank_A_Description),
            ResourceType = typeof(Resources)
        )]
        A = 3,

        [Display(
            Name = nameof(Resources.AllySupportRank_S_Name),
            Description = nameof(Resources.AllySupportRank_S_Description),
            ResourceType = typeof(Resources)
        )]
        S = 4,
    };
}
