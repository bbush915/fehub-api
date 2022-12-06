using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Api.Options;
using FEHub.Api.Services.Interfaces;
using FEHub.Entity.Common;
using FEHub.Entity.Models;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace FEHub.Api.Services.Ado;

public sealed class ItemService : IItemService
{
    private readonly string _connectionString;

    public ItemService(IOptions<DatabaseOptions> databaseOptions)
    {
        this._connectionString = databaseOptions.Value.ConnectionString;
    }

    public async Task<List<Item>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        using var connection = new SqlConnection(this._connectionString);

        await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();

        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Constants.Database.StoredProcedures.Item.GetAll;

        using var reader = await command.ExecuteReaderAsync(cancellationToken);

        var items = new List<Item>();

        while (await reader.ReadAsync(cancellationToken))
        {
            var item = BuildItem(reader);
            items.Add(item);
        }

        return items;
    }

    public async Task<Item> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        using var connection = new SqlConnection(this._connectionString);

        await connection.OpenAsync(cancellationToken);

        using var command = connection.CreateCommand();

        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Constants.Database.StoredProcedures.Item.GetById;

        command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = id;

        using var reader = await command.ExecuteReaderAsync(cancellationToken);

        Item item = null;

        if (await reader.ReadAsync(cancellationToken))
        {
            item = BuildItem(reader);
        }

        return item;
    }

    private static Item BuildItem(SqlDataReader reader)
    {
        var item = new Item()
        {
            Id = reader.GetGuid(0),
            CreatedAt = reader.GetDateTime(1),
            CreatedBy = reader.GetString(2),
            ModifiedAt = reader.GetDateTime(3),
            ModifiedBy = reader.GetString(4),
            Version = reader.GetInt32(5),
            Name = reader.GetString(6),
            Description = reader.GetString(7)
        };

        return item;
    }
}
