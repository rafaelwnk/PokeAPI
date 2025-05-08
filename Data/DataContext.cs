using Microsoft.EntityFrameworkCore;
using PokeAPI.Data.Mappings;
using PokeAPI.Models;

namespace PokeAPI.Data;

public class DataContext : DbContext
{
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<Models.Type> Types { get; set; }
    public DbSet<Region> Regions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("DataSource=PokeAPI.db;Cache=Shared");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PokemonMap());
        modelBuilder.ApplyConfiguration(new TypeMap());
        modelBuilder.ApplyConfiguration(new RegionMap());
    }
}