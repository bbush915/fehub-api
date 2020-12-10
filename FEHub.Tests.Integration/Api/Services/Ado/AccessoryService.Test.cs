//-----------------------------------------------------------------------------
// <copyright file="AccessoryService.Test.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Threading.Tasks;

using FEHub.Api.Options;
using FEHub.Api.Services.Ado;
using FEHub.Entity.Common.Helpers;

using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FEHub.Tests.Integration.Api.Services.Ado
{
    [TestClass]
    public sealed class AccessoryServiceTests
    {
        private readonly AccessoryService _accessoryService;

        public AccessoryServiceTests()
        {
            var databaseOptions = Options.Create(
                new DatabaseOptions() { ConnectionString = Global.ConnectionString }
            );

            this._accessoryService = new AccessoryService(databaseOptions);
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

            var accessory = FakeHelpers.Accessory().Generate();

            using var dbContext = Global.GetDbContext();

            await dbContext.Accessories.AddAsync(accessory);

            await dbContext.SaveChangesAsync();

            // Act

            var results = await this._accessoryService.GetAllAsync();

            // Assert

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(accessory.Id, results[0].Id);
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

            // Act

            var results = await this._accessoryService.GetAllAsync();

            // Assert

            Assert.AreEqual(accessoryCount, results.Count);
        }

        [TestMethod]
        public async Task GetByIdAsync_DoesNotExist_ReturnsNotFoundResponse()
        {
            // Arrange

            var accessoryId = Guid.NewGuid();

            // Act

            var result = await this._accessoryService.GetByIdAsync(accessoryId);

            // Assert

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task GetByIdAsync_DoesExist_ReturnsSameAccessory()
        {
            // Arrange

            var accessory = FakeHelpers.Accessory().Generate();

            using var dbContext = Global.GetDbContext();

            await dbContext.Accessories.AddAsync(accessory);

            await dbContext.SaveChangesAsync();

            // Act

            var result = await this._accessoryService.GetByIdAsync(accessory.Id);

            // Assert

            Assert.AreEqual(accessory.Id, result.Id);
        }
    }
}
