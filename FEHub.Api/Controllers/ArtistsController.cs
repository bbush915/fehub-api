using System.Collections.Generic;
using System.Threading.Tasks;

using FEHub.Api.Services.Interfaces;
using FEHub.Entity.Models;

using Microsoft.AspNetCore.Mvc;

namespace FEHub.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ArtistsController : ControllerBase
{
    private readonly IArtistService _artistService;

    public ArtistsController(IArtistService artistService)
    {
        this._artistService = artistService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Artist>>> GetAllAsync()
    {
        var artists = await this._artistService.GetAllAsync();

        return this.Ok(artists);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Artist>> GetByIdAsync(int id)
    {
        var artist = await this._artistService.GetByIdAsync(id);

        if (artist == null)
        {
            return this.NotFound();
        }

        return this.Ok(artist);
    }
}
