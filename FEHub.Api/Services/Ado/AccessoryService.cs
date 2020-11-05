//-----------------------------------------------------------------------------
// <copyright file="AccessoryService.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Api.Options;
using FEHub.Api.Services.Interfaces;
using FEHub.Entity.Common;
using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Models;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace FEHub.Api.Services.Ado
{
    public sealed class AccessoryService : IAccessoryService
    {
        private readonly string _connectionString;

        public AccessoryService(IOptions<DatabaseOptions> databaseOptions)
        {
            this._connectionString = databaseOptions.Value.ConnectionString;
        }

        public async Task<List<Accessory>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(this._connectionString);

            await connection.OpenAsync(cancellationToken);

            using var command = connection.CreateCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constants.Database.StoredProcedures.Accessory.GetAll;

            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            var accessories = new List<Accessory>();

            while (await reader.ReadAsync(cancellationToken))
            {
                var accessory = BuildAccessory(reader);
                accessories.Add(accessory);
            }

            return accessories;
        }

        public async Task<Accessory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(this._connectionString);

            await connection.OpenAsync(cancellationToken);

            using var command = connection.CreateCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constants.Database.StoredProcedures.Accessory.GetById;

            command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = id;

            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            Accessory accessory = null;

            if (await reader.ReadAsync(cancellationToken))
            {
                accessory = BuildAccessory(reader);
            }

            return accessory;
        }

        private static Accessory BuildAccessory(SqlDataReader reader)
        {
            var accessory = new Accessory()
            {
                Id = reader.GetGuid(0),
                CreatedAt = reader.GetDateTime(1),
                CreatedBy = reader.GetString(2),
                ModifiedAt = reader.GetDateTime(3),
                ModifiedBy = reader.GetString(4),
                Version = reader.GetInt32(5),
                Name = reader.GetString(6),
                Description = reader.GetString(7),
                AccessoryType = (AccessoryTypes)reader.GetInt32(8),
                Tag = reader.GetString(9)
            };

            return accessory;
        }
    }
}
