using System.ComponentModel.DataAnnotations;

namespace PokeAPI.ViewModels.Regions;

public class EditorRegionViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string? Name { get; set; }
}