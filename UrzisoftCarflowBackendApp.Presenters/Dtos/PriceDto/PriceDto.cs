using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.PriceDto
{
    public class PriceDto
    {
        [Required]
        public double Value { get; set; }

        [Required]
        public string Fuel { get; set; }

        [Required]
        public string Date { get; set; }
    }
}
