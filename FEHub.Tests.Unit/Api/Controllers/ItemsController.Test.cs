//-----------------------------------------------------------------------------
// <copyright file="ItemsController.Test.cs">
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
    public sealed class ItemsControllerTests
    {
        [Fact]
        public async Task GetAllAsync_SingleItem_ReturnsSameItem()
        {
            // Arrange

            var item = FakeHelpers.Item().Generate();

            var mockItemService = new Mock<IItemService>();
            
            mockItemService
                .Setup(x => x.GetAllAsync(CancellationToken.None))
                .Returns(Task.FromResult(new List<Item>() { item }));

            var itemsController = new ItemsController(mockItemService.Object);

            // Act

            var response = await itemsController.GetAllAsync();

            // Assert

            Assert.IsType<OkObjectResult>(response.Result);

            var resultItem = ((response.Result as OkObjectResult).Value as IEnumerable<Item>)?.First();

            Assert.NotNull(resultItem);
            Assert.Equal(item.Id, resultItem.Id);
        }

        [Fact]
        public async Task GetByIdAsync_DoesNotExist_ReturnsNotFoundResponse()
        {
            // Arrange

            var mockItemService = new Mock<IItemService>();

            mockItemService
                .Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
                .Returns(Task.FromResult<Item>(null));

            var itemsController = new ItemsController(mockItemService.Object);

            var itemId = Guid.NewGuid();

            // Act

            var response = await itemsController.GetByIdAsync(itemId);

            // Assert

            Assert.IsType<NotFoundResult>(response.Result);
        }

        [Fact]
        public async Task GetByIdAsync_DoesExist_ReturnsSameItem()
        {
            // Arrange

            var item = FakeHelpers.Item().Generate();

            var mockItemService = new Mock<IItemService>();

            mockItemService
                .Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
                .Returns(Task.FromResult(item));

            var itemsController = new ItemsController(mockItemService.Object);

            // Act

            var response = await itemsController.GetByIdAsync(item.Id);

            // Assert

            Assert.IsType<OkObjectResult>(response.Result);

            var resultItem = (response.Result as OkObjectResult)?.Value as Item;

            Assert.NotNull(resultItem);
            Assert.Equal(item.Id, resultItem.Id);
        }
    }
}
