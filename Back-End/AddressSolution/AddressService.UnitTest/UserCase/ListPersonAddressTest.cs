using AddressService.Application.UseCases;
using AddressService.Domain.Entities;
using AddressService.Domain.Interfaces.Repositories;
using Moq;

namespace AddressService.UnitTest.UserCase
{
    public class ListPersonAddressTest
    {
        [Fact]
        public async Task ExecuteAsync_ShouldReturnListOfPersonAddresses()
        {
            // Arrange
            var mockPersonAddressRepository = new Mock<IPersonAddressRepository>();
            var listPersonAddress = new ListPersonAddress(mockPersonAddressRepository.Object);

            var personAddressList = new List<PersonAddress>
            {
                new PersonAddress
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
                },
                new PersonAddress
                {
                    Id = "2-B",
                    Name = new Name
                    {
                        FirstName = "Mary",
                        LastName = "Jane"
                    },
                    Address = new Address
                    {
                        Street = "1500 Vera Cruz",
                        City = "Another City",
                        State = "Another State",
                        ZipCode = "54321"
                    }
                }
            };

            mockPersonAddressRepository
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(personAddressList);

            // Act
            var result = await listPersonAddress.ExecuteAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Collection(result,
                item =>
                {
                    Assert.Equal("1-A", item.Id);
                    Assert.Equal("Peter", item.Name.FirstName);
                    Assert.Equal("Parker", item.Name.LastName);
                    Assert.Equal("2024 New Street", item.Address.Street);
                },
                item =>
                {
                    Assert.Equal("2-B", item.Id);
                    Assert.Equal("Mary", item.Name.FirstName);
                    Assert.Equal("Jane", item.Name.LastName);
                    Assert.Equal("1500 Vera Cruz", item.Address.Street);
                });
            mockPersonAddressRepository.Verify(repo => repo.GetAllAsync(), Times.Once,
                "GetAllAsync should be called exactly once.");
        }

        [Fact]
        public async Task ExecuteAsync_ShouldReturnEmptyList_WhenNoPersonAddressesExist()
        {
            // Arrange
            var mockPersonAddressRepository = new Mock<IPersonAddressRepository>();
            var listPersonAddress = new ListPersonAddress(mockPersonAddressRepository.Object);

            mockPersonAddressRepository
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new List<PersonAddress>());

            // Act
            var result = await listPersonAddress.ExecuteAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}