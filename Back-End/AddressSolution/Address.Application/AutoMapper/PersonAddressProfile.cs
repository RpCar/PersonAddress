using AutoMapper;
using AddressService.Domain.Entities;
using AddressService.Application.DTOs;

namespace AddressService.Application.AutoMapper
{
    public class PersonAddressProfile : Profile
    {
        public PersonAddressProfile()
        {
            CreateMap<PersonAddressDTO, PersonAddress>().ReverseMap();
            CreateMap<AddressDTO, Address>().ReverseMap();
            CreateMap<NameDTO, Name>().ReverseMap();
        }
    }
}
