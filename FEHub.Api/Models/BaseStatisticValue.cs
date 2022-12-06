using FEHub.Entity.Common.Enumerations;

namespace FEHub.Api.Models;

public struct BaseStatisticValue
{
    public int AdjustedBaseGrowthRate { get; set; }
    public int AdjustedBaseValue { get; set; }
    public int BaseValue { get; set; }
    public int Ordinal { get; set; }
    public Statistics Statistic { get; set; }
}
