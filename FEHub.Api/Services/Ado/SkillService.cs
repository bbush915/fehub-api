//-----------------------------------------------------------------------------
// <copyright file="SkillService.cs">
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
using FEHub.Api.Utilities;
using FEHub.Entity.Common;
using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Models;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace FEHub.Api.Services.Ado
{
    public sealed class SkillService : ISkillService
    {
        private readonly string _connectionString;

        public SkillService(IOptions<DatabaseOptions> databaseOptions)
        {
            this._connectionString = databaseOptions.Value.ConnectionString;
        }

        public async Task<List<Skill>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(this._connectionString);

            await connection.OpenAsync(cancellationToken);

            using var command = connection.CreateCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constants.Database.StoredProcedures.Skill.GetAll;

            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            var skills = new List<Skill>();

            while (await reader.ReadAsync(cancellationToken))
            {
                var skill = BuildSkill(reader);
                skills.Add(skill);
            }

            return skills;
        }

        public async Task<IDictionary<Guid, Skill>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(this._connectionString);

            await connection.OpenAsync(cancellationToken);

            using var command = connection.CreateCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constants.Database.StoredProcedures.Skill.GetByIds;

            var parameter = new SqlParameter("Ids", SqlDbType.Structured) { TypeName = Constants.Database.UserDefinedTableTypes.GuidList };
            command.Parameters.Add(parameter).Value = AdoHelpers.BuildDataTable(ids);

            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            var skills = new Dictionary<Guid, Skill>();

            while (await reader.ReadAsync(cancellationToken))
            {
                var skill = BuildSkill(reader);
                skills.Add(skill.Id, skill);
            }

            return skills;
        }

        public async Task<Skill> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(this._connectionString);

            await connection.OpenAsync(cancellationToken);

            using var command = connection.CreateCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constants.Database.StoredProcedures.Skill.GetById;

            command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = id;

            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            Skill skill = null;

            if (await reader.ReadAsync(cancellationToken))
            {
                skill = BuildSkill(reader);
            }

            return skill;
        }

        private static Skill BuildSkill(SqlDataReader reader)
        {
            var skill = new Skill()
            {
                Id = reader.GetGuid(0),
                CreatedAt = reader.GetDateTime(1),
                CreatedBy = reader.GetString(2),
                ModifiedAt = reader.GetDateTime(3),
                ModifiedBy = reader.GetString(4),
                Version = reader.GetInt32(5),
                Name = reader.GetString(6),
                GroupName = reader.GetString(7),
                Description = reader.GetString(8),
                IsExclusive = reader.GetBoolean(9),
                IsAvailableAsSacredSeal = reader.GetBoolean(10),
                SkillPoints = reader.GetInt32(11),
                SkillType = (SkillTypes)reader.GetInt32(12),
                WeaponRefineType = reader.IsDBNull(13) ? null : (WeaponRefineTypes)reader.GetInt32(13),
                Might = reader.IsDBNull(14) ? null : reader.GetInt32(14),
                Range = reader.IsDBNull(15) ? null : reader.GetInt32(15),
                Cooldown = reader.IsDBNull(16) ? null : reader.GetInt32(16),
                HitPointsModifier = reader.IsDBNull(17) ? null : reader.GetInt32(17),
                AttackModifier = reader.IsDBNull(18) ? null : reader.GetInt32(18),
                SpeedModifier = reader.IsDBNull(19) ? null : reader.GetInt32(19),
                DefenseModifier = reader.IsDBNull(20) ? null : reader.GetInt32(20),
                ResistanceModifier = reader.IsDBNull(21) ? null : reader.GetInt32(21),
                Tag = reader.GetString(22)
            };

            return skill;
        }
    }
}
