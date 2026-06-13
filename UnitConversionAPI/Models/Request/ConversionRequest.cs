using System.ComponentModel.DataAnnotations;

namespace UnitConversionAPI.Models.Request
{
    public class ConversionRequest
    {
        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public string FromUnit { get; set; } = string.Empty;

        [Required]
        public string ToUnit { get; set; } = string.Empty;

        [Range(0.0001, double.MaxValue)]
        public double Value { get; set; }
    }
}
