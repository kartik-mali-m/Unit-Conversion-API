using UnitConversionAPI.Models.Request;
using UnitConversionAPI.Models.Response;

namespace UnitConversionAPI.Service.Interfaces
{
    public interface IConversionService
    {
        ConversionResponse Convert(ConversionRequest request);
    }
}
