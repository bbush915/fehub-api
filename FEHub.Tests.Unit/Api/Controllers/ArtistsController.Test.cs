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

public sealed class ArtistsControllerTests
{
    [Fact]
    public async Task GetAllAsync_SingleArtist_ReturnsSameArtist()
    {
        // Arrange

        var artist = FakeHelpers.Artist().Generate();

        var mockArtistService = new Mock<IArtistService>();
        
        mockArtistService
            .Setup(x => x.GetAllAsync(CancellationToken.None))
            .Returns(Task.FromResult(new List<Artist>() { artist }));

        var artistsController = new ArtistsController(mockArtistService.Object);

        // Act

        var response = await artistsController.GetAllAsync();

        // Assert

        Assert.IsType<OkObjectResult>(response.Result);

        var resultArtist = ((response.Result as OkObjectResult).Value as IEnumerable<Artist>)?.First();

        Assert.NotNull(resultArtist);
        Assert.Equal(artist.Id, resultArtist.Id);
    }

    [Fact]
    public async Task GetByIdAsync_DoesNotExist_ReturnsNotFoundResponse()
    {
        // Arrange

        var mockArtistService = new Mock<IArtistService>();

        mockArtistService
            .Setup(x => x.GetByIdAsync(It.IsAny<int>(), CancellationToken.None))
            .Returns(Task.FromResult<Artist>(null));

        var artistsController = new ArtistsController(mockArtistService.Object);

        var artistId = 1;

        // Act

        var response = await artistsController.GetByIdAsync(artistId);

        // Assert

        Assert.IsType<NotFoundResult>(response.Result);
    }

    [Fact]
    public async Task GetByIdAsync_DoesExist_ReturnsSameArtist()
    {
        // Arrange

        var artist = FakeHelpers.Artist().Generate();

        var mockArtistService = new Mock<IArtistService>();

        mockArtistService
            .Setup(x => x.GetByIdAsync(It.IsAny<int>(), CancellationToken.None))
            .Returns(Task.FromResult(artist));

        var artistsController = new ArtistsController(mockArtistService.Object);

        // Act

        var response = await artistsController.GetByIdAsync(artist.Id);

        // Assert

        Assert.IsType<OkObjectResult>(response.Result);

        var resultArtist = (response.Result as OkObjectResult)?.Value as Artist;

        Assert.NotNull(resultArtist);
        Assert.Equal(artist.Id, resultArtist.Id);
    }
}
