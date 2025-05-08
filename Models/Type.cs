using System.Text.Json.Serialization;

namespace PokeAPI.Models;

public class Type
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime LastUpdate { get; set; }
    [JsonIgnore]
    public IList<Pokemon>? Pokemons { get; set; }
    [JsonIgnore]
    public IList<Pokemon>? PokemonsWeakAgainst { get; set; }
}