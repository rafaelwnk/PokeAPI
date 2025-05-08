using PokeAPI.ViewModels.Types;

namespace PokeAPI.Interfaces;

public interface ITypeService
{
    Task<Models.Type> CreateAsync(EditorTypeViewModel model);
    Task<List<ListTypeViewModel>> GetAllAsync();
    Task<ListTypeViewModel> GetByIdAsync(int id);
    Task<ListTypeViewModel> GetByNameAsync(string name);
    Task<Models.Type> UpdateByIdAsync(int id, EditorTypeViewModel model);
    Task<Models.Type> UpdateByNameAsync(string name, EditorTypeViewModel model);
    Task<Models.Type> DeleteByIdAsync(int id);
    Task<Models.Type> DeleteByNameAsync(string name);
}