using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations;

/// <summary>
///     Defines constants representing the different colors.
/// </summary>
public enum Colors
{
    [Display(
        Name = nameof(Resources.Color_Red_Name),
        Description = nameof(Resources.Color_Red_Description),
        ResourceType = typeof(Resources)
    )]
    RED = 1,

    [Display(
        Name = nameof(Resources.Color_Blue_Name),
        Description = nameof(Resources.Color_Blue_Description),
        ResourceType = typeof(Resources)
    )]
    BLUE = 2,

    [Display(
        Name = nameof(Resources.Color_Green_Name),
        Description = nameof(Resources.Color_Green_Description),
        ResourceType = typeof(Resources)
    )]
    GREEN = 3,

    [Display(
        Name = nameof(Resources.Color_Colorless_Name),
        Description = nameof(Resources.Color_Colorless_Description),
        ResourceType = typeof(Resources)
    )]
    COLORLESS = 4,
};
