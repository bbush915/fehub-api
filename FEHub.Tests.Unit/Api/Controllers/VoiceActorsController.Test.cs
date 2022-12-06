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

public sealed class VoiceActorsControllerTests
{
    [Fact]
    public async Task GetAllAsync_SingleVoiceActor_ReturnsSameVoiceActor()
    {
        // Arrange

        var voiceActor = FakeHelpers.VoiceActor().Generate();

        var mockVoiceActorService = new Mock<IVoiceActorService>();
        
        mockVoiceActorService
            .Setup(x => x.GetAllAsync(CancellationToken.None))
            .Returns(Task.FromResult(new List<VoiceActor>() { voiceActor }));

        var voiceActorsController = new VoiceActorsController(mockVoiceActorService.Object);

        // Act

        var response = await voiceActorsController.GetAllAsync();

        // Assert

        Assert.IsType<OkObjectResult>(response.Result);

        var resultVoiceActor = ((response.Result as OkObjectResult).Value as IEnumerable<VoiceActor>)?.First();

        Assert.NotNull(resultVoiceActor);
        Assert.Equal(voiceActor.Id, resultVoiceActor.Id);
    }

    [Fact]
    public async Task GetByIdAsync_DoesNotExist_ReturnsNotFoundResponse()
    {
        // Arrange

        var mockVoiceActorService = new Mock<IVoiceActorService>();

        mockVoiceActorService
            .Setup(x => x.GetByIdAsync(It.IsAny<int>(), CancellationToken.None))
            .Returns(Task.FromResult<VoiceActor>(null));

        var voiceActorsController = new VoiceActorsController(mockVoiceActorService.Object);

        var voiceActorId = 1;

        // Act

        var response = await voiceActorsController.GetByIdAsync(voiceActorId);

        // Assert

        Assert.IsType<NotFoundResult>(response.Result);
    }

    [Fact]
    public async Task GetByIdAsync_DoesExist_ReturnsSameVoiceActor()
    {
        // Arrange

        var voiceActor = FakeHelpers.VoiceActor().Generate();

        var mockVoiceActorService = new Mock<IVoiceActorService>();

        mockVoiceActorService
            .Setup(x => x.GetByIdAsync(It.IsAny<int>(), CancellationToken.None))
            .Returns(Task.FromResult(voiceActor));

        var voiceActorsController = new VoiceActorsController(mockVoiceActorService.Object);

        // Act

        var response = await voiceActorsController.GetByIdAsync(voiceActor.Id);

        // Assert

        Assert.IsType<OkObjectResult>(response.Result);

        var resultVoiceActor = (response.Result as OkObjectResult)?.Value as VoiceActor;

        Assert.NotNull(resultVoiceActor);
        Assert.Equal(voiceActor.Id, resultVoiceActor.Id);
    }
}
