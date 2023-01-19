using TariffComparison.Core.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace TariffComparison.UnitTests.Core.helpers
{
    public class TariffFactoryTest
    {
        [Theory]
        [InlineData(TariffType.Basic)]
        [InlineData(TariffType.Packaged)]
        public void CreateProducts_Should_Return_ValidTariff_When_Valid_TarrifType(TariffType type)
        {
            // Arrange
            var consumption = 1000.0;

            // Act
            var product = TariffFactory.CreateTariffs(type, consumption);

            // Assert
            if (type == TariffType.Basic)
                product.Should().BeOfType<BasicTariff>();
            else if (type == TariffType.Packaged)
                product.Should().BeOfType<PackageTariff>();
        }

        [Fact]
        public void CreateProducts_Should_Throw_Exception_When_InValid_TarrifType()
        {
            // Arrange
            var consumption = 1000.0;
            var invalidType = (TariffType)100;

            // Act and Assert
            Action ex = () => TariffFactory.CreateTariffs(invalidType, consumption);
            ex.Should().Throw<Exception>();
           
        }

    }
}
