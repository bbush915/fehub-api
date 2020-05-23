//-----------------------------------------------------------------------------
// <copyright file="SummonerSupportRankService.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Collections.Generic;

using FEHub.Api.Services.Common;
using FEHub.Entity.Common.Enumerations;

namespace FEHub.Api.Services
{
    internal sealed class SummonerSupportRankService
    {
        #region Methods
        public List<EnumerationValue> GetAll()
        {
            return new List<EnumerationValue>()
            {
                new EnumerationValue(SummonerSupportRanks.C),
                new EnumerationValue(SummonerSupportRanks.B),
                new EnumerationValue(SummonerSupportRanks.A),
                new EnumerationValue(SummonerSupportRanks.S),
            };
        }
        #endregion
    }
}
