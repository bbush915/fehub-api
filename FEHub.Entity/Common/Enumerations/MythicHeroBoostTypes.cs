using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations;

/// <summary>
///     Defines constants representing the different mythic hero boost types.
/// </summary>
public enum MythicHeroBoostTypes
{
    [Display(
        Name = nameof(Resources.MythicHeroBoostType_Attack_Name),
        Description = nameof(Resources.MythicHeroBoostType_Attack_Description),
        ResourceType = typeof(Resources)
    )]
    ATTACK = 1,

    [Display(
        Name = nameof(Resources.MythicHeroBoostType_Speed_Name),
        Description = nameof(Resources.MythicHeroBoostType_Speed_Description),
        ResourceType = typeof(Resources)
    )]
    SPEED = 2,

    [Display(
        Name = nameof(Resources.MythicHeroBoostType_Defense_Name),
        Description = nameof(Resources.MythicHeroBoostType_Defense_Description),
        ResourceType = typeof(Resources)
    )]
    DEFENSE = 3,

    [Display(
        Name = nameof(Resources.MythicHeroBoostType_Resistance_Name),
        Description = nameof(Resources.MythicHeroBoostType_Resistance_Description),
        ResourceType = typeof(Resources)
    )]
    RESISTANCE = 4,
};
