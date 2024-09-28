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
    public class DeletePersonAddressTest
    {
        [Fact]
        public async Task ExecuteAsync_ShouldReturnDeletePersonAddress_WhenAddressIsValidAsync()
        {
            // Arrange
            var mockPersonAddressRepository = new Mock<IPersonAddressRepository>();
            var deletePersonAddress = new DeletePersonAddress(mockPersonAddressRepository.Object);
            var idToDelete = "1-A";

            // Act
            await deletePersonAddress.ExecuteAsync(idToDelete);

            // Assert
            mockPersonAddressRepository.Verify(repo => repo.DeleteAsync(idToDelete), Times.Once,
            "DeleteAsync should be called once with the correct ID.");
        }
    }
}