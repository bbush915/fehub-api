using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations;

/// <summary>
///     Defines constants representing the different accessory types.
/// </summary>
public enum AccessoryTypes
{
    [Display(
        Name = nameof(Resources.AccessoryType_Hair_Name),
        Description = nameof(Resources.AccessoryType_Hair_Description),
        ResourceType = typeof(Resources)
    )]
    HAIR = 1,

    [Display(
        Name = nameof(Resources.AccessoryType_Hat_Name),
        Description = nameof(Resources.AccessoryType_Hat_Description),
        ResourceType = typeof(Resources)
    )]
    HAT = 2,

    [Display(
        Name = nameof(Resources.AccessoryType_Mask_Name),
        Description = nameof(Resources.AccessoryType_Mask_Description),
        ResourceType = typeof(Resources)
    )]
    MASK = 3,

    [Display(
        Name = nameof(Resources.AccessoryType_Tiara_Name),
        Description = nameof(Resources.AccessoryType_Tiara_Description),
        ResourceType = typeof(Resources)
    )]
    TIARA = 4,
};
