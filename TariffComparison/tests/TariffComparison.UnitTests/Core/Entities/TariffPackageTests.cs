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
    public class TariffPackageTest
    {

        [Theory]
        [InlineData(4000, 800)]
        [InlineData(3500, 800)]
        [InlineData(4500, 950)]
        [InlineData(6000, 1400)]
        public void CalculatesAnnualCost_Should_Return_CorrectValue(double consumption, double expected)
        {
            // Arrange
            var TariffPackage = new PackageTariff(consumption);

            // Act
            var result = TariffPackage.AnnualCost;

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(4500, 800)]
        [InlineData(900, 8864)]
        [InlineData(8000, 1600)]
        [InlineData(7845, 456)]
        public void CalculatesAnnualCost_Should_Return_InCorrectValue(double consumption, double expected)
        {
            // Arrange
            var TariffPackage = new PackageTariff(consumption);

            // Act
            var result = TariffPackage.AnnualCost;

            // Assert
            result.Should().NotBe(expected);
        }

        [Fact]
        public void NamePropertyIsSet()
        {
            // Arrange
            var TariffPackage = new PackageTariff();

            // Act
            var result = TariffPackage.Name;

            // Assert
            result.Should().Be("Packaged tariff");
        }
    }
}
