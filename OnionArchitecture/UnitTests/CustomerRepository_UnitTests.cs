using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using DAL;
using UnitTests.Mock;
using DomainCore;
using FluentAssertions;
using UnitTests.Generators;

namespace UnitTests
{
    public class CustomerRepository_UnitTests
    {
        private readonly Mock<ShopContext> mockDbContext = new Mock<ShopContext>();
        private readonly MockSetup mockSetup = new MockSetup();

        private CustomerRepository target;
        public CustomerRepository_UnitTests()
        {
        }

        [Fact]
        public void Get_When_CustomerCollectionIsEmpty_Then_ShouldReturnNull()
        {
            // Arrange
            const int id = 100500;

            mockDbContext
                .Setup(c => c.Customers)
                .Returns(mockSetup.GetMockedDBSet<Customer>().Object);
            mockDbContext.Setup(c => c.Set<Customer>()).Returns(mockDbContext.Object.Customers);

            target = new CustomerRepository(mockDbContext.Object);

            // Act
            var result = target.Get(id);

            // Assert
            result.Should().Be(default(Customer));
        }

        [Fact]
        public void Get_When_CustomerWasFound_Then_ShouldReturnCustomer()
        {
            // Arrange
            const int id = 100500;

            var customer = GeneratorFactory.Create<Customer>()
                .Set(c => c.Id = id)
                .Object;

            mockDbContext
                .Setup(c => c.Customers)
                .Returns(mockSetup.GetMockedDBSet(customer).Object);
            mockDbContext.Setup(c => c.Set<Customer>()).Returns(mockDbContext.Object.Customers);

            target = new CustomerRepository(mockDbContext.Object);

            // Act
            var result = target.Get(id);

            // Assert
            result.Should().Be(customer);
        }

        [Fact]
        public void Get_When_CustomerMoreThenOne_Then_ShouldThrowException()
        {
            // Arrange
            const int id = 100500;

            var customer = GeneratorFactory.Create<Customer>()
                .Set(c => c.Id = id)
                .Object;

            mockDbContext
                .Setup(c => c.Customers)
                .Returns(mockSetup.GetMockedDBSet(new List<Customer>() { customer, customer }).Object);
            mockDbContext.Setup(c => c.Set<Customer>()).Returns(mockDbContext.Object.Customers);

            target = new CustomerRepository(mockDbContext.Object);

            // Act
            Action action = () => target.Get(id);

            // Assert
            action.Should().Throw<InvalidOperationException>();
        }
    }
}
