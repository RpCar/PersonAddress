using AddressService.Application.DTOs;

namespace AddressService.Application.Interfaces
{
    public interface ICreatePersonAddress
    {
        Task ExecuteAsync(PersonAddressDTO dto);
    }
}
