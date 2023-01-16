using TariffComparison.Core.Entities;
using TariffComparison.Core.Interfaces;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TariffComparison.UnitTests.Core.helpers
{
    public class TariffFactoryTest
    {
        [Theory]
        [InlineData(TariffType.Basic)]
        [InlineData(TariffType.Packaged)]
        public void Test_CreateProducts_ValidInput_(TariffType type)
        {
            // Arrange
            var consumption = 1000.0;

            // Act
            var product = TariffFactory.CreateProducts(type, consumption);

            // Assert
            if (type == TariffType.Basic)
                product.Should().BeOfType<BasicTariff>();
            else if (type == TariffType.Packaged)
                product.Should().BeOfType<PackageTariff>();
        }

        [Fact]
        public void Test_CreateProducts_InvalidInput()
        {
            // Arrange
            var consumption = 1000.0;
            var invalidType = (TariffType)100;

            // Act and Assert
            Action ex = () => TariffFactory.CreateProducts(invalidType, consumption);
            ex.Should().Throw<Exception>();
           
        }

    }
}
