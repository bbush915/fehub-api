using System;
using System.Threading.Tasks;

using FEHub.Api.Services;
using FEHub.Entity.Common.Helpers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FEHub.Tests.Integration.Api.Services;

[TestClass]
public sealed class AccessoryServiceTests : ResettingDatabaseTests
{
    private readonly AccessoryService _accessoryService;

    public AccessoryServiceTests()
    {
        var dbContext = Globals.CreateContext();

        this._accessoryService = new AccessoryService(dbContext);
    }

    [TestMethod]
    public async Task GetAllAsync_SingleAccessory_ReturnsSameAccessory()
    {
        // Arrange

        var accessory = FakeHelpers.Accessory().Generate();

        using var dbContext = Globals.CreateContext();

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

        using var dbContext = Globals.CreateContext();

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

        using var dbContext = Globals.CreateContext();

        await dbContext.Accessories.AddAsync(accessory);

        await dbContext.SaveChangesAsync();

        // Act

        var result = await this._accessoryService.GetByIdAsync(accessory.Id);

        // Assert

        Assert.AreEqual(accessory.Id, result.Id);
    }
}
