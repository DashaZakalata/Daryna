using ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using DomainServices.Repositories;
using DomainCore;
using FluentAssertions;
using UnitTests.Generators;

namespace UnitTests.BO
{
    public class GoodBO_UnitTests
    {
        Mock<IGoodRepository> mockRepository;
        public GoodBO_UnitTests()
        {
            mockRepository = new Mock<IGoodRepository>();

        }

        [Fact]
        public void GetGoods_When_GoodsNotFound_Then_ShouldReturnEmptyCollection()
        {
            // Arrange
            mockRepository.Setup(c => c.GetAll())
                .Returns(new List<Good>());

            var target = new GoodBO(mockRepository.Object);

            // Act
            var result = target.GetGoods();

            // Assert
            result.Should().BeAssignableTo<IEnumerable<Good>>();
            result.Should().BeEmpty();
        }

        [Fact]
        public void GetGoods_When_GoodsWasFound_Then_ShouldReturnCollectionOfGoods()
        {
            // Arrange
            const int goodsCount = 2;
            var good = GeneratorFactory.Create<Good>().Object;

            mockRepository.Setup(c => c.GetAll())
                .Returns(new List<Good>()
                {
                    good,
                    good
                });

            var target = new GoodBO(mockRepository.Object);

            // Act
            var result = target.GetGoods();

            // Assert
            result.Should().BeAssignableTo<IEnumerable<Good>>();
            result.Should().HaveCount(goodsCount);
        }
    }
}
