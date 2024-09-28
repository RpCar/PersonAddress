using AddressService.Application.DTOs;
using AddressService.Application.Interfaces;
using AddressService.Domain.Entities;
using AddressService.Domain.Interfaces.Repositories;
using AutoMapper;

namespace AddressService.Application.UseCases
{
    public class CreatePersonAddress : ICreatePersonAddress
    {
        private readonly IPersonAddressRepository _personAddressRepository;
        private readonly IMapper _mapper;

        public CreatePersonAddress(IPersonAddressRepository personAddressRepository, IMapper mapper)
        {
            _personAddressRepository = personAddressRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(PersonAddressDTO dto)
        {
            PersonAddress address = new();
            _mapper.Map(dto, address);
            await _personAddressRepository.AddAsync(address);
        }
    }
}
