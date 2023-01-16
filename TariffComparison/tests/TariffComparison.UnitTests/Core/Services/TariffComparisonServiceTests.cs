using TariffComparison.Core.Entities;
using TariffComparison.Core.Interfaces;
using TariffComparison.Core.Services;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TariffComparison.UnitTests.Core.Services
{
    public class TariffComparisonServiceTests
    {
        [Fact]
        public void GetProducts_Should_Return_List()
        {
            // Arrange
            var mockComparison = new Mock<ITariffComparison>();
            mockComparison.Setup(x => x.CompareTariffs(It.IsAny<double>()))
                .Returns(new List<Tariff> { new BasicTariff(), new PackageTariff() });
          
            var service = new TariffComparisonService(mockComparison.Object);
            var consumption = 1000.0;

            // Act
            var products = service.GetProducts(consumption);

            // Assert
            mockComparison.Verify(x => x.CompareTariffs(consumption), Times.Once);
            products.Should().BeOfType<List<Tariff>>();
            
        }


    }
}
