//-----------------------------------------------------------------------------
// <copyright file="AccessoriesController.Test.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

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

namespace FEHub.Tests.Unit.Api.Controllers
{
    public sealed class AccessoriesControllerTests
    {
        [Fact]
        public async Task GetAllAsync_SingleAccessory_ReturnsSameAccessory()
        {
            // Arrange

            var accessory = FakeHelpers.Accessory().Generate();

            var mockAccessoryService = new Mock<IAccessoryService>();
            
            mockAccessoryService
                .Setup(x => x.GetAllAsync(CancellationToken.None))
                .Returns(Task.FromResult(new List<Accessory>() { accessory }));

            var accessoriesController = new AccessoriesController(mockAccessoryService.Object);

            // Act

            var response = await accessoriesController.GetAllAsync();

            // Assert

            Assert.IsType<OkObjectResult>(response.Result);

            var resultAccessory = ((response.Result as OkObjectResult).Value as IEnumerable<Accessory>)?.First();

            Assert.NotNull(resultAccessory);
            Assert.Equal(accessory.Id, resultAccessory.Id);
        }

        [Fact]
        public async Task GetByIdAsync_DoesNotExist_ReturnsNotFoundResponse()
        {
            // Arrange

            var mockAccessoryService = new Mock<IAccessoryService>();

            mockAccessoryService
                .Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
                .Returns(Task.FromResult<Accessory>(null));

            var accessoriesController = new AccessoriesController(mockAccessoryService.Object);

            var accessoryId = Guid.NewGuid();

            // Act

            var response = await accessoriesController.GetByIdAsync(accessoryId);

            // Assert

            Assert.IsType<NotFoundResult>(response.Result);
        }

        [Fact]
        public async Task GetByIdAsync_DoesExist_ReturnsSameAccessory()
        {
            // Arrange

            var accessory = FakeHelpers.Accessory().Generate();

            var mockAccessoryService = new Mock<IAccessoryService>();

            mockAccessoryService
                .Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
                .Returns(Task.FromResult(accessory));

            var accessoriesController = new AccessoriesController(mockAccessoryService.Object);

            // Act

            var response = await accessoriesController.GetByIdAsync(accessory.Id);

            // Assert

            Assert.IsType<OkObjectResult>(response.Result);

            var resultAccessory = (response.Result as OkObjectResult).Value as Accessory;

            Assert.NotNull(resultAccessory);
            Assert.Equal(accessory.Id, resultAccessory.Id);
        }
    }
}
