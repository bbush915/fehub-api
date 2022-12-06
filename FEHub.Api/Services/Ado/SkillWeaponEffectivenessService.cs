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

public sealed class SkillWeaponEffectivenessService : ISkillWeaponEffectivenessService
{
    private readonly string _connectionString;

    public SkillWeaponEffectivenessService(IOptions<DatabaseOptions> databaseOptions)
    {
        this._connectionString = databaseOptions.Value.ConnectionString;
    }

    public async Task<ILookup<Guid, SkillWeaponEffectiveness>> GetBySkillIdsAsync(IEnumerable<Guid> skillIds, CancellationToken cancellationToken = default)
    {
        using var connection = new SqlConnection(this._connectionString);

        await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();

        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Constants.Database.StoredProcedures.SkillWeaponEffectiveness.GetBySkillIds;

        var parameter = new SqlParameter("SkillIds", SqlDbType.Structured) { TypeName = Constants.Database.UserDefinedTableTypes.GuidList };
        command.Parameters.Add(parameter).Value = AdoHelpers.BuildDataTable(skillIds);

        using var reader = await command.ExecuteReaderAsync(cancellationToken);

        var skillWeaponEffectivenesss = new List<SkillWeaponEffectiveness>();

        while (await reader.ReadAsync(cancellationToken))
        {
            var skillWeaponEffectiveness = BuildSkillWeaponEffectivenesss(reader);
            skillWeaponEffectivenesss.Add(skillWeaponEffectiveness);
        }

        return skillWeaponEffectivenesss.ToLookup(x => x.SkillId);
    }

    private static SkillWeaponEffectiveness BuildSkillWeaponEffectivenesss(SqlDataReader reader)
    {
        var skillWeaponEffectiveness = new SkillWeaponEffectiveness()
        {
            Id = reader.GetInt32(0),
            SkillId = reader.GetGuid(1),
            WeaponEffectivenessType = (WeaponEffectivenessTypes)reader.GetInt32(2),
            DamageType = reader.IsDBNull(3) ? null : (DamageTypes)reader.GetInt32(3),
            MovementType = reader.IsDBNull(4) ? null : (MovementTypes)reader.GetInt32(4),
            Weapon = reader.IsDBNull(5) ? null : (Weapons)reader.GetInt32(5) 
        };

        return skillWeaponEffectiveness;
    }
}
