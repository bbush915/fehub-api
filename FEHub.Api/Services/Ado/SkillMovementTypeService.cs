//-----------------------------------------------------------------------------
// <copyright file="SkillMovementTypeService.cs">
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
    public sealed class SkillMovementTypeService : ISkillMovementTypeService
    {
        private readonly string _connectionString;

        public SkillMovementTypeService(IOptions<DatabaseOptions> databaseOptions)
        {
            this._connectionString = databaseOptions.Value.ConnectionString;
        }

        public async Task<ILookup<Guid, SkillMovementType>> GetBySkillIdsAsync(IEnumerable<Guid> skillIds, CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(this._connectionString);

            await connection.OpenAsync(cancellationToken);

            using var command = connection.CreateCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Constants.Database.StoredProcedures.SkillMovementType.GetBySkillIds;

            var parameter = new SqlParameter("SkillIds", SqlDbType.Structured) { TypeName = Constants.Database.UserDefinedTableTypes.GuidList };
            command.Parameters.Add(parameter).Value = AdoHelpers.BuildDataTable(skillIds);

            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            var skillMovementTypes = new List<SkillMovementType>();

            while (await reader.ReadAsync(cancellationToken))
            {
                var skillMovementType = BuildSkillMovementTypes(reader);
                skillMovementTypes.Add(skillMovementType);
            }

            return skillMovementTypes.ToLookup(x => x.SkillId);
        }

        private static SkillMovementType BuildSkillMovementTypes(SqlDataReader reader)
        {
            var skillMovementType = new SkillMovementType()
            {
                Id = reader.GetInt32(0),
                SkillId = reader.GetGuid(1),
                MovementType = (MovementTypes)reader.GetInt32(2),
            };

            return skillMovementType;
        }
    }
}
