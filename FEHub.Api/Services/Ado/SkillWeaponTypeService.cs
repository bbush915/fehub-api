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
using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Models;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace FEHub.Api.Services.Ado;

public sealed class SkillWeaponTypeService : ISkillWeaponTypeService
{
    private readonly string _connectionString;

    public SkillWeaponTypeService(IOptions<DatabaseOptions> databaseOptions)
    {
        this._connectionString = databaseOptions.Value.ConnectionString;
    }

    public async Task<ILookup<Guid, SkillWeaponType>> GetBySkillIdsAsync(IEnumerable<Guid> skillIds, CancellationToken cancellationToken = default)
    {
        using var connection = new SqlConnection(this._connectionString);

        await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();

        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Constants.Database.StoredProcedures.SkillWeaponType.GetBySkillIds;

        var parameter = new SqlParameter("SkillIds", SqlDbType.Structured) { TypeName = Constants.Database.UserDefinedTableTypes.GuidList };
        command.Parameters.Add(parameter).Value = AdoHelpers.BuildDataTable(skillIds);

        using var reader = await command.ExecuteReaderAsync(cancellationToken);

        var skillWeaponTypes = new List<SkillWeaponType>();

        while (await reader.ReadAsync(cancellationToken))
        {
            var skillWeaponType = BuildSkillWeaponTypes(reader);
            skillWeaponTypes.Add(skillWeaponType);
        }

        return skillWeaponTypes.ToLookup(x => x.SkillId);
    }

    private static SkillWeaponType BuildSkillWeaponTypes(SqlDataReader reader)
    {
        var skillWeaponType = new SkillWeaponType()
        {
            Id = reader.GetInt32(0),
            SkillId = reader.GetGuid(1),
            Color = (Colors)reader.GetInt32(2),
            Weapon = (Weapons)reader.GetInt32(3),
        };

        return skillWeaponType;
    }
}
