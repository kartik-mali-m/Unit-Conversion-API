namespace UnitConversionAPI.Exceptions;

public class InvalidUnitException : Exception
{
    public InvalidUnitException(string message)
        : base(message)
    {
    }
}