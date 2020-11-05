//-----------------------------------------------------------------------------
// <copyright file="HeroesController.cs">
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
    public sealed class HeroesController : ControllerBase
    {
        private readonly IHeroService _heroService;

        public HeroesController(IHeroService heroService)
        {
            this._heroService = heroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accessory>>> GetAllAsync()
        {
            var heroes = await this._heroService.GetAllAsync();

            return this.Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Accessory>> GetById(Guid id)
        {
            var hero = await this._heroService.GetByIdAsync(id);

            if (hero == null)
            {
                return this.NotFound();
            }

            return this.Ok(hero);
        }
    }
}
