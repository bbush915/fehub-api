using System;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

using FEHub.Entity.Common.Helpers;
using FEHub.Tests.Integration.Utilities;

using GraphQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FEHub.Tests.Integration.Api.GraphQL;

[TestClass]
public sealed class ItemsTests : ResettingDatabaseTests
{
    private readonly TestServer _testServer;

    public ItemsTests()
    {
        this._testServer = TestHelpers.GetTestServer();
    }

    [TestMethod]
    public async Task Items_SingleItem_CanReturnAllFields()
    {
        // Arrange

        var item = FakeHelpers.Item().Generate();

        using var dbContext = Globals.CreateContext();

        await dbContext.Items.AddAsync(item);

        await dbContext.SaveChangesAsync();

        var httpClient = this._testServer.CreateClient();

        var query = @"
                query GetItems {
                    items {
                        id
                        createdAt
                        createdBy
                        modifiedAt
                        modifiedBy
                        version
                        name
                        description
                    }
                }
            ";

        // Act

        var httpResponse = await httpClient.PostAsJsonAsync("/graphql", new { Query = query });

        // Assert

        Assert.IsTrue(httpResponse.IsSuccessStatusCode);

        var executionResult = await httpResponse.Content.ReadFromJsonAsync<ExecutionResult>();
        var data = (JsonElement)executionResult.Data;

        var jsonItems = data.GetProperty("items");

        Assert.AreEqual(1, jsonItems.GetArrayLength());

        var jsonItem = jsonItems[0];

        Assert.AreEqual(item.Id, jsonItem.GetProperty("id").GetGuid());
        Assert.AreEqual(item.CreatedAt, jsonItem.GetProperty("createdAt").GetDateTime());
        Assert.AreEqual(item.CreatedBy, jsonItem.GetProperty("createdBy").GetString());
        Assert.AreEqual(item.ModifiedAt, jsonItem.GetProperty("modifiedAt").GetDateTime());
        Assert.AreEqual(item.ModifiedBy, jsonItem.GetProperty("modifiedBy").GetString());
        Assert.AreEqual(item.Version, jsonItem.GetProperty("version").GetInt32());
        Assert.AreEqual(item.Name, jsonItem.GetProperty("name").GetString());
        Assert.AreEqual(item.Description, jsonItem.GetProperty("description").GetString());
    }

    [TestMethod]
    public async Task Items_NoItem_ReturnsEmptyArray()
    {
        // Arrange

        var httpClient = this._testServer.CreateClient();

        var query = @"
                query GetItems {
                    items {
                        id
                        createdAt
                        createdBy
                        modifiedAt
                        modifiedBy
                        version
                        name
                        description
                    }
                }
            ";

        // Act

        var httpResponse = await httpClient.PostAsJsonAsync("/graphql", new { Query = query });

        // Assert

        Assert.IsTrue(httpResponse.IsSuccessStatusCode);

        var executionResult = await httpResponse.Content.ReadFromJsonAsync<ExecutionResult>();
        var data = (JsonElement)executionResult.Data;

        var jsonItems = data.GetProperty("items");

        Assert.AreEqual(0, jsonItems.GetArrayLength());
    }

    [TestMethod]
    public async Task Item_SingleItem_CanReturnAllFields()
    {
        // Arrange

        var item = FakeHelpers.Item().Generate();

        using var dbContext = Globals.CreateContext();

        await dbContext.Items.AddAsync(item);

        await dbContext.SaveChangesAsync();

        var httpClient = this._testServer.CreateClient();

        var query = @"
                query GetItem($id: Guid!) {
                    item(id: $id) {
                        id
                        createdAt
                        createdBy
                        modifiedAt
                        modifiedBy
                        version
                        name
                        description
                    }
                }
            ";

        // Act

        var httpResponse = await httpClient.PostAsJsonAsync("/graphql", new { Query = query, Variables = new { ID = item.Id } } );

        // Assert

        Assert.IsTrue(httpResponse.IsSuccessStatusCode);

        var executionResult = await httpResponse.Content.ReadFromJsonAsync<ExecutionResult>();
        var data = (JsonElement)executionResult.Data;

        var jsonItem = data.GetProperty("item");

        Assert.IsNotNull(jsonItem);

        Assert.AreEqual(item.Id, jsonItem.GetProperty("id").GetGuid());
        Assert.AreEqual(item.CreatedAt, jsonItem.GetProperty("createdAt").GetDateTime());
        Assert.AreEqual(item.CreatedBy, jsonItem.GetProperty("createdBy").GetString());
        Assert.AreEqual(item.ModifiedAt, jsonItem.GetProperty("modifiedAt").GetDateTime());
        Assert.AreEqual(item.ModifiedBy, jsonItem.GetProperty("modifiedBy").GetString());
        Assert.AreEqual(item.Version, jsonItem.GetProperty("version").GetInt32());
        Assert.AreEqual(item.Name, jsonItem.GetProperty("name").GetString());
        Assert.AreEqual(item.Description, jsonItem.GetProperty("description").GetString());
    }

    [TestMethod]
    public async Task Item_NoItem_ReturnsNull()
    {
        // Arrange

        var httpClient = this._testServer.CreateClient();

        var query = @"
                query GetItem($id: Guid!) {
                    item(id: $id) {
                        id
                        createdAt
                        createdBy
                        modifiedAt
                        modifiedBy
                        version
                        name
                        description
                    }
                }
            ";

        // Act

        var httpResponse = await httpClient.PostAsJsonAsync("/graphql", new { Query = query, Variables = new { ID = Guid.NewGuid() } });

        // Assert

        Assert.IsTrue(httpResponse.IsSuccessStatusCode);

        var executionResult = await httpResponse.Content.ReadFromJsonAsync<ExecutionResult>();
        var data = (JsonElement)executionResult.Data;

        var jsonItem = data.GetProperty("item");

        Assert.AreEqual(JsonValueKind.Null, jsonItem.ValueKind);
    }
}
