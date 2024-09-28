using AddressService.Application.Interfaces;
using AddressService.Domain.Interfaces.Repositories;

namespace AddressService.Application.UseCases
{
    public class DeletePersonAddress : IDeletePersonAddress
    {
        private readonly IPersonAddressRepository _personAddressRepository;

        public DeletePersonAddress(IPersonAddressRepository personAddressRepository)
        {
            _personAddressRepository = personAddressRepository;
        }

        public async Task ExecuteAsync(string id)
        {
            await _personAddressRepository.DeleteAsync(id);
        }
    }
}
