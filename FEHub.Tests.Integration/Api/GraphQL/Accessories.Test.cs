//-----------------------------------------------------------------------------
// <copyright file="Accessories.Test.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Common.Helpers;
using FEHub.Tests.Integration.Utilities;

using GraphQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FEHub.Tests.Integration.Api.GraphQL
{
    [TestClass]
    public sealed class AccessoriesTests
    {
        private readonly TestServer _testServer;

        public AccessoriesTests()
        {
            this._testServer = TestHelpers.GetTestServer();
        }

        [TestCleanup]
        public async Task AfterEachAsync()
        {
            await Global.ResetDatabaseAsync();
        }

        [TestMethod]
        public async Task Accessories_SingleAccessory_CanReturnAllFields()
        {
            // Arrange

            var accessory = FakeHelpers.Accessory().Generate();

            using var dbContext = Global.GetDbContext();

            await dbContext.Accessories.AddAsync(accessory);

            await dbContext.SaveChangesAsync();

            var httpClient = this._testServer.CreateClient();

            var query = @"
                query GetAccessories {
                    accessories {
                        id
                        createdAt
                        createdBy
                        modifiedAt
                        modifiedBy
                        version
                        name
                        description
                        accessoryType
                        tag
                    }
                }
            ";

            // Act

            var httpResponse = await httpClient.PostAsJsonAsync("/graphql", new { Query = query });

            // Assert

            Assert.IsTrue(httpResponse.IsSuccessStatusCode);

            var executionResult = await httpResponse.Content.ReadFromJsonAsync<ExecutionResult>();
            var data = (JsonElement)executionResult.Data;

            var jsonAccessories = data.GetProperty("accessories");

            Assert.AreEqual(1, jsonAccessories.GetArrayLength());

            var jsonAccessory = jsonAccessories[0];

            Assert.AreEqual(accessory.Id, jsonAccessory.GetProperty("id").GetGuid());
            Assert.AreEqual(accessory.CreatedAt, jsonAccessory.GetProperty("createdAt").GetDateTime());
            Assert.AreEqual(accessory.CreatedBy, jsonAccessory.GetProperty("createdBy").GetString());
            Assert.AreEqual(accessory.ModifiedAt, jsonAccessory.GetProperty("modifiedAt").GetDateTime());
            Assert.AreEqual(accessory.ModifiedBy, jsonAccessory.GetProperty("modifiedBy").GetString());
            Assert.AreEqual(accessory.Version, jsonAccessory.GetProperty("version").GetInt32());
            Assert.AreEqual(accessory.Name, jsonAccessory.GetProperty("name").GetString());
            Assert.AreEqual(accessory.Description, jsonAccessory.GetProperty("description").GetString());
            Assert.AreEqual(accessory.AccessoryType, (AccessoryTypes)jsonAccessory.GetProperty("accessoryType").GetInt32());
            Assert.AreEqual(accessory.Tag, jsonAccessory.GetProperty("tag").GetString());
        }
    }
}
