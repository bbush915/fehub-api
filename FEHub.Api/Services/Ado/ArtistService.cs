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

public sealed class ArtistService : IArtistService
{
    private readonly string _connectionString;

    public ArtistService(IOptions<DatabaseOptions> databaseOptions)
    {
        this._connectionString = databaseOptions.Value.ConnectionString;
    }

    public async Task<List<Artist>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        using var connection = new SqlConnection(this._connectionString);

        await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();

        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Constants.Database.StoredProcedures.Artist.GetAll;

        using var reader = await command.ExecuteReaderAsync(cancellationToken);

        var artists = new List<Artist>();

        while (await reader.ReadAsync(cancellationToken))
        {
            var artist = BuildArtist(reader);
            artists.Add(artist);
        }

        return artists;
    }

    public async Task<IDictionary<int, Artist>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default)
    {
        using var connection = new SqlConnection(this._connectionString);

        await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();

        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Constants.Database.StoredProcedures.Artist.GetByIds;

        var parameter = new SqlParameter("Ids", SqlDbType.Structured) { TypeName = Constants.Database.UserDefinedTableTypes.IntList };
        command.Parameters.Add(parameter).Value = AdoHelpers.BuildDataTable(ids);

        using var reader = await command.ExecuteReaderAsync(cancellationToken);

        var artists = new Dictionary<int, Artist>();

        while (await reader.ReadAsync(cancellationToken))
        {
            var artist = BuildArtist(reader);
            artists.Add(artist.Id, artist);
        }

        return artists;
    }

    public async Task<Artist> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        using var connection = new SqlConnection(this._connectionString);

        await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();

        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Constants.Database.StoredProcedures.Artist.GetById;

        command.Parameters.Add("Id", SqlDbType.Int).Value = id;

        using var reader = await command.ExecuteReaderAsync(cancellationToken);

        Artist artist = null;

        if (await reader.ReadAsync(cancellationToken))
        {
            artist = BuildArtist(reader);
        }

        return artist;
    }

    private static Artist BuildArtist(SqlDataReader reader)
    {
        var artist = new Artist()
        {
            Id = reader.GetInt32(0),
            CreatedAt = reader.GetDateTime(1),
            CreatedBy = reader.GetString(2),
            ModifiedAt = reader.GetDateTime(3),
            ModifiedBy = reader.GetString(4),
            Version = reader.GetInt32(5),
            Name = reader.GetString(6),
            NameKanji = reader.IsDBNull(7) ? null : reader.GetString(7),
            Company = reader.IsDBNull(8) ? null : reader.GetString(8)
        };

        return artist;
    }
}
