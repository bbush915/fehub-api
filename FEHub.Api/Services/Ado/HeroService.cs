//-----------------------------------------------------------------------------
// <copyright file="HeroService.cs">
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
    public sealed class HeroService : IHeroService
    {
        private readonly string _connectionString;

        public HeroService(IOptions<DatabaseOptions> databaseOptions)
        {
            this._connectionString = databaseOptions.Value.ConnectionString;
        }

        public async Task<List<Hero>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(this._connectionString);

            await connection.OpenAsync(cancellationToken);

            using var command = connection.CreateCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constants.Database.StoredProcedures.Hero.GetAll;

            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            var heroes = new List<Hero>();

            while (await reader.ReadAsync(cancellationToken))
            {
                var hero = BuildHero(reader);
                heroes.Add(hero);
            }

            return heroes;
        }

        public async Task<Hero> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(this._connectionString);

            await connection.OpenAsync(cancellationToken);

            using var command = connection.CreateCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constants.Database.StoredProcedures.Hero.GetById;

            command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = id;

            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            Hero hero = null;

            if (await reader.ReadAsync(cancellationToken))
            {
                hero = BuildHero(reader);
            }

            return hero;
        }

        private static Hero BuildHero(SqlDataReader reader)
        {
            var hero = new Hero()
            {
                Id = reader.GetGuid(0),
                CreatedAt = reader.GetDateTime(1),
                CreatedBy = reader.GetString(2),
                ModifiedAt = reader.GetDateTime(3),
                ModifiedBy = reader.GetString(4),
                Version = reader.GetInt32(5),
                Name = reader.GetString(6),
                Title = reader.GetString(7),
                Description = reader.GetString(8),
                Origin = reader.GetString(9),
                Gender = (Genders)reader.GetInt32(10),
                AdditionDate = reader.GetDateTime(11),
                ReleaseDate = reader.GetDateTime(12),
                ArtistId = reader.GetInt32(13),
                IsLegendaryHero = reader.GetBoolean(14),
                IsMythicHero = reader.GetBoolean(15),
                Element = reader.IsDBNull(16) ? null : (Elements)reader.GetInt32(16),
                LegendaryHeroBoostType = reader.IsDBNull(17) ? null : (LegendaryHeroBoostTypes)reader.GetInt32(17),
                MythicHeroBoostType = reader.IsDBNull(18) ? null : (MythicHeroBoostTypes)reader.GetInt32(18),
                IsDuoHero = reader.GetBoolean(19),
                IsResplendentHero = reader.GetBoolean(20),
                Color = (Colors)reader.GetInt32(21),
                Weapon = (Weapons)reader.GetInt32(22),
                MovementType = (MovementTypes)reader.GetInt32(23),
                BVID = reader.GetInt32(24),
                BaseHitPoints = reader.GetInt32(25),
                HitPointsGrowthRate = reader.GetInt32(26),
                BaseAttack = reader.GetInt32(27),
                AttackGrowthRate = reader.GetInt32(28),
                BaseSpeed = reader.GetInt32(29),
                SpeedGrowthRate = reader.GetInt32(30),
                BaseDefense = reader.GetInt32(31),
                DefenseGrowthRate = reader.GetInt32(32),
                BaseResistance = reader.GetInt32(33),
                ResistanceGrowthRate = reader.GetInt32(34),
                Tag = reader.GetString(35)
            };

            return hero;
        }
    }
}
