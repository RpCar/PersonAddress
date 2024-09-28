using AddressService.Application.Interfaces;
using AddressService.Domain.Entities;
using AddressService.Domain.Interfaces.Repositories;

namespace AddressService.Application.UseCases
{
    public class ListPersonAddress : IListPersonAddress
    {
        private readonly IPersonAddressRepository _personAddressRepository;

        public ListPersonAddress(IPersonAddressRepository personAddressRepository)
        {
            _personAddressRepository = personAddressRepository;
        }

        public async Task<IEnumerable<PersonAddress>> ExecuteAsync()
        {
            return await _personAddressRepository.GetAllAsync();
        }
    }
}
