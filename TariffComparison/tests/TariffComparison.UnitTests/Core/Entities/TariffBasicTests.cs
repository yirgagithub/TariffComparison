using TariffComparison.Core.Entities;
using FluentAssertions;
using Xunit;

namespace TariffComparison.UnitTests.Core.Entities
{
    public class TariffBasicTest
    {

        [Theory]
        [InlineData(3500, 830)]
        [InlineData(4500, 1050)]
        [InlineData(6000, 1380)]
        public void TariffBasic_CalculatesAnnualCost_ReturnsCorrectValue(double consumption, double expected)
        {
            // Arrange
            var TariffBasic = new BasicTariff(consumption);

            // Act
            var result = TariffBasic.AnnualCost;

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(3500, 800)]
        [InlineData(4500, 950)]
        [InlineData(6000, 1400)]
        public void TariffBasic_CalculatesAnnualCost_ReturnsInCorrectValue(double consumption, double expected)
        {
            // Arrange
            var TariffBasic = new BasicTariff(consumption);

            // Act
            var result = TariffBasic.AnnualCost;

            // Assert
            result.Should().NotBe(expected);
        }

        [Fact]
        public void NamePropertyIsSet()
        {
            // Arrange
            var TariffBasic = new BasicTariff();

            // Act
            var result = TariffBasic.Name;

            // Assert
            result.Should().Be("basic electricity tariff");
        }
    }
}
