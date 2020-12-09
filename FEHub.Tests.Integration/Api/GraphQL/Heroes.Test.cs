//-----------------------------------------------------------------------------
// <copyright file="Heroes.Test.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Common.Helpers;
using FEHub.Tests.Integration.Utilities;

using GraphQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FEHub.Tests.Integration.Api.GraphQL
{
    [TestClass]
    public sealed class HeroesTests
    {
        private readonly TestServer _testServer;

        public HeroesTests()
        {
            this._testServer = TestHelpers.GetTestServer();
        }

        [TestCleanup]
        public async Task AfterEachAsync()
        {
            await Global.ResetDatabaseAsync();
        }

        [TestMethod]
        public async Task Heroes_SingleHero_CanReturnAllFields()
        {
            // Arrange

            var artist = FakeHelpers.Artist().Generate();
            var hero = FakeHelpers.Hero(artistId: artist.Id).Generate();

            using var dbContext = Global.GetDbContext();

            await dbContext.Artists.AddAsync(artist);
            await dbContext.Heroes.AddAsync(hero);

            await dbContext.Database.OpenConnectionAsync();
            await dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Artists] ON");

            await dbContext.SaveChangesAsync();

            var httpClient = this._testServer.CreateClient();

            var query = @"
                query GetHeroes {
                    heroes {
                        id
                        createdAt
                        createdBy
                        modifiedAt
                        modifiedBy
                        version
                        name
                        title
                        description
                        origin
                        gender
                        additionDate
                        releaseDate
                        artistId
                        isLegendaryHero
                        isMythicHero
                        element
                        legendaryHeroBoostType
                        mythicHeroBoostType
                        isDuoHero
                        isResplendentHero
                        color
                        weapon
                        movementType
                        bvid
                        baseHitPoints
                        hitPointsGrowthRate
                        baseAttack
                        attackGrowthRate
                        baseSpeed
                        speedGrowthRate
                        baseDefense
                        defenseGrowthRate
                        baseResistance
                        resistanceGrowthRate
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

            var jsonHeroes = data.GetProperty("heroes");

            Assert.AreEqual(1, jsonHeroes.GetArrayLength());

            var jsonHero = jsonHeroes[0];

            Assert.AreEqual(hero.Id, jsonHero.GetProperty("id").GetGuid());
            Assert.AreEqual(hero.CreatedAt, jsonHero.GetProperty("createdAt").GetDateTime());
            Assert.AreEqual(hero.CreatedBy, jsonHero.GetProperty("createdBy").GetString());
            Assert.AreEqual(hero.ModifiedAt, jsonHero.GetProperty("modifiedAt").GetDateTime());
            Assert.AreEqual(hero.ModifiedBy, jsonHero.GetProperty("modifiedBy").GetString());
            Assert.AreEqual(hero.Version, jsonHero.GetProperty("version").GetInt32());
            Assert.AreEqual(hero.Name, jsonHero.GetProperty("name").GetString());
            Assert.AreEqual(hero.Title, jsonHero.GetProperty("title").GetString());
            Assert.AreEqual(hero.Description, jsonHero.GetProperty("description").GetString());
            Assert.AreEqual(hero.Origin, jsonHero.GetProperty("origin").GetString());
            Assert.AreEqual(hero.Gender, (Genders)jsonHero.GetProperty("gender").GetInt32());
            Assert.AreEqual(hero.AdditionDate, jsonHero.GetProperty("additionDate").GetDateTime());
            Assert.AreEqual(hero.ReleaseDate, jsonHero.GetProperty("releaseDate").GetDateTime());
            Assert.AreEqual(hero.ArtistId, jsonHero.GetProperty("artistId").GetInt32());
            Assert.AreEqual(hero.IsLegendaryHero, jsonHero.GetProperty("isLegendaryHero").GetBoolean());
            Assert.AreEqual(hero.IsMythicHero, jsonHero.GetProperty("isMythicHero").GetBoolean());
            Assert.AreEqual(hero.Element, jsonHero.GetProperty("element").ValueKind == JsonValueKind.Null ? null : (Elements)jsonHero.GetProperty("element").GetInt32());
            Assert.AreEqual(hero.LegendaryHeroBoostType, jsonHero.GetProperty("legendaryHeroBoostType").ValueKind == JsonValueKind.Null ? null : (LegendaryHeroBoostTypes)jsonHero.GetProperty("legendaryHeroBoostType").GetInt32());
            Assert.AreEqual(hero.MythicHeroBoostType, jsonHero.GetProperty("mythicHeroBoostType").ValueKind == JsonValueKind.Null ? null : (MythicHeroBoostTypes)jsonHero.GetProperty("mythicHeroBoostType").GetInt32());
            Assert.AreEqual(hero.IsDuoHero, jsonHero.GetProperty("isDuoHero").GetBoolean());
            Assert.AreEqual(hero.IsResplendentHero, jsonHero.GetProperty("isResplendentHero").GetBoolean());
            Assert.AreEqual(hero.Color, (Colors)jsonHero.GetProperty("color").GetInt32());
            Assert.AreEqual(hero.Weapon, (Weapons)jsonHero.GetProperty("weapon").GetInt32());
            Assert.AreEqual(hero.MovementType, (MovementTypes)jsonHero.GetProperty("movementType").GetInt32());
            Assert.AreEqual(hero.BVID, jsonHero.GetProperty("bvid").GetInt32());
            Assert.AreEqual(hero.BaseHitPoints, jsonHero.GetProperty("baseHitPoints").GetInt32());
            Assert.AreEqual(hero.HitPointsGrowthRate, jsonHero.GetProperty("hitPointsGrowthRate").GetInt32());
            Assert.AreEqual(hero.BaseAttack, jsonHero.GetProperty("baseAttack").GetInt32());
            Assert.AreEqual(hero.AttackGrowthRate, jsonHero.GetProperty("attackGrowthRate").GetInt32());
            Assert.AreEqual(hero.BaseSpeed, jsonHero.GetProperty("baseSpeed").GetInt32());
            Assert.AreEqual(hero.SpeedGrowthRate, jsonHero.GetProperty("speedGrowthRate").GetInt32());
            Assert.AreEqual(hero.BaseDefense, jsonHero.GetProperty("baseDefense").GetInt32());
            Assert.AreEqual(hero.DefenseGrowthRate, jsonHero.GetProperty("defenseGrowthRate").GetInt32());
            Assert.AreEqual(hero.BaseResistance, jsonHero.GetProperty("baseResistance").GetInt32());
            Assert.AreEqual(hero.ResistanceGrowthRate, jsonHero.GetProperty("resistanceGrowthRate").GetInt32());
            Assert.AreEqual(hero.Tag, jsonHero.GetProperty("tag").GetString());

        }

        [TestMethod]
        public async Task Heroes_NoHero_ReturnsEmptyArray()
        {
            // Arrange

            var httpClient = this._testServer.CreateClient();

            var query = @"
                query GetHeroes {
                    heroes {
                        id
                        createdAt
                        createdBy
                        modifiedAt
                        modifiedBy
                        version
                        name
                        title
                        description
                        origin
                        gender
                        additionDate
                        releaseDate
                        artistId
                        isLegendaryHero
                        isMythicHero
                        element
                        legendaryHeroBoostType
                        mythicHeroBoostType
                        isDuoHero
                        isResplendentHero
                        color
                        weapon
                        movementType
                        bvid
                        baseHitPoints
                        hitPointsGrowthRate
                        baseAttack
                        attackGrowthRate
                        baseSpeed
                        speedGrowthRate
                        baseDefense
                        defenseGrowthRate
                        baseResistance
                        resistanceGrowthRate
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

            var jsonHeroes = data.GetProperty("heroes");

            Assert.AreEqual(0, jsonHeroes.GetArrayLength());
        }

        [TestMethod]
        public async Task Hero_SingleHero_CanReturnAllFields()
        {
            // Arrange

            var artist = FakeHelpers.Artist().Generate();
            var hero = FakeHelpers.Hero(artistId: artist.Id).Generate();

            using var dbContext = Global.GetDbContext();

            await dbContext.Artists.AddAsync(artist);
            await dbContext.Heroes.AddAsync(hero);

            await dbContext.Database.OpenConnectionAsync();
            await dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Artists] ON");

            await dbContext.SaveChangesAsync();

            var httpClient = this._testServer.CreateClient();

            var query = @"
                query GetHero($id: Guid!) {
                    hero(id: $id) {
                        id
                        createdAt
                        createdBy
                        modifiedAt
                        modifiedBy
                        version
                        name
                        title
                        description
                        origin
                        gender
                        additionDate
                        releaseDate
                        artistId
                        isLegendaryHero
                        isMythicHero
                        element
                        legendaryHeroBoostType
                        mythicHeroBoostType
                        isDuoHero
                        isResplendentHero
                        color
                        weapon
                        movementType
                        bvid
                        baseHitPoints
                        hitPointsGrowthRate
                        baseAttack
                        attackGrowthRate
                        baseSpeed
                        speedGrowthRate
                        baseDefense
                        defenseGrowthRate
                        baseResistance
                        resistanceGrowthRate
                        tag
                    }
                }
            ";

            // Act

            var httpResponse = await httpClient.PostAsJsonAsync("/graphql", new { Query = query, Variables = new { ID = hero.Id } } );

            // Assert

            Assert.IsTrue(httpResponse.IsSuccessStatusCode);

            var executionResult = await httpResponse.Content.ReadFromJsonAsync<ExecutionResult>();
            var data = (JsonElement)executionResult.Data;

            var jsonHero = data.GetProperty("hero");

            Assert.IsNotNull(jsonHero);

            Assert.AreEqual(hero.Id, jsonHero.GetProperty("id").GetGuid());
            Assert.AreEqual(hero.CreatedAt, jsonHero.GetProperty("createdAt").GetDateTime());
            Assert.AreEqual(hero.CreatedBy, jsonHero.GetProperty("createdBy").GetString());
            Assert.AreEqual(hero.ModifiedAt, jsonHero.GetProperty("modifiedAt").GetDateTime());
            Assert.AreEqual(hero.ModifiedBy, jsonHero.GetProperty("modifiedBy").GetString());
            Assert.AreEqual(hero.Version, jsonHero.GetProperty("version").GetInt32());
            Assert.AreEqual(hero.Name, jsonHero.GetProperty("name").GetString());
            Assert.AreEqual(hero.Title, jsonHero.GetProperty("title").GetString());
            Assert.AreEqual(hero.Description, jsonHero.GetProperty("description").GetString());
            Assert.AreEqual(hero.Origin, jsonHero.GetProperty("origin").GetString());
            Assert.AreEqual(hero.Gender, (Genders)jsonHero.GetProperty("gender").GetInt32());
            Assert.AreEqual(hero.AdditionDate, jsonHero.GetProperty("additionDate").GetDateTime());
            Assert.AreEqual(hero.ReleaseDate, jsonHero.GetProperty("releaseDate").GetDateTime());
            Assert.AreEqual(hero.ArtistId, jsonHero.GetProperty("artistId").GetInt32());
            Assert.AreEqual(hero.IsLegendaryHero, jsonHero.GetProperty("isLegendaryHero").GetBoolean());
            Assert.AreEqual(hero.IsMythicHero, jsonHero.GetProperty("isMythicHero").GetBoolean());
            Assert.AreEqual(hero.Element, jsonHero.GetProperty("element").ValueKind == JsonValueKind.Null ? null : (Elements)jsonHero.GetProperty("element").GetInt32());
            Assert.AreEqual(hero.LegendaryHeroBoostType, jsonHero.GetProperty("legendaryHeroBoostType").ValueKind == JsonValueKind.Null ? null : (LegendaryHeroBoostTypes)jsonHero.GetProperty("legendaryHeroBoostType").GetInt32());
            Assert.AreEqual(hero.MythicHeroBoostType, jsonHero.GetProperty("mythicHeroBoostType").ValueKind == JsonValueKind.Null ? null : (MythicHeroBoostTypes)jsonHero.GetProperty("mythicHeroBoostType").GetInt32());
            Assert.AreEqual(hero.IsDuoHero, jsonHero.GetProperty("isDuoHero").GetBoolean());
            Assert.AreEqual(hero.IsResplendentHero, jsonHero.GetProperty("isResplendentHero").GetBoolean());
            Assert.AreEqual(hero.Color, (Colors)jsonHero.GetProperty("color").GetInt32());
            Assert.AreEqual(hero.Weapon, (Weapons)jsonHero.GetProperty("weapon").GetInt32());
            Assert.AreEqual(hero.MovementType, (MovementTypes)jsonHero.GetProperty("movementType").GetInt32());
            Assert.AreEqual(hero.BVID, jsonHero.GetProperty("bvid").GetInt32());
            Assert.AreEqual(hero.BaseHitPoints, jsonHero.GetProperty("baseHitPoints").GetInt32());
            Assert.AreEqual(hero.HitPointsGrowthRate, jsonHero.GetProperty("hitPointsGrowthRate").GetInt32());
            Assert.AreEqual(hero.BaseAttack, jsonHero.GetProperty("baseAttack").GetInt32());
            Assert.AreEqual(hero.AttackGrowthRate, jsonHero.GetProperty("attackGrowthRate").GetInt32());
            Assert.AreEqual(hero.BaseSpeed, jsonHero.GetProperty("baseSpeed").GetInt32());
            Assert.AreEqual(hero.SpeedGrowthRate, jsonHero.GetProperty("speedGrowthRate").GetInt32());
            Assert.AreEqual(hero.BaseDefense, jsonHero.GetProperty("baseDefense").GetInt32());
            Assert.AreEqual(hero.DefenseGrowthRate, jsonHero.GetProperty("defenseGrowthRate").GetInt32());
            Assert.AreEqual(hero.BaseResistance, jsonHero.GetProperty("baseResistance").GetInt32());
            Assert.AreEqual(hero.ResistanceGrowthRate, jsonHero.GetProperty("resistanceGrowthRate").GetInt32());
            Assert.AreEqual(hero.Tag, jsonHero.GetProperty("tag").GetString());
        }

        [TestMethod]
        public async Task Hero_NoHero_ReturnsNull()
        {
            // Arrange

            var httpClient = this._testServer.CreateClient();

            var query = @"
                query GetHero($id: Guid!) {
                    hero(id: $id) {
                        id
                        createdAt
                        createdBy
                        modifiedAt
                        modifiedBy
                        version
                        name
                        title
                        description
                        origin
                        gender
                        additionDate
                        releaseDate
                        artistId
                        isLegendaryHero
                        isMythicHero
                        element
                        legendaryHeroBoostType
                        mythicHeroBoostType
                        isDuoHero
                        isResplendentHero
                        color
                        weapon
                        movementType
                        bvid
                        baseHitPoints
                        hitPointsGrowthRate
                        baseAttack
                        attackGrowthRate
                        baseSpeed
                        speedGrowthRate
                        baseDefense
                        defenseGrowthRate
                        baseResistance
                        resistanceGrowthRate
                        tag
                    }
                }
            ";

            // Act

            var httpResponse = await httpClient.PostAsJsonAsync("/graphql", new { Query = query, Variables = new { ID = Guid.NewGuid() } });

            // Assert

            Assert.IsTrue(httpResponse.IsSuccessStatusCode);

            var executionResult = await httpResponse.Content.ReadFromJsonAsync<ExecutionResult>();
            var data = (JsonElement)executionResult.Data;

            var jsonHero = data.GetProperty("hero");

            Assert.AreEqual(JsonValueKind.Null, jsonHero.ValueKind);
        }
    }
}
