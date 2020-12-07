//-----------------------------------------------------------------------------
// <copyright file="SkillsController.cs">
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
    public sealed class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            this._skillService = skillService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetAllAsync()
        {
            var skills = await this._skillService.GetAllAsync();
            return this.Ok(skills);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetByIdAsync(Guid id)
        {
            var skill = await this._skillService.GetByIdAsync(id);

            if (skill == null)
            {
                return this.NotFound();
            }

            return this.Ok(skill);
        }
    }
}
