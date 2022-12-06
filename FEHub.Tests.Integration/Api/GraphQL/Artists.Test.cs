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

namespace FEHub.Tests.Integration.Api.GraphQL;

[TestClass]
public sealed class ArtistsTests : ResettingDatabaseTests
{
    private readonly TestServer _testServer;

    public ArtistsTests()
    {
        this._testServer = TestHelpers.GetTestServer();
    }

    [TestMethod]
    public async Task Artists_SingleArtist_CanReturnAllFields()
    {
        // Arrange

        var artist = FakeHelpers.Artist().Generate();

        using var dbContext = Globals.CreateContext();

        await dbContext.Artists.AddAsync(artist);

        await dbContext.Database.OpenConnectionAsync();
        await dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Artists] ON");

        await dbContext.SaveChangesAsync();

        var httpClient = this._testServer.CreateClient();

        var query = @"
                query GetArtists {
                    artists {
                        id
                        createdAt
                        createdBy
                        modifiedAt
                        modifiedBy
                        version
                        name
                        nameKanji
                        company
                    }
                }
            ";

        // Act

        var httpResponse = await httpClient.PostAsJsonAsync("/graphql", new { Query = query });

        // Assert

        Assert.IsTrue(httpResponse.IsSuccessStatusCode);

        var executionResult = await httpResponse.Content.ReadFromJsonAsync<ExecutionResult>();
        var data = (JsonElement)executionResult.Data;

        var jsonArtists = data.GetProperty("artists");

        Assert.AreEqual(1, jsonArtists.GetArrayLength());

        var jsonArtist = jsonArtists[0];

        Assert.AreEqual(artist.Id, jsonArtist.GetProperty("id").GetInt32());
        Assert.AreEqual(artist.CreatedAt, jsonArtist.GetProperty("createdAt").GetDateTime());
        Assert.AreEqual(artist.CreatedBy, jsonArtist.GetProperty("createdBy").GetString());
        Assert.AreEqual(artist.ModifiedAt, jsonArtist.GetProperty("modifiedAt").GetDateTime());
        Assert.AreEqual(artist.ModifiedBy, jsonArtist.GetProperty("modifiedBy").GetString());
        Assert.AreEqual(artist.Version, jsonArtist.GetProperty("version").GetInt32());
        Assert.AreEqual(artist.Name, jsonArtist.GetProperty("name").GetString());
        Assert.AreEqual(artist.NameKanji, jsonArtist.GetProperty("nameKanji").GetString());
        Assert.AreEqual(artist.Company, jsonArtist.GetProperty("company").GetString());
    }

    [TestMethod]
    public async Task Artists_NoArtist_ReturnsEmptyArray()
    {
        // Arrange

        var httpClient = this._testServer.CreateClient();

        var query = @"
                query GetArtists {
                    artists {
                        id
                        createdAt
                        createdBy
                        modifiedAt
                        modifiedBy
                        version
                        name
                        nameKanji
                        company
                    }
                }
            ";

        // Act

        var httpResponse = await httpClient.PostAsJsonAsync("/graphql", new { Query = query });

        // Assert

        Assert.IsTrue(httpResponse.IsSuccessStatusCode);

        var executionResult = await httpResponse.Content.ReadFromJsonAsync<ExecutionResult>();
        var data = (JsonElement)executionResult.Data;

        var jsonArtists = data.GetProperty("artists");

        Assert.AreEqual(0, jsonArtists.GetArrayLength());
    }

    [TestMethod]
    public async Task Artist_SingleArtist_CanReturnAllFields()
    {
        // Arrange

        var artist = FakeHelpers.Artist().Generate();

        using var dbContext = Globals.CreateContext();

        await dbContext.Artists.AddAsync(artist);

        await dbContext.Database.OpenConnectionAsync();
        await dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Artists] ON");

        await dbContext.SaveChangesAsync();

        var httpClient = this._testServer.CreateClient();

        var query = @"
                query GetArtist($id: Int!) {
                    artist(id: $id) {
                        id
                        createdAt
                        createdBy
                        modifiedAt
                        modifiedBy
                        version
                        name
                        nameKanji
                        company
                    }
                }
            ";

        // Act

        var httpResponse = await httpClient.PostAsJsonAsync("/graphql", new { Query = query, Variables = new { ID = artist.Id } } );

        // Assert

        Assert.IsTrue(httpResponse.IsSuccessStatusCode);

        var executionResult = await httpResponse.Content.ReadFromJsonAsync<ExecutionResult>();
        var data = (JsonElement)executionResult.Data;

        var jsonArtist = data.GetProperty("artist");

        Assert.IsNotNull(jsonArtist);

        Assert.AreEqual(artist.Id, jsonArtist.GetProperty("id").GetInt32());
        Assert.AreEqual(artist.CreatedAt, jsonArtist.GetProperty("createdAt").GetDateTime());
        Assert.AreEqual(artist.CreatedBy, jsonArtist.GetProperty("createdBy").GetString());
        Assert.AreEqual(artist.ModifiedAt, jsonArtist.GetProperty("modifiedAt").GetDateTime());
        Assert.AreEqual(artist.ModifiedBy, jsonArtist.GetProperty("modifiedBy").GetString());
        Assert.AreEqual(artist.Version, jsonArtist.GetProperty("version").GetInt32());
        Assert.AreEqual(artist.Name, jsonArtist.GetProperty("name").GetString());
        Assert.AreEqual(artist.NameKanji, jsonArtist.GetProperty("nameKanji").GetString());
        Assert.AreEqual(artist.Company, jsonArtist.GetProperty("company").GetString());
    }

    [TestMethod]
    public async Task Artist_NoArtist_ReturnsNull()
    {
        // Arrange

        var httpClient = this._testServer.CreateClient();

        var query = @"
                query GetArtist($id: Int!) {
                    artist(id: $id) {
                        id
                        createdAt
                        createdBy
                        modifiedAt
                        modifiedBy
                        version
                        name
                        nameKanji
                        company
                    }
                }
            ";

        // Act

        var httpResponse = await httpClient.PostAsJsonAsync("/graphql", new { Query = query, Variables = new { ID = 1 } });

        // Assert

        Assert.IsTrue(httpResponse.IsSuccessStatusCode);

        var executionResult = await httpResponse.Content.ReadFromJsonAsync<ExecutionResult>();
        var data = (JsonElement)executionResult.Data;

        var jsonArtist = data.GetProperty("artist");

        Assert.AreEqual(JsonValueKind.Null, jsonArtist.ValueKind);
    }
}
