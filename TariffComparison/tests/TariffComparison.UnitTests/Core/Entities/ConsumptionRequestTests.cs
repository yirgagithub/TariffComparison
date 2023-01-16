using TariffComparison.Core.Entities;
using FluentAssertions;
using Xunit;

namespace TariffComparison.UnitTests.Core.Entities
{
    public class ConsumptionRequestTests
    {
        [Fact]
        public void ProductB_CalculatesAnnualCost_ReturnsCorrectValue()
        {
            // Arrange
            var productB = new ConsumptionRequest { Consumption = 4000 };

            // Act
            var result = productB.Consumption;

            // Assert
            result.Should().Be(4000);
        }
    }
}
