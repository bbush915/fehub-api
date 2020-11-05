//-----------------------------------------------------------------------------
// <copyright file="HeroVoiceActorService.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

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

namespace FEHub.Api.Services.Ado
{
    public sealed class HeroVoiceActorService : IHeroVoiceActorService
    {
        private readonly string _connectionString;

        public HeroVoiceActorService(IOptions<DatabaseOptions> databaseOptions)
        {
            this._connectionString = databaseOptions.Value.ConnectionString;
        }

        public async Task<ILookup<Guid, HeroVoiceActor>> GetByHeroIdsAsync(IEnumerable<Guid> heroIds, Languages language, CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(this._connectionString);

            await connection.OpenAsync(cancellationToken);

            using var command = connection.CreateCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constants.Database.StoredProcedures.HeroVoiceActor.GetByHeroIds;

            var parameter = new SqlParameter("HeroIds", SqlDbType.Structured) { TypeName = Constants.Database.UserDefinedTableTypes.GuidList };
            command.Parameters.Add(parameter).Value = AdoHelpers.BuildDataTable(heroIds);

            command.Parameters.Add("Language", SqlDbType.Int).Value = language;

            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            var heroVoiceActors = new List<HeroVoiceActor>();

            while (await reader.ReadAsync(cancellationToken))
            {
                var heroVoiceActor = BuildHeroVoiceActor(reader);
                heroVoiceActors.Add(heroVoiceActor);
            }

            return heroVoiceActors.ToLookup(x => x.HeroId);
        }

        private static HeroVoiceActor BuildHeroVoiceActor(SqlDataReader reader)
        {
            var heroVoiceActor = new HeroVoiceActor()
            {
                Id = reader.GetInt32(0),
                HeroId = reader.GetGuid(1),
                VoiceActorId = reader.GetInt32(2),
                Language = (Languages)reader.GetInt32(3),
                Sort = reader.GetInt32(4)
            };

            return heroVoiceActor;
        }
    }
}
