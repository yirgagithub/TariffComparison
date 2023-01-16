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
        public void Test_GetProducts_ValidInput()
        {
            // Arrange
            var mockComparison = new Mock<ITariffComparison>();
            mockComparison.Setup(x => x.CompareTariffs(It.IsAny<double>()))
                .Returns(new List<Tariff> { new BasicTariff(), new PackageTariff() });

            var mockValidator = new Mock<IValidator<double>>();
            mockValidator.Setup(x => x.Validate(It.IsAny<double>()))
               .Returns(new FluentValidation.Results.ValidationResult());


            var service = new TariffComparisonService(mockComparison.Object, mockValidator.Object);
            var consumption = 1000.0;

            // Act
            var products = service.GetProducts(consumption);

            // Assert
            mockComparison.Verify(x => x.CompareTariffs(consumption), Times.Once);
            mockValidator.Verify(x => x.Validate(consumption), Times.Once);
            products.Should().NotBeEmpty().And.HaveCount(2)
                .And.Contain(p => p is BasicTariff)
                .And.Contain(p => p is PackageTariff);
        }

        [Fact]
        public void Test_GetProducts_ZeroConsumption()
        {
            // Arrange
            var mockComparison = new Mock<ITariffComparison>();
            var mockValidator = new Mock<IValidator<double>>();
            mockValidator.Setup(x => x.Validate(It.IsAny<double>()))
                .Returns(new FluentValidation.Results.ValidationResult(new[] { new ValidationFailure("error", "Consumption value must be greater than zero") }));

            var service = new TariffComparisonService(mockComparison.Object, mockValidator.Object);
            var consumption = 0;

            // Act
            Action act = () => service.GetProducts(consumption);

            // Assert
            act.Should().Throw<Exception>().WithMessage("Consumption value must be greater than zero");
            mockValidator.Verify(x => x.Validate(consumption), Times.Once);
        }

        [Fact]
        public void Test_GetProducts_NegativeConsumption()
        {
            // Arrange
            var mockComparison = new Mock<ITariffComparison>();
            var mockValidator = new Mock<IValidator<double>>();
            mockValidator.Setup(x => x.Validate(It.IsAny<double>()))
                .Returns(new FluentValidation.Results.ValidationResult(new[] { new ValidationFailure("error", "Consumption value must be greater than zero") }));

            var service = new TariffComparisonService(mockComparison.Object, mockValidator.Object);
            var consumption = -1000.0;

            // Act
            Action act = () => service.GetProducts(consumption);

            // Assert
            act.Should().Throw<Exception>().WithMessage("Consumption value must be greater than zero");
            mockValidator.Verify(x => x.Validate(consumption), Times.Once);
            mockComparison.Verify(x => x.CompareTariffs(consumption), Times.Never);
        }



    }
}
