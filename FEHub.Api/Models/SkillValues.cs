﻿//-----------------------------------------------------------------------------
// <copyright file="SkillValues.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

namespace FEHub.Api.Models
{
    public sealed class SkillValues
    {
        public int HitPointsModifier { get; set; }
        public int AttackModifier { get; set; }
        public int SpeedModifier { get; set; }
        public int DefenseModifier { get; set; }
        public int ResistanceModifier { get; set; }
    }
}
