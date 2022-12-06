using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations;

/// <summary>
///     Defines constants representing the different legendary hero boost types.
/// </summary>
public enum LegendaryHeroBoostTypes
{
    [Display(
        Name = nameof(Resources.LegendaryHeroBoostType_Attack_Name),
        Description = nameof(Resources.LegendaryHeroBoostType_Attack_Description),
        ResourceType = typeof(Resources)
    )]
    ATTACK = 1,

    [Display(
        Name = nameof(Resources.LegendaryHeroBoostType_Speed_Name),
        Description = nameof(Resources.LegendaryHeroBoostType_Speed_Description),
        ResourceType = typeof(Resources)
    )]
    SPEED = 2,

    [Display(
        Name = nameof(Resources.LegendaryHeroBoostType_Defense_Name),
        Description = nameof(Resources.LegendaryHeroBoostType_Defense_Description),
        ResourceType = typeof(Resources)
    )]
    DEFENSE = 3,

    [Display(
        Name = nameof(Resources.LegendaryHeroBoostType_Resistance_Name),
        Description = nameof(Resources.LegendaryHeroBoostType_Resistance_Description),
        ResourceType = typeof(Resources)
    )]
    RESISTANCE = 4,

    [Display(
        Name = nameof(Resources.LegendaryHeroBoostType_PairUp_Name),
        Description = nameof(Resources.LegendaryHeroBoostType_PairUp_Description),
        ResourceType = typeof(Resources)
    )]
    PAIR_UP = 5,
};
