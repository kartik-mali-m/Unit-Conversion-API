using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitConversionAPI.Models.Request;
using UnitConversionAPI.Service.Interfaces;

namespace UnitConversionAPI.Controllers
{
    /// Provides endpoints for converting values between measurement units.
    
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _conversionService;

        public ConversionController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        /// Converts a value from one unit to another.
        /// returns Converted value.

        [HttpPost]
        public IActionResult Convert(ConversionRequest request)
        {
            var result = _conversionService.Convert(request);

            return Ok(result);
        }
    }
}
