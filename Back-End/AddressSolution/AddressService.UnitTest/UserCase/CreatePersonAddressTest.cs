using AddressService.Application.AutoMapper;
using AddressService.Application.DTOs;
using AddressService.Application.UseCases;
using AddressService.Domain.Entities;
using AddressService.Domain.Interfaces.Repositories;
using AutoMapper;
using Microsoft.OpenApi.Any;
using Moq;

namespace AddressService.UnitTest.UserCase
{
    public class CreatePersonAddressTest
    {
        [Fact]
        public async Task ExecuteAsync_ShouldReturnCreatedPersonAddress_WhenAddressIsValidAsync()
        {
            // Arrange
            var personAddressDto = new PersonAddressDTO
            {
                Name = new NameDTO
                {
                    FirstName = "Peter",
                    LastName = "Parker"
                },
                Address = new AddressDTO
                {
                    Street = "2024 New Street",
                    City = "Orlando",
                    State = "Florida",
                    ZipCode = "12345"
                }
            };

            var personAddress = new PersonAddress
            {
                Id = "1-A",
                Name = new Name
                {
                    FirstName = "Peter",
                    LastName = "Parker"
                },
                Address = new Address
                {
                    Street = "2024 New Street",
                    City = "Orlando",
                    State = "Florida",
                    ZipCode = "12345"
                }
            };

            var result = new PersonAddress();

            var mockPersonAddressRepository = new Mock<IPersonAddressRepository>();
            mockPersonAddressRepository
                .Setup(repo => repo.AddAsync(It.IsAny<PersonAddress>()))
                .Callback<PersonAddress>(addr => result = addr);

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PersonAddressProfile());
            });

            var mapper = mapperConfig.CreateMapper();

            var createPersonAddress = new CreatePersonAddress(mockPersonAddressRepository.Object, mapper);
            
            // Act
            await createPersonAddress.ExecuteAsync(personAddressDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(personAddress.Name.FirstName, result.Name.FirstName);
            Assert.Equal(personAddress.Name.LastName, result.Name.LastName);
            Assert.Equal(personAddress.Address.Street, result.Address.Street);
            Assert.Equal(personAddress.Address.City, result.Address.City);
            Assert.Equal(personAddress.Address.State, result.Address.State);
            Assert.Equal(personAddress.Address.ZipCode, result.Address.ZipCode);
            mockPersonAddressRepository.Verify(repo => repo.AddAsync(It.IsAny<PersonAddress>()), Times.Once,
                "AddAsync should be called exactly once.");
        }
    }
}