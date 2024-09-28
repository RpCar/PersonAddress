using System.ComponentModel.DataAnnotations;

namespace AddressService.Application.DTOs
{
    public class NameDTO
    {
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; } = string.Empty;
    }
}