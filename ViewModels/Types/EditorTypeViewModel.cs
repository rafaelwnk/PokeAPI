using System.ComponentModel.DataAnnotations;

namespace PokeAPI.ViewModels.Types;

public class EditorTypeViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string? Name { get; set; }
}