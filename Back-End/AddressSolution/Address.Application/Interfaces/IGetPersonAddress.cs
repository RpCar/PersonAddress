using AddressService.Domain.Entities;

namespace AddressService.Application.Interfaces
{
    public interface IGetPersonAddress
    {
        Task<PersonAddress> ExecuteAsync(string id);
    }
}