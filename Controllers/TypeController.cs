using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeAPI.Exceptions;
using PokeAPI.Extensions;
using PokeAPI.Interfaces;
using PokeAPI.ViewModels;
using PokeAPI.ViewModels.Types;

namespace PokeAPI.Controllers;

[ApiController]
public class TypeController : ControllerBase
{
    private readonly ITypeService _typeService;

    public TypeController(ITypeService typeService)
    {
        _typeService = typeService;
    }

    [HttpPost("v1/types")]
    public async Task<IActionResult> PostTypeAsync([FromBody] EditorTypeViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Models.Type>(ModelState.GetErrors()));

        try
        {
            var type = await _typeService.CreateAsync(model);
            return Ok(new ResultViewModel<Models.Type>(type));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Não foi possível cadastrar o tipo"));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpGet("v1/types")]
    public async Task<IActionResult> GetTypesAsync()
    {
        try
        {
            var types = await _typeService.GetAllAsync();
            return Ok(new ResultViewModel<List<ListTypeViewModel>>(types));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpGet("v1/types/{id:int}")]
    public async Task<IActionResult> GetTypeByIdAsync([FromRoute] int id)
    {
        try
        {
            var type = await _typeService.GetByIdAsync(id);
            return Ok(new ResultViewModel<ListTypeViewModel>(type));
        }
        catch (InvalidTypeException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpGet("v1/types/{name}")]
    public async Task<IActionResult> GetTypeByNameAsync([FromRoute] string name)
    {
        try
        {
            var type = await _typeService.GetByNameAsync(name);
            return Ok(new ResultViewModel<ListTypeViewModel>(type));
        }
        catch (InvalidTypeException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpPut("v1/types/{id:int}")]
    public async Task<IActionResult> PutTypeByIdAsync([FromRoute] int id, [FromBody] EditorTypeViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Models.Type>(ModelState.GetErrors()));

        try
        {
            var type = await _typeService.UpdateByIdAsync(id, model);
            return Ok(new ResultViewModel<Models.Type>(type));
        }
        catch (InvalidTypeException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Não foi possível atualizar o tipo."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpPut("v1/types/{name}")]
    public async Task<IActionResult> PutTypeByNameAsync([FromRoute] string name, [FromBody] EditorTypeViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Models.Type>(ModelState.GetErrors()));

        try
        {
            var type = await _typeService.UpdateByNameAsync(name, model);
            return Ok(new ResultViewModel<Models.Type>(type));
        }
        catch (InvalidTypeException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Não foi possível atualizar o tipo."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpDelete("v1/types/{id:int}")]
    public async Task<IActionResult> DeleteTypeByIdAsync([FromRoute] int id)
    {
        try
        {
            var type = await _typeService.DeleteByIdAsync(id);
            return Ok(new ResultViewModel<Models.Type>(type));
        }
        catch (InvalidTypeException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Não foi possível deletar o tipo."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }

    [HttpDelete("v1/types/{name}")]
    public async Task<IActionResult> DeleteTypeByNameAsync([FromRoute] string name)
    {
        try
        {
            var type = await _typeService.DeleteByNameAsync(name); ;
            return Ok(new ResultViewModel<Models.Type>(type));
        }
        catch (InvalidTypeException ex)
        {
            return NotFound(new ResultViewModel<string>(ex.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Não foi possível deletar o tipo."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Erro interno."));
        }
    }
}