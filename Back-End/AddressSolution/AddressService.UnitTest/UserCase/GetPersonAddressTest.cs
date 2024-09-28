using AddressService.Application.AutoMapper;
using AddressService.Application.DTOs;
using AddressService.Application.Interfaces;
using AddressService.Application.UseCases;
using AddressService.Domain.Entities;
using AddressService.Domain.Interfaces.Repositories;
using AutoMapper;
using Moq;

namespace AddressService.UnitTest.UserCase
{
    public class GetPersonAddressTest
    {
        [Fact]
        public async Task ExecuteAsync_ShouldReturnGetPersonAddress_WhenAddressIsValidAsync()
        {
            // Arrange
            var mockPersonAddressRepository = new Mock<IPersonAddressRepository>();
            var getPersonAddress = new GetPersonAddress(mockPersonAddressRepository.Object);
            var validId = "1-A";

            var expectedPersonAddress = new PersonAddress
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

            mockPersonAddressRepository
                .Setup(repo => repo.GetByIdAsync(validId))
                .ReturnsAsync(expectedPersonAddress);

            // Act
            var result = await getPersonAddress.ExecuteAsync(validId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPersonAddress.Id, result.Id);
            Assert.Equal(expectedPersonAddress.Name.FirstName, result.Name.FirstName);
            Assert.Equal(expectedPersonAddress.Name.LastName, result.Name.LastName);
            Assert.Equal(expectedPersonAddress.Address.Street, result.Address.Street);
            Assert.Equal(expectedPersonAddress.Address.City, result.Address.City);
            Assert.Equal(expectedPersonAddress.Address.State, result.Address.State);
            Assert.Equal(expectedPersonAddress.Address.ZipCode, result.Address.ZipCode);
            mockPersonAddressRepository.Verify(repo => repo.GetByIdAsync(validId), Times.Once,
                "GetByIdAsync should be called exactly once.");
        }

        [Fact]
        public async Task ExecuteAsync_ShouldReturnGetPersonAddress_WhenEntityDoesNotExistAsync()
        {
            // Arrange
            var mockPersonAddressRepository = new Mock<IPersonAddressRepository>();
            var getPersonAddress = new GetPersonAddress(mockPersonAddressRepository.Object);
            var nonExistentId = "1-A";

            // Act && Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => getPersonAddress.ExecuteAsync(nonExistentId));
        }
    }
}