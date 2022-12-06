using FEHub.Api.Models;
using FEHub.Entity.Common.Enumerations;

namespace FEHub.Api.Services.Interfaces;

public interface IStatisticService
{
    StatisticValues GetValues(StatisticValueContext context);

    int GetValue(StatisticValueContext context, Statistics statistic);
}
