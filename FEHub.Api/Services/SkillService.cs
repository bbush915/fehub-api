//-----------------------------------------------------------------------------
// <copyright file="SkillService.cs">
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
using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Models;

using Microsoft.EntityFrameworkCore;

namespace FEHub.Api.Services
{
    public sealed class SkillService : ISkillService
    {
        private readonly FehContext _dbContext;

        public SkillService(FehContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task<List<Skill>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return this._dbContext
                .Skills
                .ToListAsync(cancellationToken);
        }

        public async Task<IDictionary<Guid, Skill>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            return await this._dbContext
                .Skills
                .Where(x => ids.Contains(x.Id))
                .ToDictionaryAsync(k => k.Id, v => v, cancellationToken);
        }

        public Task<Skill> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return this._dbContext
                .Skills
                .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<List<Skill>> QueryByNameAndSkillTypeAsync(string name, SkillTypes? skillType = null, CancellationToken cancellationToken = default)
        {
            if (skillType == SkillTypes.SACRED_SEAL)
            {
                return this._dbContext
                    .Skills
                    .Where(
                        x => 
                            x.Name.Contains(name) && 
                            (x.SkillType == skillType || x.IsAvailableAsSacredSeal)
                    )
                    .ToListAsync(cancellationToken);
            }

            return this._dbContext
                .Skills
                .Where(
                    x => 
                        x.Name.Contains(name) &&
                        ((skillType == null) || (x.SkillType == skillType))
                )
                .ToListAsync(cancellationToken);
        }
    }
}
