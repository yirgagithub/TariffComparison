using FluentAssertions;
using TariffComparison.Core.Entities;
using Xunit;

namespace TariffComparison.UnitTests.Core.Entities
{
    public class TariffTests
    {
 
        [Fact]
        public void ToString_Should_Return_ExpectedStringResult()
        {
            // Arrange
            var tariff = new BasicTariff(100);

            // Act
            var result = tariff.ToString();

            // Assert
            var expectedResult = "The Annual Tarrif for basic electricity tariff with consumtion 100 is 82";
            result.Should().Be(expectedResult);
        }
    }
    
}
