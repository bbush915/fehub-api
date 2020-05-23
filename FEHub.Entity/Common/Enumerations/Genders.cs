//-----------------------------------------------------------------------------
// <copyright file="Genders.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations
{
    /// <summary>
    ///     Defines constants representing the different genders.
    /// </summary>
    public enum Genders
    {
        [Display(
            Name = nameof(Resources.Gender_Female_Name),
            Description = nameof(Resources.Gender_Female_Description),
            ResourceType = typeof(Resources)
        )]
        FEMALE = 1,

        [Display(
            Name = nameof(Resources.Gender_Male_Name),
            Description = nameof(Resources.Gender_Male_Description),
            ResourceType = typeof(Resources)
        )]
        MALE = 2,

        [Display(
            Name = nameof(Resources.Gender_None_Name),
            Description = nameof(Resources.Gender_None_Description),
            ResourceType = typeof(Resources)
        )]
        NONE = 3,
    };
}
