using AddressService.Domain.Entities;

namespace AddressService.Domain.Interfaces.Repositories
{
    public interface IPersonAddressRepository
    {
        Task<PersonAddress> GetByIdAsync(string id);
        Task<IEnumerable<PersonAddress>> GetAllAsync();
        Task AddAsync(PersonAddress address);
        Task UpdateAsync(PersonAddress address);
        Task DeleteAsync(string id);
    }
}
