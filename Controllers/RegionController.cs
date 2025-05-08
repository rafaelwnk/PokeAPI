using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeAPI.Exceptions;
using PokeAPI.Extensions;
using PokeAPI.Interfaces;
using PokeAPI.Models;
using PokeAPI.ViewModels;
using PokeAPI.ViewModels.Regions;

namespace PokeAPI.Controllers;

[ApiController]
public class RegionController : ControllerBase
{
    private readonly IRegionService _regionService;

    public RegionController(IRegionService regionService)
    {
        _regionService = regionService;
    }

    [HttpPost("v1/regions")]
    public async Task<IActionResult> PostRegionAsync([FromBody] EditorRegionViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Region>(ModelState.GetErrors()));

        try
        {
            var region = await _regionService.CreateAsync(model);
            return Ok(new ResultViewModel<Region>(region));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Não foi possível cadastrar a região."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpGet("v1/regions")]
    public async Task<IActionResult> GetRegionsAsync()
    {
        try
        {
            var regions = await _regionService.GetAllAsync();
            return Ok(new ResultViewModel<List<ListRegionViewModel>>(regions));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpGet("v1/regions/{id:int}")]
    public async Task<IActionResult> GetRegionByIdAsync([FromRoute] int id)
    {
        try
        {
            var region = await _regionService.GetByIdAsync(id);
            return Ok(new ResultViewModel<ListRegionViewModel>(region));
        }
        catch (InvalidRegionException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpGet("v1/regions/{name}")]
    public async Task<IActionResult> GetRegionByNameAsync([FromRoute] string name)
    {
        try
        {
            var region = await _regionService.GetByNameAsync(name);
            return Ok(new ResultViewModel<ListRegionViewModel>(region));
        }
        catch (InvalidRegionException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpPut("v1/regions/{id:int}")]
    public async Task<IActionResult> PutRegionByIdAsync([FromRoute] int id, [FromBody] EditorRegionViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Region>(ModelState.GetErrors()));

        try
        {
            var region = await _regionService.UpdateByIdAsync(id, model);
            return Ok(new ResultViewModel<Region>(region));
        }
        catch (InvalidRegionException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Não foi possível atualizar a região."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpPut("v1/regions/{name}")]
    public async Task<IActionResult> PutRegionByNameAsync([FromRoute] string name, [FromBody] EditorRegionViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Region>(ModelState.GetErrors()));

        try
        {
            var region = await _regionService.UpdateByNameAsync(name, model);
            return Ok(new ResultViewModel<Region>(region));
        }
        catch (InvalidRegionException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Não foi possível atualizar a região."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpDelete("v1/regions/{id:int}")]
    public async Task<IActionResult> DeleteRegionByIdAsync([FromRoute] int id)
    {
        try
        {
            var region = await _regionService.DeleteByIdAsync(id);
            return Ok(new ResultViewModel<Region>(region));
        }
        catch (InvalidRegionException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Não foi possível deletar a região."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpDelete("v1/regions/{name}")]
    public async Task<IActionResult> DeleteRegionByNameAsync([FromRoute] string name)
    {
        try
        {
            var region = await _regionService.DeleteByNameAsync(name);
            return Ok(new ResultViewModel<Region>(region));
        }
        catch (InvalidRegionException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Não foi possível deletar a região."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }
}