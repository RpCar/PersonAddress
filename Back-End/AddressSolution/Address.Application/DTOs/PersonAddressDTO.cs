using System.ComponentModel.DataAnnotations;

namespace AddressService.Application.DTOs
{
    public class PersonAddressDTO
    {
        [Required]
        public AddressDTO Address { get; set; } = new();
        [Required]
        public NameDTO Name { get; set; } = new();
    }
}
