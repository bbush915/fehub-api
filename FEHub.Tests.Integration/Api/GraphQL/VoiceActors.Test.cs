//-----------------------------------------------------------------------------
// <copyright file="VoiceActors.Test.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

using FEHub.Entity.Common.Helpers;
using FEHub.Tests.Integration.Utilities;

using GraphQL;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FEHub.Tests.Integration.Api.GraphQL
{
    [TestClass]
    public sealed class VoiceActorsTests
    {
        private readonly TestServer _testServer;

        public VoiceActorsTests()
        {
            this._testServer = TestHelpers.GetTestServer();
        }

        [TestCleanup]
        public async Task AfterEachAsync()
        {
            await Global.ResetDatabaseAsync();
        }

        [TestMethod]
        public async Task VoiceActors_SingleVoiceActor_CanReturnAllFields()
        {
            // Arrange

            var voiceActor = FakeHelpers.VoiceActor().Generate();

            using var dbContext = Global.GetDbContext();

            await dbContext.VoiceActors.AddAsync(voiceActor);
    
            await dbContext.Database.OpenConnectionAsync();
            await dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[VoiceActors] ON");

            await dbContext.SaveChangesAsync();

            var httpClient = this._testServer.CreateClient();

            var query = @"
                query GetVoiceActors {
                    voiceActors {
                        id
                        createdAt
                        createdBy
                        modifiedAt
                        modifiedBy
                        version
                        name
                        nameKanji
                    }
                }
            ";

            // Act

            var httpResponse = await httpClient.PostAsJsonAsync("/graphql", new { Query = query });

            // Assert

            Assert.IsTrue(httpResponse.IsSuccessStatusCode);

            var executionResult = await httpResponse.Content.ReadFromJsonAsync<ExecutionResult>();
            var data = (JsonElement)executionResult.Data;

            var jsonVoiceActors = data.GetProperty("voiceActors");

            Assert.AreEqual(1, jsonVoiceActors.GetArrayLength());

            var jsonVoiceActor = jsonVoiceActors[0];

            Assert.AreEqual(voiceActor.Id, jsonVoiceActor.GetProperty("id").GetInt32());
            Assert.AreEqual(voiceActor.CreatedAt, jsonVoiceActor.GetProperty("createdAt").GetDateTime());
            Assert.AreEqual(voiceActor.CreatedBy, jsonVoiceActor.GetProperty("createdBy").GetString());
            Assert.AreEqual(voiceActor.ModifiedAt, jsonVoiceActor.GetProperty("modifiedAt").GetDateTime());
            Assert.AreEqual(voiceActor.ModifiedBy, jsonVoiceActor.GetProperty("modifiedBy").GetString());
            Assert.AreEqual(voiceActor.Version, jsonVoiceActor.GetProperty("version").GetInt32());
            Assert.AreEqual(voiceActor.Name, jsonVoiceActor.GetProperty("name").GetString());
            Assert.AreEqual(voiceActor.NameKanji, jsonVoiceActor.GetProperty("nameKanji").GetString());
        }

        [TestMethod]
        public async Task VoiceActors_NoVoiceActor_ReturnsEmptyArray()
        {
            // Arrange

            var httpClient = this._testServer.CreateClient();

            var query = @"
                query GetVoiceActors {
                    voiceActors {
                        id
                        createdAt
                        createdBy
                        modifiedAt
                        modifiedBy
                        version
                        name
                        nameKanji
                    }
                }
            ";

            // Act

            var httpResponse = await httpClient.PostAsJsonAsync("/graphql", new { Query = query });

            // Assert

            Assert.IsTrue(httpResponse.IsSuccessStatusCode);

            var executionResult = await httpResponse.Content.ReadFromJsonAsync<ExecutionResult>();
            var data = (JsonElement)executionResult.Data;

            var jsonVoiceActors = data.GetProperty("voiceActors");

            Assert.AreEqual(0, jsonVoiceActors.GetArrayLength());
        }

        [TestMethod]
        public async Task VoiceActor_SingleVoiceActor_CanReturnAllFields()
        {
            // Arrange

            var voiceActor = FakeHelpers.VoiceActor().Generate();

            using var dbContext = Global.GetDbContext();

            await dbContext.VoiceActors.AddAsync(voiceActor);

            await dbContext.Database.OpenConnectionAsync();
            await dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[VoiceActors] ON");

            await dbContext.SaveChangesAsync();

            var httpClient = this._testServer.CreateClient();

            var query = @"
                query GetVoiceActor($id: Int!) {
                    voiceActor(id: $id) {
                        id
                        createdAt
                        createdBy
                        modifiedAt
                        modifiedBy
                        version
                        name
                        nameKanji
                    }
                }
            ";

            // Act

            var httpResponse = await httpClient.PostAsJsonAsync("/graphql", new { Query = query, Variables = new { ID = voiceActor.Id } } );

            // Assert

            Assert.IsTrue(httpResponse.IsSuccessStatusCode);

            var executionResult = await httpResponse.Content.ReadFromJsonAsync<ExecutionResult>();
            var data = (JsonElement)executionResult.Data;

            var jsonVoiceActor = data.GetProperty("voiceActor");

            Assert.IsNotNull(jsonVoiceActor);

            Assert.AreEqual(voiceActor.Id, jsonVoiceActor.GetProperty("id").GetInt32());
            Assert.AreEqual(voiceActor.CreatedAt, jsonVoiceActor.GetProperty("createdAt").GetDateTime());
            Assert.AreEqual(voiceActor.CreatedBy, jsonVoiceActor.GetProperty("createdBy").GetString());
            Assert.AreEqual(voiceActor.ModifiedAt, jsonVoiceActor.GetProperty("modifiedAt").GetDateTime());
            Assert.AreEqual(voiceActor.ModifiedBy, jsonVoiceActor.GetProperty("modifiedBy").GetString());
            Assert.AreEqual(voiceActor.Version, jsonVoiceActor.GetProperty("version").GetInt32());
            Assert.AreEqual(voiceActor.Name, jsonVoiceActor.GetProperty("name").GetString());
            Assert.AreEqual(voiceActor.NameKanji, jsonVoiceActor.GetProperty("nameKanji").GetString());
        }

        [TestMethod]
        public async Task VoiceActor_NoVoiceActor_ReturnsNull()
        {
            // Arrange

            var httpClient = this._testServer.CreateClient();

            var query = @"
                query GetVoiceActor($id: Int!) {
                    voiceActor(id: $id) {
                        id
                        createdAt
                        createdBy
                        modifiedAt
                        modifiedBy
                        version
                        name
                        nameKanji
                    }
                }
            ";

            // Act

            var httpResponse = await httpClient.PostAsJsonAsync("/graphql", new { Query = query, Variables = new { ID = 1 } });

            // Assert

            Assert.IsTrue(httpResponse.IsSuccessStatusCode);

            var executionResult = await httpResponse.Content.ReadFromJsonAsync<ExecutionResult>();
            var data = (JsonElement)executionResult.Data;

            var jsonVoiceActor = data.GetProperty("voiceActor");

            Assert.AreEqual(JsonValueKind.Null, jsonVoiceActor.ValueKind);
        }
    }
}
