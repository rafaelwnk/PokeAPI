namespace PokeAPI.ViewModels.Pokemons;

public class ListPokemonViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<string>? Types { get; set; }
    public List<string>? Weaknesses { get; set; }
    public string? Region { get; set; }
    public bool HasMega { get; set; }
}