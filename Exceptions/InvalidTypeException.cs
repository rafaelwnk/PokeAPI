namespace PokeAPI.Exceptions;

public class InvalidTypeException : Exception
{
    public InvalidTypeException() : base("Tipo(s) não encontrado(s).") { }
}