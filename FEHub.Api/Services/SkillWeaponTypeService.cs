//-----------------------------------------------------------------------------
// <copyright file="SkillWeaponTypeService.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Api.Services.Interfaces;
using FEHub.Entity;
using FEHub.Entity.Models;

using Microsoft.EntityFrameworkCore;

namespace FEHub.Api.Services
{
    public sealed class SkillWeaponTypeService : ISkillWeaponTypeService
    {
        private readonly FehContext _dbContext;

        public SkillWeaponTypeService(FehContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task<ILookup<Guid, SkillWeaponType>> GetBySkillIdsAsync(IEnumerable<Guid> skillIds, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(
                this._dbContext
                    .SkillWeaponTypes
                    .Where(x => skillIds.Contains(x.SkillId))
                    .ToLookup(x => x.SkillId)
            );
        }
    }
}
