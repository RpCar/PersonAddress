using AddressService.Application.Interfaces;
using AddressService.Domain.Entities;
using AddressService.Domain.Interfaces.Repositories;

namespace AddressService.Application.UseCases
{
    public class GetPersonAddress : IGetPersonAddress
    {
        private readonly IPersonAddressRepository _personAddressRepository;

        public GetPersonAddress(IPersonAddressRepository personAddressRepository)
        {
            _personAddressRepository = personAddressRepository;
        }

        public async Task<PersonAddress> ExecuteAsync(string id)
        {
            var personAddress = await _personAddressRepository.GetByIdAsync(id);

            if (personAddress == null)
                throw new InvalidOperationException("PersonAddress not found");

            return personAddress;
        }
    }
}
