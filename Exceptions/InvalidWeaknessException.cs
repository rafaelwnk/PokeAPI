namespace PokeAPI.Exceptions;

public class InvalidWeaknessException : Exception
{
    public InvalidWeaknessException() : base("Fraqueza(s) não encontrada(s).") { }
}