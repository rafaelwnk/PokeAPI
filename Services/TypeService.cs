using Microsoft.EntityFrameworkCore;
using PokeAPI.Data;
using PokeAPI.Exceptions;
using PokeAPI.Interfaces;
using PokeAPI.ViewModels.Types;

namespace PokeAPI.Services;

public class TypeService : ITypeService
{
    private readonly DataContext _context;

    public TypeService(DataContext context)
    {
        _context = context;
    }

    public async Task<Models.Type> CreateAsync(EditorTypeViewModel model)
    {
        var type = new Models.Type
        {
            Name = model.Name
        };

        await _context.Types.AddAsync(type);
        await _context.SaveChangesAsync();

        return type;
    }

    public async Task<List<ListTypeViewModel>> GetAllAsync()
    {
        var types = await _context.Types
                .AsNoTracking()
                .Select(x => new ListTypeViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .OrderBy(x => x.Id)
                .ToListAsync();

        return types;
    }

    public async Task<ListTypeViewModel> GetByIdAsync(int id)
    {
        var type = await _context.Types
            .AsNoTracking()
            .Select(x => new ListTypeViewModel
            {
                Id = x.Id,
                Name = x.Name
            })
            .FirstOrDefaultAsync(x => x.Id == id);

        if (type == null)
            throw new InvalidTypeException();

        return type;
    }

    public async Task<ListTypeViewModel> GetByNameAsync(string name)
    {
        var type = await _context.Types
            .AsNoTracking()
            .Select(x => new ListTypeViewModel
            {
                Id = x.Id,
                Name = x.Name
            })
            .FirstOrDefaultAsync(x => x.Name == name);

        if (type == null)
            throw new InvalidTypeException();

        return type;
    }

    public async Task<Models.Type> UpdateByIdAsync(int id, EditorTypeViewModel model)
    {
        var type = await _context.Types.FirstOrDefaultAsync(x => x.Id == id);
        if (type == null)
            throw new InvalidTypeException();

        type.Name = model.Name;
        type.LastUpdate = DateTime.UtcNow;

        _context.Types.Update(type);
        await _context.SaveChangesAsync();

        return type;
    }

    public async Task<Models.Type> UpdateByNameAsync(string name, EditorTypeViewModel model)
    {
        var type = await _context.Types.FirstOrDefaultAsync(x => x.Name == name);
        if (type == null)
            throw new InvalidTypeException();

        type.Name = model.Name;
        type.LastUpdate = DateTime.UtcNow;

        _context.Types.Update(type);
        await _context.SaveChangesAsync();

        return type;
    }
    public async Task<Models.Type> DeleteByIdAsync(int id)
    {
        var type = await _context.Types.FirstOrDefaultAsync(x => x.Id == id);
        if (type == null)
            throw new InvalidTypeException();

        _context.Types.Remove(type);
        await _context.SaveChangesAsync();

        return type;
    }

    public async Task<Models.Type> DeleteByNameAsync(string name)
    {
        var type = await _context.Types.FirstOrDefaultAsync(x => x.Name == name);
        if (type == null)
            throw new InvalidTypeException();

        _context.Types.Remove(type);
        await _context.SaveChangesAsync();

        return type;
    }
}