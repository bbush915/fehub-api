using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations;

/// <summary>
///     Defines constants representing the different weapon refine types.
/// </summary>
public enum WeaponRefineTypes
{
    [Display(
        Name = nameof(Resources.WeaponRefineType_Attack_Name),
        Description = nameof(Resources.WeaponRefineType_Attack_Description),
        ResourceType = typeof(Resources)
    )]
    ATTACK = 1,

    [Display(
        Name = nameof(Resources.WeaponRefineType_Speed_Name),
        Description = nameof(Resources.WeaponRefineType_Speed_Description),
        ResourceType = typeof(Resources)
    )]
    SPEED = 2,

    [Display(
        Name = nameof(Resources.WeaponRefineType_Defense_Name),
        Description = nameof(Resources.WeaponRefineType_Defense_Description),
        ResourceType = typeof(Resources)
    )]
    DEFENSE = 3,

    [Display(
        Name = nameof(Resources.WeaponRefineType_Resistance_Name),
        Description = nameof(Resources.WeaponRefineType_Resistance_Description),
        ResourceType = typeof(Resources)
    )]
    RESISTANCE = 4,

    [Display(
        Name = nameof(Resources.WeaponRefineType_Effect1_Name),
        Description = nameof(Resources.WeaponRefineType_Effect1_Description),
        ResourceType = typeof(Resources)
    )]
    EFFECT_1 = 5,

    [Display(
        Name = nameof(Resources.WeaponRefineType_Effect2_Name),
        Description = nameof(Resources.WeaponRefineType_Effect2_Description),
        ResourceType = typeof(Resources)
    )]
    EFFECT_2 = 6,
};
