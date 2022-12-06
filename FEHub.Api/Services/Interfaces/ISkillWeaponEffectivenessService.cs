﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Entity.Models;

namespace FEHub.Api.Services.Interfaces;

public interface ISkillWeaponEffectivenessService
{
    Task<ILookup<Guid, SkillWeaponEffectiveness>> GetBySkillIdsAsync(IEnumerable<Guid> skillIds, CancellationToken cancellationToken = default);
}
