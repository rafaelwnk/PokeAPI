namespace PokeAPI.Exceptions;

public class InvalidRegionException : Exception
{
    public InvalidRegionException() : base("Região não encontrada.") { }
}