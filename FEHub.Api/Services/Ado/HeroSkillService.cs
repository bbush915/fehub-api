using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Api.Options;
using FEHub.Api.Services.Interfaces;
using FEHub.Api.Utilities;
using FEHub.Entity.Common;
using FEHub.Entity.Models;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace FEHub.Api.Services.Ado;

public sealed class HeroSkillService : IHeroSkillService
{
    private readonly string _connectionString;

    public HeroSkillService(IOptions<DatabaseOptions> databaseOptions)
    {
        this._connectionString = databaseOptions.Value.ConnectionString;
    }

    public async Task<ILookup<Guid, HeroSkill>> GetByHeroIdsAsync(IEnumerable<Guid> heroIds, CancellationToken cancellationToken = default)
    {
        using var connection = new SqlConnection(this._connectionString);

        await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();

        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Constants.Database.StoredProcedures.HeroSkill.GetByHeroIds;

        var parameter = new SqlParameter("HeroIds", SqlDbType.Structured) { TypeName = Constants.Database.UserDefinedTableTypes.GuidList };
        command.Parameters.Add(parameter).Value = AdoHelpers.BuildDataTable(heroIds);

        using var reader = await command.ExecuteReaderAsync(cancellationToken);

        var heroSkills = new List<HeroSkill>();

        while (await reader.ReadAsync(cancellationToken))
        {
            var heroSkill = BuildHeroSkill(reader);
            heroSkills.Add(heroSkill);
        }

        return heroSkills.ToLookup(x => x.HeroId);
    }

    private static HeroSkill BuildHeroSkill(SqlDataReader reader)
    {
        var heroSkill = new HeroSkill()
        {
            Id = reader.GetInt32(0),
            HeroId = reader.GetGuid(1),
            SkillId = reader.GetGuid(2),
            SkillPosition = reader.GetInt32(3),
            DefaultRarity = reader.IsDBNull(4) ? null : reader.GetInt32(4),
            UnlockRarity = reader.GetInt32(5)
        };

        return heroSkill;
    }
}
