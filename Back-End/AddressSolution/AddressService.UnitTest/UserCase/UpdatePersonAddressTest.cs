using AddressService.Application.AutoMapper;
using AddressService.Application.DTOs;
using AddressService.Application.Interfaces;
using AddressService.Application.UseCases;
using AddressService.Domain.Entities;
using AddressService.Domain.Interfaces.Repositories;
using AutoMapper;
using Microsoft.OpenApi.Any;
using Moq;

namespace AddressService.UnitTest.UserCase
{
    public class UpdatePersonAddressTest
    {
        [Fact]
        public async Task ExecuteAsync_ShouldUpdatePersonAddress_WhenIdIsValid()
        {
            // Arrange
            var mockPersonAddressRepository = new Mock<IPersonAddressRepository>();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new PersonAddressProfile())); 
            var mapper = mapperConfig.CreateMapper();
            var updatePersonAddress = new UpdatePersonAddress(mockPersonAddressRepository.Object, mapper);
            var validId = "1-A";

            var existingPersonAddress = new PersonAddress
            {
                Id = validId,
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

            var updatedDto = new PersonAddressDTO
            {
                Name = new NameDTO
                {
                    FirstName = "Mary",
                    LastName = "Jane"
                },
                Address = new AddressDTO
                {
                    Street = "1500 Vera Cruz",
                    City = "Springfield",
                    State = "Oregon",
                    ZipCode = "54321"
                }
            };

            mockPersonAddressRepository
                .Setup(repo => repo.GetByIdAsync(validId))
                .ReturnsAsync(existingPersonAddress);

            // Act
            await updatePersonAddress.ExecuteAsync(validId, updatedDto);

            // Assert
            mockPersonAddressRepository.Verify(repo => repo.UpdateAsync(It.Is<PersonAddress>(p =>
                p.Id == validId &&
                p.Name.FirstName == updatedDto.Name.FirstName &&
                p.Name.LastName == updatedDto.Name.LastName &&
                p.Address.Street == updatedDto.Address.Street &&
                p.Address.City == updatedDto.Address.City &&
                p.Address.State == updatedDto.Address.State &&
                p.Address.ZipCode == updatedDto.Address.ZipCode
            )), Times.Once);
            mockPersonAddressRepository.Verify(repo => repo.GetByIdAsync(validId), Times.Once);
            mockPersonAddressRepository.Verify(repo => repo.UpdateAsync(It.IsAny<PersonAddress>()), Times.Once);
        }

        [Fact]
        public async Task ExecuteAsync_ShouldThrowKeyNotFoundException_WhenEntityDoesNotExist()
        {
            // Arrange
            var mockPersonAddressRepository = new Mock<IPersonAddressRepository>();
            var mapper = new Mock<IMapper>(); 
            var updatePersonAddress = new UpdatePersonAddress(mockPersonAddressRepository.Object, mapper.Object);
            var nonExistentId = "2-B";

            var updatedDto = new PersonAddressDTO
            {
                Name = new NameDTO
                {
                    FirstName = "Mary",
                    LastName = "Jane"
                },
                Address = new AddressDTO
                {
                    Street = "1500 Vera Cruz",
                    City = "Springfield",
                    State = "Oregon",
                    ZipCode = "54321"
                }
            };
            #pragma warning disable CS8600, CS8620
            mockPersonAddressRepository
                .Setup(repo => repo.GetByIdAsync(nonExistentId))
                .ReturnsAsync(default(PersonAddress));
            #pragma warning restore CS8600, CS8620

            // Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => updatePersonAddress.ExecuteAsync(nonExistentId, updatedDto));
        }
    }
}