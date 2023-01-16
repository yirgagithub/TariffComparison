using TariffComparison.Core.Entities;
using TariffComparison.Core.Services;
using TariffComparison;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace TariffComparison.UnitTests.Core.Services
{
    public class TariffComparisonTests
    {
        [Fact]
        public void CompareTariffs_Should_ReturnBasicAndPackageTariff_When_Valid_Consumption()
        {
            // Arrange
            var consumption = 1000.0;
            var tariffComparison = new TariffsComparison();

            // Act
            var products = tariffComparison.CompareTariffs(consumption);

            // Assert
            products.Should().NotBeEmpty()
                .And.HaveCount(2)
                .And.Contain(p => p is BasicTariff)
                .And.Contain(p => p is PackageTariff)
                .And.BeInAscendingOrder(p => p.AnnualCost);
        }

        [Fact]
        public void CompareTariffs_Should_Return_OrderedList_When_Valid_Consumption()
        {
            // Arrange
            var tariffComparison = new TariffsComparison();

            // Act
            var products1 = tariffComparison.CompareTariffs(1000.0);
            var products2 = tariffComparison.CompareTariffs(2000.0);
            var products3 = tariffComparison.CompareTariffs(3000.0);

            // Assert
            products1.Should().BeInAscendingOrder(p => p.AnnualCost);
            products2.Should().BeInAscendingOrder(p => p.AnnualCost);
            products3.Should().BeInAscendingOrder(p => p.AnnualCost);
            products1.First().AnnualCost.Should().BeLessThan(products2.First().AnnualCost);
            products2.First().AnnualCost.Should().BeLessThan(products3.First().AnnualCost);
        }


        [Fact]
        public void CompareTariffs_Should_Return_TwoTariff_When_Valid_Consumption()
        {
            // Arrange
            var tariffComparison = new TariffsComparison();

            // Act
            var products1 = tariffComparison.CompareTariffs(double.MinValue);
            var products2 = tariffComparison.CompareTariffs(double.MaxValue);

            // Assert
            products1.Should().HaveCount(2)
                .And.Contain(p => p is BasicTariff)
                .And.Contain(p => p is PackageTariff)
                .And.BeInAscendingOrder(p => p.AnnualCost);

            products2.Should().HaveCount(2)
                .And.Contain(p => p is BasicTariff)
                .And.Contain(p => p is PackageTariff)
                .And.BeInAscendingOrder(p => p.AnnualCost);
        }

    }
}
