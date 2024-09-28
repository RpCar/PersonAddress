using AddressService.Application.DTOs;
using AddressService.Application.Interfaces;
using AddressService.Domain.Entities;
using AddressService.Domain.Interfaces.Repositories;
using AutoMapper;
using System.Net;

namespace AddressService.Application.UseCases
{
    public class UpdatePersonAddress : IUpdatePersonAddress
    {
        private readonly IPersonAddressRepository _personAddressRepository;
        private readonly IMapper _mapper;

        public UpdatePersonAddress(IPersonAddressRepository personAddressRepository, IMapper mapper)
        {
            _personAddressRepository = personAddressRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(string id, PersonAddressDTO dto)
        {
            var existingAddress = await _personAddressRepository.GetByIdAsync(id);

            if (existingAddress == null)
            {
                throw new KeyNotFoundException($"Address with ID {id} was not found.");
            }

            _mapper.Map(dto, existingAddress);
            await _personAddressRepository.UpdateAsync(existingAddress);
        }
    }
}
