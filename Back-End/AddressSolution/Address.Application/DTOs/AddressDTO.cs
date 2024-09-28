using System.ComponentModel.DataAnnotations;

namespace AddressService.Application.DTOs
{
    public class AddressDTO
    {
        [Required(ErrorMessage = "Street is required.")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "Zip Code is required.")]
        public string ZipCode { get; set; } = string.Empty;
    }
}