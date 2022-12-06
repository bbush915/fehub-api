using System.Collections.Generic;
using System.Threading.Tasks;

using FEHub.Api.Services.Interfaces;
using FEHub.Entity.Models;

using Microsoft.AspNetCore.Mvc;

namespace FEHub.Api.Controllers;

[ApiController]
[Route("api/voice-actors")]
public sealed class VoiceActorsController : ControllerBase
{
    private readonly IVoiceActorService _voiceActorService;

    public VoiceActorsController(IVoiceActorService voiceActorService)
    {
        this._voiceActorService = voiceActorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VoiceActor>>> GetAllAsync()
    {
        var voiceActors = await this._voiceActorService.GetAllAsync();

        return this.Ok(voiceActors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VoiceActor>> GetByIdAsync(int id)
    {
        var voiceActor = await this._voiceActorService.GetByIdAsync(id);

        if (voiceActor == null)
        {
            return this.NotFound();
        }

        return this.Ok(voiceActor);
    }
}
