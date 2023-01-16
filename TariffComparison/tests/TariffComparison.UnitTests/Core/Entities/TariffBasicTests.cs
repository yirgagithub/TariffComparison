using TariffComparison.Core.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TariffComparison.UnitTests.Core.Entities
{
    public class ProductBTest
    {

        [Theory]
        [InlineData(4000, 800)]
        [InlineData(900, 8864)]
        [InlineData(8000, 1600)]
        [InlineData(7845, 456)]
        public void ProductB_CalculatesAnnualCost_ReturnsCorrectValue(double consumption, double expected)
        {
            // Arrange
            var productB = new PackageTariff { AnnualCost = consumption };

            // Act
            var result = productB.AnnualCost;

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(4500, 800)]
        [InlineData(900, 8864)]
        [InlineData(8000, 1600)]
        [InlineData(7845, 456)]
        public void ProductB_CalculatesAnnualCost_ReturnsInCorrectValue(double consumption, double expected)
        {
            // Arrange
            var productB = new PackageTariff { AnnualCost = consumption };

            // Act
            var result = productB.AnnualCost;

            // Assert
            result.Should().NotBe(expected);
        }

        [Fact]
        public void ProductB_NamePropertyIsSet()
        {
            // Arrange
            var productB = new PackageTariff();

            // Act
            var result = productB.Name;

            // Assert
            result.Should().Be("Packaged tariff");
        }
    }
}
