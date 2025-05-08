using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeAPI.Exceptions;
using PokeAPI.Extensions;
using PokeAPI.Interfaces;
using PokeAPI.Models;
using PokeAPI.ViewModels;
using PokeAPI.ViewModels.Pokemons;

namespace PokeAPI.Controllers;

[ApiController]
public class PokemonController : ControllerBase
{
    private readonly IPokemonService _pokemonService;

    public PokemonController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    [HttpPost("v1/pokemons")]
    public async Task<IActionResult> PostPokemonAsync([FromBody] EditorPokemonViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Pokemon>(ModelState.GetErrors()));

        try
        {
            var pokemon = await _pokemonService.CreateAsync(model);
            return Ok(new ResultViewModel<Pokemon>(pokemon));
        }
        catch (InvalidTypeException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (InvalidWeaknessException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (InvalidRegionException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Não foi possível cadastrar o pokémon"));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpGet("v1/pokemons")]
    public async Task<IActionResult> GetPokemonsAsync()
    {
        try
        {
            var pokemons = await _pokemonService.GetAllAsync();
            return Ok(new ResultViewModel<List<ListPokemonViewModel>>(pokemons));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpGet("v1/pokemons/{id:int}")]
    public async Task<IActionResult> GetPokemonByIdAsync([FromRoute] int id)
    {
        try
        {
            var pokemon = await _pokemonService.GetByIdAsync(id);
            return Ok(new ResultViewModel<ListPokemonViewModel>(pokemon));
        }
        catch (InvalidPokemonException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpGet("v1/pokemons/{name}")]
    public async Task<IActionResult> GetPokemonByNameAsync([FromRoute] string name)
    {
        try
        {
            var pokemon = await _pokemonService.GetByNameAsync(name);
            return Ok(new ResultViewModel<ListPokemonViewModel>(pokemon));
        }
        catch (InvalidPokemonException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpPut("v1/pokemons/{id:int}")]
    public async Task<IActionResult> PutPokemonByIdAsync([FromRoute] int id, [FromBody] EditorPokemonViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Pokemon>(ModelState.GetErrors()));

        try
        {
            var pokemon = await _pokemonService.UpdateByIdAsync(id, model);
            return Ok(new ResultViewModel<Pokemon>(pokemon));
        }
        catch (InvalidPokemonException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (InvalidTypeException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (InvalidWeaknessException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (InvalidRegionException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Não foi possível atualizar o pokémon."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpPut("v1/pokemons/{name}")]
    public async Task<IActionResult> PutPokemonByNameAsync([FromRoute] string name, [FromBody] EditorPokemonViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Pokemon>(ModelState.GetErrors()));

        try
        {
            var pokemon = await _pokemonService.UpdateByNameAsync(name, model);
            return Ok(new ResultViewModel<Pokemon>(pokemon));
        }
        catch (InvalidPokemonException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (InvalidTypeException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (InvalidWeaknessException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (InvalidRegionException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Não foi possível atualizar o pokémon."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpPatch("v1/pokemons/{id:int}")]
    public async Task<IActionResult> PatchPokemonByIdAsync([FromRoute] int id, [FromBody] UpdatePokemonViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Pokemon>(ModelState.GetErrors()));

        try
        {
            var pokemon = await _pokemonService.UpdatePatchByIdAsync(id, model);
            return Ok(new ResultViewModel<Pokemon>(pokemon));
        }
        catch (InvalidPokemonException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (InvalidTypeException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (InvalidWeaknessException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (InvalidRegionException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Não foi possível atualizar o pokémon."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpPatch("v1/pokemons/{name}")]
    public async Task<IActionResult> PatchPokemonByNameAsync([FromRoute] string name, [FromBody] UpdatePokemonViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Pokemon>(ModelState.GetErrors()));

        try
        {
            var pokemon = await _pokemonService.UpdatePatchByNameAsync(name, model);
            return Ok(new ResultViewModel<Pokemon>(pokemon));
        }
        catch (InvalidPokemonException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (InvalidTypeException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (InvalidWeaknessException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (InvalidRegionException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Não foi possível atualizar o pokémon."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }

    }

    [HttpDelete("v1/pokemons/{id:int}")]
    public async Task<IActionResult> DeletePokemonByIdAsync([FromRoute] int id)
    {
        try
        {
            var pokemon = await _pokemonService.DeleteByIdAsync(id);
            return Ok(new ResultViewModel<Pokemon>(pokemon));
        }
        catch (InvalidPokemonException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Não foi possível deletar o pokémon."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpDelete("v1/pokemons/{name}")]
    public async Task<IActionResult> DeletePokemonByNameAsync([FromRoute] string name)
    {
        try
        {
            var pokemon = await _pokemonService.DeleteByNameAsync(name);
            return Ok(new ResultViewModel<Pokemon>(pokemon));
        }
        catch (InvalidPokemonException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Não foi possível deletar o pokémon."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }
}