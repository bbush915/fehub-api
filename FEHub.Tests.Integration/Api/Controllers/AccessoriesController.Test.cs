//-----------------------------------------------------------------------------
// <copyright file="AccessoriesController.Test.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

using FEHub.Entity.Common.Helpers;
using FEHub.Entity.Models;
using FEHub.Tests.Integration.Utilities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FEHub.Tests.Integration.Api.Controllers
{
    [TestClass]
    public sealed class AccessoriesControllerTests
    {
        private readonly TestServer _testServer;

        public AccessoriesControllerTests()
        {
            this._testServer = TestHelpers.GetTestServer();
        }

        [TestCleanup]
        public async Task AfterEachAsync()
        {
            await Global.ResetDatabaseAsync();
        }

        [TestMethod]
        public async Task GetAllAsync_SingleAccessory_ReturnsSameAccessory()
        {
            // Arrange

            var accessories = FakeHelpers.Accessory().Generate(1);

            using var dbContext = Global.GetDbContext();

            await dbContext.Accessories.AddRangeAsync(accessories);

            await dbContext.SaveChangesAsync();

            var httpClient = this._testServer.CreateClient();

            // Act

            var httpResponse = await httpClient.GetAsync("/api/accessories");

            // Assert

            Assert.IsTrue(httpResponse.IsSuccessStatusCode);

            var jsonAccessories = await httpResponse.Content.ReadFromJsonAsync<Accessory[]>();

            Assert.AreEqual(1, jsonAccessories.Length);
            Assert.AreEqual(accessories[0].Id, jsonAccessories[0].Id);
        }

        [TestMethod]
        [DataRow(10)]
        public async Task GetAllAsync_MultipleAccessories_ReturnsSameNumberOfAccessories(int accessoryCount)
        {
            // Arrange

            var accessories = FakeHelpers.Accessory().Generate(accessoryCount);

            using var dbContext = Global.GetDbContext();

            await dbContext.Accessories.AddRangeAsync(accessories);

            await dbContext.SaveChangesAsync();

            var httpClient = this._testServer.CreateClient();

            // Act

            var httpResponse = await httpClient.GetAsync("/api/accessories");

            // Assert

            Assert.IsTrue(httpResponse.IsSuccessStatusCode);

            var jsonAccessories = await httpResponse.Content.ReadFromJsonAsync<Accessory[]>();

            Assert.AreEqual(accessoryCount, jsonAccessories.Length);
        }

        [TestMethod]
        public async Task GetByIdAsync_DoesNotExist_ReturnsNotFoundResponse()
        {
            // Arrange

            var accessoryId = Guid.NewGuid();

            var httpClient = this._testServer.CreateClient();

            // Act

            var httpResponse = await httpClient.GetAsync($"/api/accessories/{accessoryId}");

            // Assert

            Assert.AreEqual(httpResponse.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task GetByIdAsync_DoesExist_ReturnsSameAccessory()
        {
            // Arrange

            var accessory = FakeHelpers.Accessory().Generate();

            using var dbContext = Global.GetDbContext();

            await dbContext.Accessories.AddAsync(accessory);

            await dbContext.SaveChangesAsync();

            var httpClient = this._testServer.CreateClient();

            // Act

            var httpResponse = await httpClient.GetAsync($"/api/accessories/{accessory.Id}");

            // Assert

            Assert.IsTrue(httpResponse.IsSuccessStatusCode);

            var jsonAccessory = await httpResponse.Content.ReadFromJsonAsync<Accessory>();

            Assert.AreEqual(accessory.Id, jsonAccessory.Id);
        }
    }
}
