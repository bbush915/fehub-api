using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Api.Controllers;
using FEHub.Api.Services.Interfaces;
using FEHub.Entity.Common.Helpers;
using FEHub.Entity.Models;

using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FEHub.Tests.Unit.Api.Controllers;

public sealed class HeroesControllerTests
{
    [Fact]
    public async Task GetAllAsync_SingleHero_ReturnsSameHero()
    {
        // Arrange

        var hero = FakeHelpers.Hero().Generate();

        var mockHeroService = new Mock<IHeroService>();
        
        mockHeroService
            .Setup(x => x.GetAllAsync(CancellationToken.None))
            .Returns(Task.FromResult(new List<Hero>() { hero }));

        var heroesController = new HeroesController(mockHeroService.Object);

        // Act

        var response = await heroesController.GetAllAsync();

        // Assert

        Assert.IsType<OkObjectResult>(response.Result);

        var resultHero = ((response.Result as OkObjectResult).Value as IEnumerable<Hero>)?.First();

        Assert.NotNull(resultHero);
        Assert.Equal(hero.Id, resultHero.Id);
    }

    [Fact]
    public async Task GetByIdAsync_DoesNotExist_ReturnsNotFoundResponse()
    {
        // Arrange

        var mockHeroService = new Mock<IHeroService>();

        mockHeroService
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
            .Returns(Task.FromResult<Hero>(null));

        var heroesController = new HeroesController(mockHeroService.Object);

        var heroId = Guid.NewGuid();

        // Act

        var response = await heroesController.GetByIdAsync(heroId);

        // Assert

        Assert.IsType<NotFoundResult>(response.Result);
    }

    [Fact]
    public async Task GetByIdAsync_DoesExist_ReturnsSameHero()
    {
        // Arrange

        var hero = FakeHelpers.Hero().Generate();

        var mockHeroService = new Mock<IHeroService>();

        mockHeroService
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
            .Returns(Task.FromResult(hero));

        var heroesController = new HeroesController(mockHeroService.Object);

        // Act

        var response = await heroesController.GetByIdAsync(hero.Id);

        // Assert

        Assert.IsType<OkObjectResult>(response.Result);

        var resultHero = (response.Result as OkObjectResult)?.Value as Hero;

        Assert.NotNull(resultHero);
        Assert.Equal(hero.Id, resultHero.Id);
    }
}
