using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations;

/// <summary>
///     Defines constants representing the different languages.
/// </summary>
public enum Languages
{
    [Display(
        Name = nameof(Resources.Language_English_Name),
        Description = nameof(Resources.Language_English_Description),
        ResourceType = typeof(Resources)
    )]
    ENGLISH = 1,

    [Display(
        Name = nameof(Resources.Language_Japanese_Name),
        Description = nameof(Resources.Language_Japanese_Description),
        ResourceType = typeof(Resources)
    )]
    JAPANESE = 2,
};
