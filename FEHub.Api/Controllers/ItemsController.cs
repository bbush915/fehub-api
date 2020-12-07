//-----------------------------------------------------------------------------
// <copyright file="ItemsController.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FEHub.Api.Services.Interfaces;
using FEHub.Entity.Models;

using Microsoft.AspNetCore.Mvc;

namespace FEHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            this._itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAllAsync()
        {
            var items = await this._itemService.GetAllAsync();
            return this.Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetByIdAsync(Guid id)
        {
            var item = await this._itemService.GetByIdAsync(id);

            if (item == null)
            {
                return this.NotFound();
            }

            return this.Ok(item);
        }
    }
}
