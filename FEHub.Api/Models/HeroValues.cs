//-----------------------------------------------------------------------------
// <copyright file="HeroValues.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

namespace FEHub.Api.Models
{
    public sealed class HeroValues
    {
        public int BVID { get; set; }
        public int BaseHitPoints { get; set; }
        public int HitPointsGrowthRate { get; set; }
        public int BaseAttack { get; set; }
        public int AttackGrowthRate { get; set; }
        public int BaseSpeed { get; set; }
        public int SpeedGrowthRate { get; set; }
        public int BaseDefense { get; set; }
        public int DefenseGrowthRate { get; set; }
        public int BaseResistance { get; set; }
        public int ResistanceGrowthRate { get; set; }
    }
}
