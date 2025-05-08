using PokeAPI.Models;
using PokeAPI.ViewModels.Regions;

namespace PokeAPI.Interfaces;

public interface IRegionService
{
    Task<Region> CreateAsync(EditorRegionViewModel model);
    Task<List<ListRegionViewModel>> GetAllAsync();
    Task<ListRegionViewModel> GetByIdAsync(int id);
    Task<ListRegionViewModel> GetByNameAsync(string name);
    Task<Region> UpdateByIdAsync(int id, EditorRegionViewModel model);
    Task<Region> UpdateByNameAsync(string name, EditorRegionViewModel model);
    Task<Region> DeleteByIdAsync(int id);
    Task<Region> DeleteByNameAsync(string name);
}