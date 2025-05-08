namespace PokeAPI.Models;

public class Pokemon
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public IList<Type>? Types { get; set; }
    public IList<Type>? Weaknesses { get; set; }
    public int RegionId { get; set; }
    public Region? Region { get; set; }
    public bool HasMega { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime LastUpdate { get; set; }
}
