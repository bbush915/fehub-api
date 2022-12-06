using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations;

/// <summary>
///     Defines constants representing the different weapon effectiveness types.
/// </summary>
public enum WeaponEffectivenessTypes
{
    [Display(
        Name = nameof(Resources.WeaponEffectivenessType_MovementType_Name),
        Description = nameof(Resources.WeaponEffectivenessType_MovementType_Description),
        ResourceType = typeof(Resources)
    )]
    MOVEMENT_TYPE = 1,

    [Display(
        Name = nameof(Resources.WeaponEffectivenessType_Weapon_Name),
        Description = nameof(Resources.WeaponEffectivenessType_Weapon_Description),
        ResourceType = typeof(Resources)
    )]
    WEAPON = 2,

    [Display(
        Name = nameof(Resources.WeaponEffectivenessType_DamageType_Name),
        Description = nameof(Resources.WeaponEffectivenessType_DamageType_Description),
        ResourceType = typeof(Resources)
    )]
    DAMAGE_TYPE = 3,
};
