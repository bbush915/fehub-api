using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations;

/// <summary>
///     Defines constants representing the different favorite marks.
/// </summary>
public enum FavoriteMarks
{
    [Display(
        Name = nameof(Resources.FavoriteMark_Mark1_Name),
        Description = nameof(Resources.FavoriteMark_Mark1_Description),
        ResourceType = typeof(Resources)
    )]
    MARK_1 = 1,

    [Display(
        Name = nameof(Resources.FavoriteMark_Mark2_Name),
        Description = nameof(Resources.FavoriteMark_Mark2_Description),
        ResourceType = typeof(Resources)
    )]
    MARK_2 = 2,

    [Display(
        Name = nameof(Resources.FavoriteMark_Mark3_Name),
        Description = nameof(Resources.FavoriteMark_Mark3_Description),
        ResourceType = typeof(Resources)
    )]
    MARK_3 = 3,

    [Display(
        Name = nameof(Resources.FavoriteMark_Mark4_Name),
        Description = nameof(Resources.FavoriteMark_Mark4_Description),
        ResourceType = typeof(Resources)
    )]
    MARK_4 = 4,

    [Display(
        Name = nameof(Resources.FavoriteMark_Mark5_Name),
        Description = nameof(Resources.FavoriteMark_Mark5_Description),
        ResourceType = typeof(Resources)
    )]
    MARK_5 = 5,

    [Display(
        Name = nameof(Resources.FavoriteMark_Mark6_Name),
        Description = nameof(Resources.FavoriteMark_Mark6_Description),
        ResourceType = typeof(Resources)
    )]
    MARK_6 = 6,

    [Display(
        Name = nameof(Resources.FavoriteMark_Mark7_Name),
        Description = nameof(Resources.FavoriteMark_Mark7_Description),
        ResourceType = typeof(Resources)
    )]
    MARK_7 = 7,

    [Display(
        Name = nameof(Resources.FavoriteMark_Mark8_Name),
        Description = nameof(Resources.FavoriteMark_Mark8_Description),
        ResourceType = typeof(Resources)
    )]
    MARK_8 = 8,
};
