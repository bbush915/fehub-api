using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations;

/// <summary>
///     Defines constants representing the different weapons.
/// </summary>
public enum Weapons
{
    [Display(
        Name = nameof(Resources.Weapon_Sword_Name),
        Description = nameof(Resources.Weapon_Sword_Description),
        ResourceType = typeof(Resources)
    )]
    SWORD = 1,

    [Display(
        Name = nameof(Resources.Weapon_Lance_Name),
        Description = nameof(Resources.Weapon_Lance_Description),
        ResourceType = typeof(Resources)
    )]
    LANCE = 2,

    [Display(
        Name = nameof(Resources.Weapon_Axe_Name),
        Description = nameof(Resources.Weapon_Axe_Description),
        ResourceType = typeof(Resources)
    )]
    AXE = 3,

    [Display(
        Name = nameof(Resources.Weapon_Bow_Name),
        Description = nameof(Resources.Weapon_Bow_Description),
        ResourceType = typeof(Resources)
    )]
    BOW = 4,

    [Display(
        Name = nameof(Resources.Weapon_Dagger_Name),
        Description = nameof(Resources.Weapon_Dagger_Description),
        ResourceType = typeof(Resources)
    )]
    DAGGER = 5,

    [Display(
        Name = nameof(Resources.Weapon_Tome_Name),
        Description = nameof(Resources.Weapon_Tome_Description),
        ResourceType = typeof(Resources)
    )]
    TOME = 6,

    [Display(
        Name = nameof(Resources.Weapon_Staff_Name),
        Description = nameof(Resources.Weapon_Staff_Description),
        ResourceType = typeof(Resources)
    )]
    STAFF = 7,

    [Display(
        Name = nameof(Resources.Weapon_Dragonstone_Name),
        Description = nameof(Resources.Weapon_Dragonstone_Description),
        ResourceType = typeof(Resources)
    )]
    DRAGONSTONE = 8,

    [Display(
        Name = nameof(Resources.Weapon_Beaststone_Name),
        Description = nameof(Resources.Weapon_Beaststone_Description),
        ResourceType = typeof(Resources)
    )]
    BEASTSTONE = 9,
};
