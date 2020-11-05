//-----------------------------------------------------------------------------
// <copyright file="StatisticValues.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

namespace FEHub.Api.Models
{
    public struct StatisticValues
    {
        public int HitPoints { get; set; }
        public int Attack { get; set; }
        public int Speed { get; set; }
        public int Defense { get; set; }
        public int Resistance { get; set; }
    }
}
