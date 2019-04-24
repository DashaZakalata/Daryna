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

namespace UnitTests
{
    public class CustomerRepository_UnitTests
    {
        CustomerRepository target;
        Mock<ShopContext> mockDbContext;

        public CustomerRepository_UnitTests()
        {
            mockDbContext = new Mock<ShopContext>();

            target = new CustomerRepository(mockDbContext.Object);
        }

        [Fact]
        public void Get_When_CustomerCollectionIsEmpty_Then_ShouldReturnNull()
        {
            // Arrange
            const int id = 100500;

            mockDbContext
                .Setup(c => c.Customers)
                .Returns(new MockDbSet<Customer>());

            // Act
            var result = target.Get(id);

            // Assert
            result.Should().Be(default(Customer));
        }
    }
}
