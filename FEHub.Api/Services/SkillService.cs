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

using FEHub.Entity;
using FEHub.Entity.Models;

using Microsoft.EntityFrameworkCore;

namespace FEHub.Api.Services
{
    internal sealed class SkillService
    {
        #region Fields
        private readonly FehContext _dbContext;
        #endregion

        #region Constructors
        public SkillService(FehContext dbContext)
        {
            this._dbContext = dbContext;
        }
        #endregion

        #region Methods
        public async Task<List<Skill>> GetAllAsync()
        {
            return await this._dbContext
                .Skills
                .ToListAsync();
        }

        public async Task<IDictionary<Guid, Skill>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
        {
            return await this._dbContext
                .Skills
                .Where(x => ids.Contains(x.Id))
                .ToDictionaryAsync(
                    x => x.Id,
                    y => y
                );
        }

        public async Task<Skill> GetByIdAsync(Guid id)
        {
            return await this._dbContext
                .Skills
                .SingleOrDefaultAsync(x => x.Id == id);
        }
        #endregion
    }
}
