using System.Collections.Generic;
using System.Data;
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

public sealed class VoiceActorService : IVoiceActorService
{
    private readonly string _connectionString;

    public VoiceActorService(IOptions<DatabaseOptions> databaseOptions)
    {
        this._connectionString = databaseOptions.Value.ConnectionString;
    }

    public async Task<List<VoiceActor>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        using var connection = new SqlConnection(this._connectionString);

        await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();

        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Constants.Database.StoredProcedures.VoiceActor.GetAll;

        using var reader = await command.ExecuteReaderAsync(cancellationToken);

        var voiceActors = new List<VoiceActor>();

        while (await reader.ReadAsync(cancellationToken))
        {
            var voiceActor = BuildVoiceActor(reader);
            voiceActors.Add(voiceActor);
        }

        return voiceActors;
    }

    public async Task<IDictionary<int, VoiceActor>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default)
    {
        using var connection = new SqlConnection(this._connectionString);

        await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();

        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Constants.Database.StoredProcedures.VoiceActor.GetByIds;

        var parameter = new SqlParameter("Ids", SqlDbType.Structured) { TypeName = Constants.Database.UserDefinedTableTypes.IntList };
        command.Parameters.Add(parameter).Value = AdoHelpers.BuildDataTable(ids);

        using var reader = await command.ExecuteReaderAsync(cancellationToken);

        var voiceActors = new Dictionary<int, VoiceActor>();

        while (await reader.ReadAsync(cancellationToken))
        {
            var voiceActor = BuildVoiceActor(reader);
            voiceActors.Add(voiceActor.Id, voiceActor);
        }

        return voiceActors;
    }

    public async Task<VoiceActor> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        using var connection = new SqlConnection(this._connectionString);

        await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();

        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Constants.Database.StoredProcedures.VoiceActor.GetById;

        command.Parameters.Add("Id", SqlDbType.Int).Value = id;

        using var reader = await command.ExecuteReaderAsync(cancellationToken);

        VoiceActor voiceActor = null;

        if (await reader.ReadAsync(cancellationToken))
        {
            voiceActor = BuildVoiceActor(reader);
        }

        return voiceActor;
    }

    private static VoiceActor BuildVoiceActor(SqlDataReader reader)
    {
        var voiceActor = new VoiceActor()
        {
            Id = reader.GetInt32(0),
            CreatedAt = reader.GetDateTime(1),
            CreatedBy = reader.GetString(2),
            ModifiedAt = reader.GetDateTime(3),
            ModifiedBy = reader.GetString(4),
            Version = reader.GetInt32(5),
            Name = reader.GetString(6),
            NameKanji = reader.IsDBNull(7) ? null : reader.GetString(7)
        };

        return voiceActor;
    }
}
