//-----------------------------------------------------------------------------
// <copyright file="IStatisticService.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Api.Models;
using FEHub.Entity.Common.Enumerations;

namespace FEHub.Api.Services.Interfaces
{
    public interface IStatisticService
    {
        StatisticValues GetValues(StatisticValueContext context);

        int GetValue(StatisticValueContext context, Statistics statistic);
    }
}
