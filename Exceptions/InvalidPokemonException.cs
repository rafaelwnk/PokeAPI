namespace PokeAPI.Exceptions;

public class InvalidPokemonException : Exception
{
    public InvalidPokemonException() : base("Pokémon não encontrado.") { }
}