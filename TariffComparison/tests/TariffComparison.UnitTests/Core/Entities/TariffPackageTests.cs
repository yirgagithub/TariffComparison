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
    public class ProductATest
    {

        [Fact]
        public void ProductA_CalculatesAnnualCost_ReturnsCorrectValue()
        {
            // Arrange
            var productA = new BasicTariff { AnnualCost = 6000 };

            // Act
            var result = productA.AnnualCost;

            // Assert
            result.Should().Be(1380);
        }

        [Fact]
        public void ProductA_CalculatesAnnualCost_ReturnsInCorrectValue()
        {
            // Arrange
            var productA = new BasicTariff { AnnualCost = 6000 };

            // Act
            var result = productA.AnnualCost;

            // Assert
            result.Should().NotBe(380);
        }

        [Fact]
        public void ProductA_NamePropertyIsSet()
        {
            // Arrange
            var productA = new BasicTariff();

            // Act
            var result = productA.Name;

            // Assert
            result.Should().Be("basic electricity tariff");
        }
    }
}
