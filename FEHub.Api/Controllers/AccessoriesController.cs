using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FEHub.Api.Services.Interfaces;
using FEHub.Entity.Models;

using Microsoft.AspNetCore.Mvc;

namespace FEHub.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AccessoriesController : ControllerBase
{
    private readonly IAccessoryService _accessoryService;

    public AccessoriesController(IAccessoryService accessoryService)
    {
        this._accessoryService = accessoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Accessory>>> GetAllAsync()
    {
        var accessories = await this._accessoryService.GetAllAsync();

        return this.Ok(accessories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Accessory>> GetByIdAsync(Guid id)
    {
        var accessory = await this._accessoryService.GetByIdAsync(id);

        if (accessory == null)
        {
            return this.NotFound();
        }

        return this.Ok(accessory);
    }
}
