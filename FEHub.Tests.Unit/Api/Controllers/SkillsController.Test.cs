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

public sealed class SkillsControllerTests
{
    [Fact]
    public async Task GetAllAsync_SingleSkill_ReturnsSameSkill()
    {
        // Arrange

        var skill = FakeHelpers.Skill().Generate();

        var mockSkillService = new Mock<ISkillService>();
        
        mockSkillService
            .Setup(x => x.GetAllAsync(CancellationToken.None))
            .Returns(Task.FromResult(new List<Skill>() { skill }));

        var skillsController = new SkillsController(mockSkillService.Object);

        // Act

        var response = await skillsController.GetAllAsync();

        // Assert

        Assert.IsType<OkObjectResult>(response.Result);

        var resultSkill = ((response.Result as OkObjectResult).Value as IEnumerable<Skill>)?.First();

        Assert.NotNull(resultSkill);
        Assert.Equal(skill.Id, resultSkill.Id);
    }

    [Fact]
    public async Task GetByIdAsync_DoesNotExist_ReturnsNotFoundResponse()
    {
        // Arrange

        var mockSkillService = new Mock<ISkillService>();

        mockSkillService
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
            .Returns(Task.FromResult<Skill>(null));

        var skillsController = new SkillsController(mockSkillService.Object);

        var skillId = Guid.NewGuid();

        // Act

        var response = await skillsController.GetByIdAsync(skillId);

        // Assert

        Assert.IsType<NotFoundResult>(response.Result);
    }

    [Fact]
    public async Task GetByIdAsync_DoesExist_ReturnsSameSkill()
    {
        // Arrange

        var skill = FakeHelpers.Skill().Generate();

        var mockSkillService = new Mock<ISkillService>();

        mockSkillService
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
            .Returns(Task.FromResult(skill));

        var skillsController = new SkillsController(mockSkillService.Object);

        // Act

        var response = await skillsController.GetByIdAsync(skill.Id);

        // Assert

        Assert.IsType<OkObjectResult>(response.Result);

        var resultSkill = (response.Result as OkObjectResult)?.Value as Skill;

        Assert.NotNull(resultSkill);
        Assert.Equal(skill.Id, resultSkill.Id);
    }
}
