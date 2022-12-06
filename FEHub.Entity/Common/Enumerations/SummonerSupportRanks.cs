using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

namespace FEHub.Entity.Common.Enumerations;

/// <summary>
///     Defines constants representing the different summoner support ranks.
/// </summary>
public enum SummonerSupportRanks
{
    [Display(
        Name = nameof(Resources.SummonerSupportRank_C_Name),
        Description = nameof(Resources.SummonerSupportRank_C_Description),
        ResourceType = typeof(Resources)
    )]
    C = 1,

    [Display(
        Name = nameof(Resources.SummonerSupportRank_B_Name),
        Description = nameof(Resources.SummonerSupportRank_B_Description),
        ResourceType = typeof(Resources)
    )]
    B = 2,

    [Display(
        Name = nameof(Resources.SummonerSupportRank_A_Name),
        Description = nameof(Resources.SummonerSupportRank_A_Description),
        ResourceType = typeof(Resources)
    )]
    A = 3,

    [Display(
        Name = nameof(Resources.SummonerSupportRank_S_Name),
        Description = nameof(Resources.SummonerSupportRank_S_Description),
        ResourceType = typeof(Resources)
    )]
    S = 4,
};
