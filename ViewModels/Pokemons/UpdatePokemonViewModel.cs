namespace PokeAPI.ViewModels.Pokemons;

public class UpdatePokemonViewModel
{
    public string? Name { get; set; }
    public List<string>? Types { get; set; }
    public List<string>? Weaknesses { get; set; }
    public int? RegionId { get; set; }
    public bool? HasMega { get; set; }
}