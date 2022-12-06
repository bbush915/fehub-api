using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations;

/// <summary>
///     Defines constants representing the different skill types.
/// </summary>
public enum SkillTypes
{
    [Display(
        Name = nameof(Resources.SkillType_Weapon_Name),
        Description = nameof(Resources.SkillType_Weapon_Description),
        ResourceType = typeof(Resources)
    )]
    WEAPON = 1,

    [Display(
        Name = nameof(Resources.SkillType_Assist_Name),
        Description = nameof(Resources.SkillType_Assist_Description),
        ResourceType = typeof(Resources)
    )]
    ASSIST = 2,

    [Display(
        Name = nameof(Resources.SkillType_Special_Name),
        Description = nameof(Resources.SkillType_Special_Description),
        ResourceType = typeof(Resources)
    )]
    SPECIAL = 3,

    [Display(
        Name = nameof(Resources.SkillType_PassiveA_Name),
        Description = nameof(Resources.SkillType_PassiveA_Description),
        ResourceType = typeof(Resources)
    )]
    PASSIVE_A = 4,

    [Display(
        Name = nameof(Resources.SkillType_PassiveB_Name),
        Description = nameof(Resources.SkillType_PassiveB_Description),
        ResourceType = typeof(Resources)
    )]
    PASSIVE_B = 5,

    [Display(
        Name = nameof(Resources.SkillType_PassiveC_Name),
        Description = nameof(Resources.SkillType_PassiveC_Description),
        ResourceType = typeof(Resources)
    )]
    PASSIVE_C = 6,

    [Display(
        Name = nameof(Resources.SkillType_SacredSeal_Name),
        Description = nameof(Resources.SkillType_SacredSeal_Description),
        ResourceType = typeof(Resources)
    )]
    SACRED_SEAL = 7,
};
