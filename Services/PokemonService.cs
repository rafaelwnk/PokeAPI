using Microsoft.EntityFrameworkCore;
using PokeAPI.Data;
using PokeAPI.Exceptions;
using PokeAPI.Interfaces;
using PokeAPI.Models;
using PokeAPI.ViewModels.Pokemons;

namespace PokeAPI.Services;

public class PokemonService : IPokemonService
{
    private readonly DataContext _context;

    public PokemonService(DataContext context)
    {
        _context = context;
    }

    public async Task<Pokemon> CreateAsync(EditorPokemonViewModel model)
    {
        var types = await _context.Types.
            Where(x => model.Types!.Contains(x.Name!))
            .ToListAsync();
        if (!types.Any())
            throw new InvalidTypeException();

        var weaknesses = await _context.Types.
                Where(x => model.Weaknesses!.Contains(x.Name!))
                .ToListAsync();
        if (!weaknesses.Any())
            throw new InvalidWeaknessException();

        var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == model.RegionId);
        if (region == null)
            throw new InvalidRegionException();

        var pokemon = new Pokemon
        {
            Name = model.Name,
            Types = types,
            Weaknesses = weaknesses,
            RegionId = model.RegionId,
            Region = region,
            HasMega = model.HasMega,
        };

        await _context.Pokemons.AddAsync(pokemon);
        await _context.SaveChangesAsync();

        return pokemon;
    }

    public async Task<List<ListPokemonViewModel>> GetAllAsync()
    {
        var pokemons = await _context.Pokemons
            .AsNoTracking()
            .Select(x => new ListPokemonViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Types = x.Types!.Select(y => y.Name).ToList()!,
                Weaknesses = x.Weaknesses!.Select(y => y.Name).ToList()!,
                Region = x.Region!.Name,
                HasMega = x.HasMega
            })
            .OrderBy(x => x.Id)
            .ToListAsync();

        return pokemons;
    }

    public async Task<ListPokemonViewModel> GetByIdAsync(int id)
    {
        var pokemon = await _context.Pokemons
            .AsNoTracking()
            .Select(x => new ListPokemonViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Types = x.Types!.Select(y => y.Name).ToList()!,
                Weaknesses = x.Weaknesses!.Select(y => y.Name).ToList()!,
                Region = x.Region!.Name,
                HasMega = x.HasMega
            })
            .FirstOrDefaultAsync(x => x.Id == id);

        if (pokemon == null)
            throw new InvalidPokemonException();

        return pokemon;
    }

    public async Task<ListPokemonViewModel> GetByNameAsync(string name)
    {
        var pokemon = await _context.Pokemons
            .AsNoTracking()
            .Select(x => new ListPokemonViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Types = x.Types!.Select(y => y.Name).ToList()!,
                Weaknesses = x.Weaknesses!.Select(y => y.Name).ToList()!,
                Region = x.Region!.Name,
                HasMega = x.HasMega
            })
            .FirstOrDefaultAsync(x => x.Name == name);

        if (pokemon == null)
            throw new InvalidPokemonException();

        return pokemon;
    }

    public async Task<Pokemon> UpdateByIdAsync(int id, EditorPokemonViewModel model)
    {
        var pokemon = await _context.Pokemons
            .Include(x => x.Types)
            .Include(x => x.Weaknesses)
            .Include(x => x.Region)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (pokemon == null)
            throw new InvalidPokemonException();

        var types = await _context.Types.
            Where(x => model.Types!.Contains(x.Name!))
            .ToListAsync();
        if (!types.Any())
            throw new InvalidTypeException();

        var weaknesses = await _context.Types.
                Where(x => model.Weaknesses!.Contains(x.Name!))
                .ToListAsync();
        if (!weaknesses.Any())
            throw new InvalidWeaknessException();

        var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == model.RegionId);
        if (region == null)
            throw new InvalidRegionException();

        pokemon.Types!.Clear();
        pokemon.Weaknesses!.Clear();
        pokemon.Name = model.Name;
        pokemon.Types = types;
        pokemon.Weaknesses = weaknesses;
        pokemon.RegionId = model.RegionId;
        pokemon.Region = region;
        pokemon.HasMega = model.HasMega;
        pokemon.LastUpdate = DateTime.UtcNow;

        _context.Pokemons.Update(pokemon);
        await _context.SaveChangesAsync();

        return pokemon;
    }

    public async Task<Pokemon> UpdateByNameAsync(string name, EditorPokemonViewModel model)
    {
        var pokemon = await _context.Pokemons
            .Include(x => x.Types)
            .Include(x => x.Weaknesses)
            .Include(x => x.Region)
            .FirstOrDefaultAsync(x => x.Name == name);

        if (pokemon == null)
            throw new InvalidPokemonException();

        var types = await _context.Types.
            Where(x => model.Types!.Contains(x.Name!))
            .ToListAsync();
        if (!types.Any())
            throw new InvalidTypeException();

        var weaknesses = await _context.Types.
                Where(x => model.Weaknesses!.Contains(x.Name!))
                .ToListAsync();
        if (!weaknesses.Any())
            throw new InvalidWeaknessException();

        var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == model.RegionId);
        if (region == null)
            throw new InvalidRegionException();

        pokemon.Types!.Clear();
        pokemon.Weaknesses!.Clear();
        pokemon.Name = model.Name;
        pokemon.Types = types;
        pokemon.Weaknesses = weaknesses;
        pokemon.RegionId = model.RegionId;
        pokemon.Region = region;
        pokemon.HasMega = model.HasMega;
        pokemon.LastUpdate = DateTime.UtcNow;

        _context.Pokemons.Update(pokemon);
        await _context.SaveChangesAsync();

        return pokemon;
    }

    public async Task<Pokemon> UpdatePatchByIdAsync(int id, UpdatePokemonViewModel model)
    {
        var pokemon = await _context.Pokemons
            .Include(x => x.Types)
            .Include(x => x.Weaknesses)
            .Include(x => x.Region)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (pokemon == null)
            throw new InvalidPokemonException();

        if (!string.IsNullOrEmpty(model.Name))
            pokemon.Name = model.Name;

        if (model.Types != null && model.Types.Any())
        {
            var types = await _context.Types.
            Where(x => model.Types!.Contains(x.Name!))
            .ToListAsync();
            if (!types.Any())
                throw new InvalidTypeException();

            pokemon.Types!.Clear();
            pokemon.Types = types;
        }

        if (model.Weaknesses != null && model.Weaknesses.Any())
        {
            var weaknesses = await _context.Types.
            Where(x => model.Weaknesses!.Contains(x.Name!))
            .ToListAsync();
            if (!weaknesses.Any())
                throw new InvalidWeaknessException();

            pokemon.Weaknesses!.Clear();
            pokemon.Weaknesses = weaknesses;
        }

        if (model.RegionId.HasValue)
        {
            var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == model.RegionId);
            if (region == null)
                throw new InvalidRegionException();

            pokemon.RegionId = model.RegionId.Value;
            pokemon.Region = region;
        }

        if (model.HasMega.HasValue)
            pokemon.HasMega = model.HasMega.Value;

        pokemon.LastUpdate = DateTime.UtcNow;

        _context.Pokemons.Update(pokemon);
        await _context.SaveChangesAsync();

        return pokemon;
    }

    public async Task<Pokemon> UpdatePatchByNameAsync(string name, UpdatePokemonViewModel model)
    {
        var pokemon = await _context.Pokemons
            .Include(x => x.Types)
            .Include(x => x.Weaknesses)
            .Include(x => x.Region)
            .FirstOrDefaultAsync(x => x.Name == name);

        if (pokemon == null)
            throw new InvalidPokemonException();

        if (!string.IsNullOrEmpty(model.Name))
            pokemon.Name = model.Name;

        if (model.Types != null && model.Types.Any())
        {
            var types = await _context.Types.
            Where(x => model.Types!.Contains(x.Name!))
            .ToListAsync();
            if (!types.Any())
                throw new InvalidTypeException();

            pokemon.Types!.Clear();
            pokemon.Types = types;
        }

        if (model.Weaknesses != null && model.Weaknesses.Any())
        {
            var weaknesses = await _context.Types.
            Where(x => model.Weaknesses!.Contains(x.Name!))
            .ToListAsync();
            if (!weaknesses.Any())
                throw new InvalidWeaknessException();

            pokemon.Weaknesses!.Clear();
            pokemon.Weaknesses = weaknesses;
        }

        if (model.RegionId.HasValue)
        {
            var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == model.RegionId);
            if (region == null)
                throw new InvalidRegionException();

            pokemon.RegionId = model.RegionId.Value;
            pokemon.Region = region;
        }

        if (model.HasMega.HasValue)
            pokemon.HasMega = model.HasMega.Value;

        pokemon.LastUpdate = DateTime.UtcNow;

        _context.Pokemons.Update(pokemon);
        await _context.SaveChangesAsync();

        return pokemon;
    }

    public async Task<Pokemon> DeleteByIdAsync(int id)
    {
        var pokemon = await _context.Pokemons.FirstOrDefaultAsync(x => x.Id == id);
        if (pokemon == null)
            throw new InvalidPokemonException();

        _context.Pokemons.Remove(pokemon);
        await _context.SaveChangesAsync();

        return pokemon;
    }

    public async Task<Pokemon> DeleteByNameAsync(string name)
    {
        var pokemon = await _context.Pokemons.FirstOrDefaultAsync(x => x.Name == name);
        if (pokemon == null)
            throw new InvalidPokemonException();

        _context.Pokemons.Remove(pokemon);
        await _context.SaveChangesAsync();

        return pokemon;
    }
}