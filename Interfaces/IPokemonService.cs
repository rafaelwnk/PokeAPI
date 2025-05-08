using PokeAPI.Models;
using PokeAPI.ViewModels.Pokemons;

namespace PokeAPI.Interfaces;

public interface IPokemonService
{
    Task<Pokemon> CreateAsync(EditorPokemonViewModel model);
    Task<List<ListPokemonViewModel>> GetAllAsync();
    Task<ListPokemonViewModel> GetByIdAsync(int id);
    Task<ListPokemonViewModel> GetByNameAsync(string name);
    Task<Pokemon> UpdateByIdAsync(int id, EditorPokemonViewModel model);
    Task<Pokemon> UpdateByNameAsync(string name, EditorPokemonViewModel model);
    Task<Pokemon> UpdatePatchByIdAsync(int id, UpdatePokemonViewModel model);
    Task<Pokemon> UpdatePatchByNameAsync(string name, UpdatePokemonViewModel model);
    Task<Pokemon> DeleteByIdAsync(int id);
    Task<Pokemon> DeleteByNameAsync(string name);
}