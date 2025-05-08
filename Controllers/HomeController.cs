using Microsoft.AspNetCore.Mvc;
using PokeAPI.ViewModels;
namespace PokeAPI.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("/health")]
    public IActionResult GetApi()
    {
        return Ok(new ResultViewModel<string>("API funcionando!", null!));
    }
}