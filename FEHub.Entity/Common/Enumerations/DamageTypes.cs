using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations;

/// <summary>
///     Defines constants representing the different damage types.
/// </summary>
public enum DamageTypes
{
    [Display(
        Name = nameof(Resources.DamageType_Physical_Name),
        Description = nameof(Resources.DamageType_Physical_Description),
        ResourceType = typeof(Resources)
    )]
    PHYSICAL = 1,

    [Display(
        Name = nameof(Resources.DamageType_Magical_Name),
        Description = nameof(Resources.DamageType_Magical_Description),
        ResourceType = typeof(Resources)
    )]
    MAGICAL = 2,
};
