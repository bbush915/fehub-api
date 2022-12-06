using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Models;

namespace FEHub.Api.Services.Interfaces;

public interface ISkillService
{
    Task<List<Skill>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<IDictionary<Guid, Skill>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);

    Task<Skill> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<Skill>> QueryByNameAndSkillTypeAsync(string name, SkillTypes? skillType = null, CancellationToken cancellationToken = default);
}
