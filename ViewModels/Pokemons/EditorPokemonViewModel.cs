using System.ComponentModel.DataAnnotations;

namespace PokeAPI.ViewModels.Pokemons;

public class EditorPokemonViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Pokémon deve conter pelo menos um tipo.")]
    public List<string>? Types { get; set; }

    [Required(ErrorMessage = "Pokémon deve conter pelo menos uma fraqueza.")]
    public List<string>? Weaknesses { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "A região é obrigatória.")]
    public int RegionId { get; set; }
    public bool HasMega { get; set; }

}