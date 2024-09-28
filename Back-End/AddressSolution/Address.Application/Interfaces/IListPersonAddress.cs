using AddressService.Domain.Entities;

namespace AddressService.Application.Interfaces
{
    public interface IListPersonAddress
    {
        Task<IEnumerable<PersonAddress>> ExecuteAsync();
    }
}
