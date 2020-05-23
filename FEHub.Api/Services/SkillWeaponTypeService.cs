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

using FEHub.Entity;
using FEHub.Entity.Models;

using Microsoft.EntityFrameworkCore;

namespace FEHub.Api.Services
{
    internal sealed class SkillWeaponTypeService
    {
        #region Fields
        private readonly FehContext _dbContext;
        #endregion

        #region Constructors
        public SkillWeaponTypeService(FehContext dbContext)
        {
            this._dbContext = dbContext;
        }
        #endregion

        #region Methods
        public Task<ILookup<Guid, SkillWeaponType>> GetBySkillIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                this._dbContext
                    .SkillWeaponTypes
                    .Where(x => ids.Contains(x.SkillId))
                    .ToLookup(x => x.SkillId)
            );
        }
        #endregion
    }
}
