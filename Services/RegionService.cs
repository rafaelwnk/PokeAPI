using Microsoft.EntityFrameworkCore;
using PokeAPI.Data;
using PokeAPI.Exceptions;
using PokeAPI.Interfaces;
using PokeAPI.Models;
using PokeAPI.ViewModels.Regions;

namespace PokeAPI.Services;

public class RegionService : IRegionService
{
    private readonly DataContext _context;

    public RegionService(DataContext context)
    {
        _context = context;
    }

    public async Task<Region> CreateAsync(EditorRegionViewModel model)
    {
        var region = new Region
        {
            Name = model.Name,
        };

        await _context.Regions.AddAsync(region);
        await _context.SaveChangesAsync();

        return region;
    }

    public async Task<List<ListRegionViewModel>> GetAllAsync()
    {
        var regions = await _context.Regions
            .AsNoTracking()
            .Select(x => new ListRegionViewModel
            {
                Id = x.Id,
                Name = x.Name
            })
            .OrderBy(x => x.Id)
            .ToListAsync();

        return regions;
    }

    public async Task<ListRegionViewModel> GetByIdAsync(int id)
    {
        var region = await _context.Regions
            .AsNoTracking()
            .Select(x => new ListRegionViewModel
            {
                Id = x.Id,
                Name = x.Name
            })
            .FirstOrDefaultAsync(x => x.Id == id);

        if (region == null)
            throw new InvalidRegionException();

        return region;
    }

    public async Task<ListRegionViewModel> GetByNameAsync(string name)
    {
        var region = await _context.Regions
            .AsNoTracking()
            .Select(x => new ListRegionViewModel
            {
                Id = x.Id,
                Name = x.Name
            })
            .FirstOrDefaultAsync(x => x.Name == name);

        if (region == null)
            throw new InvalidRegionException();

        return region;
    }

    public async Task<Region> UpdateByIdAsync(int id, EditorRegionViewModel model)
    {
        var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
        if (region == null)
            throw new InvalidRegionException();

        region.Name = model.Name;
        region.LastUpdate = DateTime.UtcNow;

        _context.Regions.Update(region);
        await _context.SaveChangesAsync();

        return region;
    }

    public async Task<Region> UpdateByNameAsync(string name, EditorRegionViewModel model)
    {
        var region = await _context.Regions.FirstOrDefaultAsync(x => x.Name == name);
        if (region == null)
            throw new InvalidRegionException();

        region.Name = model.Name;
        region.LastUpdate = DateTime.UtcNow;

        _context.Regions.Update(region);
        await _context.SaveChangesAsync();

        return region;
    }
    public async Task<Region> DeleteByIdAsync(int id)
    {
        var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
        if (region == null)
            throw new InvalidRegionException();

        _context.Regions.Remove(region);
        await _context.SaveChangesAsync();

        return region;
    }

    public async Task<Region> DeleteByNameAsync(string name)
    {
        var region = await _context.Regions.FirstOrDefaultAsync(x => x.Name == name);
        if (region == null)
            throw new InvalidRegionException();

        _context.Regions.Remove(region);
        await _context.SaveChangesAsync();

        return region;
    }
}