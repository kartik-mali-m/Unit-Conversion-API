using UnitConversionAPI.Exceptions;
using UnitConversionAPI.Models.Request;
using UnitConversionAPI.Models.Response;
using UnitConversionAPI.Service.Interfaces;

namespace UnitConversionAPI.Service.Implementations;

public class ConversionService : IConversionService
{
    public ConversionResponse Convert(ConversionRequest request)
    {
        double result = 0;

        // Temperature
        if (request.Category.Equals("Temperature", StringComparison.OrdinalIgnoreCase))
        {
            if (request.FromUnit.Equals("Celsius", StringComparison.OrdinalIgnoreCase)
                && request.ToUnit.Equals("Fahrenheit", StringComparison.OrdinalIgnoreCase))
            {
                result = (request.Value * 9 / 5) + 32;
            }
            else if (request.FromUnit.Equals("Fahrenheit", StringComparison.OrdinalIgnoreCase)
                     && request.ToUnit.Equals("Celsius", StringComparison.OrdinalIgnoreCase))
            {
                result = (request.Value - 32) * 5 / 9;
            }
            else
            {
                throw new InvalidUnitException("Unsupported temperature conversion.");
            }
        }

        // Length
        else if (request.Category.Equals("Length", StringComparison.OrdinalIgnoreCase))
        {
            if (request.FromUnit.Equals("Meter", StringComparison.OrdinalIgnoreCase)
                && request.ToUnit.Equals("Feet", StringComparison.OrdinalIgnoreCase))
            {
                result = request.Value * 3.28084;
            }
            else if (request.FromUnit.Equals("Feet", StringComparison.OrdinalIgnoreCase)
                     && request.ToUnit.Equals("Meter", StringComparison.OrdinalIgnoreCase))
            {
                result = request.Value / 3.28084;
            }
            else
            {
                throw new InvalidUnitException("Unsupported length conversion.");
            }
        }

        // Weight
        else if (request.Category.Equals("Weight", StringComparison.OrdinalIgnoreCase))
        {
            if (request.FromUnit.Equals("Kilogram", StringComparison.OrdinalIgnoreCase)
                && request.ToUnit.Equals("Pound", StringComparison.OrdinalIgnoreCase))
            {
                result = request.Value * 2.20462;
            }
            else if (request.FromUnit.Equals("Pound", StringComparison.OrdinalIgnoreCase)
                     && request.ToUnit.Equals("Kilogram", StringComparison.OrdinalIgnoreCase))
            {
                result = request.Value / 2.20462;
            }
            else
            {
                throw new InvalidUnitException("Unsupported weight conversion.");
            }
        }
        else
        {
            throw new InvalidUnitException("Invalid category.");
        }

        return new ConversionResponse
        {
            Category = request.Category,
            FromUnit = request.FromUnit,
            ToUnit = request.ToUnit,
            InputValue = request.Value,
            ConvertedValue = result
        };
    }
}