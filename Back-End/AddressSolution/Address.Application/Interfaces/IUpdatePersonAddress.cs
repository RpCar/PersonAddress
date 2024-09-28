using AddressService.Application.DTOs;

namespace AddressService.Application.Interfaces
{
    public interface IUpdatePersonAddress
    {
        Task ExecuteAsync(string id, PersonAddressDTO dto);
    }
}
