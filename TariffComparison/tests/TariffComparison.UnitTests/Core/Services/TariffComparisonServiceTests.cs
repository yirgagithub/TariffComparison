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

        private readonly Mock<IValidator<double>> _mockValidator;
        private readonly Mock<ITariffComparison> _mockComparison;
        public TariffComparisonServiceTests()
        {
            _mockComparison = new Mock<ITariffComparison>();
            _mockValidator = new Mock<IValidator<double>>();
        }
        [Fact]
        public void GetProducts_Should_Return_ListOfTariff_When_Valid_Consumption()
        {
            // Arrange
            var consumption = 1000.0;
            _mockComparison.Setup(x => x.CompareTariffs(It.IsAny<double>()))
                .Returns(new List<Tariff> { new BasicTariff(), new PackageTariff() });
            _mockValidator.Setup(x => x.Validate(consumption)).Returns(new FluentValidation.Results.ValidationResult());
            var service = new TariffComparisonService(_mockComparison.Object, _mockValidator.Object);

            // Act
            var products = service.GetProducts(consumption);

            // Assert
            _mockComparison.Verify(x => x.CompareTariffs(consumption), Times.Once);
            products.Should().BeOfType<List<Tariff>>();
            
        }

        [Fact]
        public void GetProducts_Should_Throw_Exception_When_InValid_Consumption()
        {
            // Arrange
            var consumption = 0;
            var mockComparison = new Mock<ITariffComparison>();
            mockComparison.Setup(x => x.CompareTariffs(It.IsAny<double>()))
                .Returns(new List<Tariff> { new BasicTariff(), new PackageTariff() });
            var validationError = new ValidationFailure { PropertyName = "Consumption", ErrorMessage = "Consumption must be greater than zero" };
            List<ValidationFailure> list = new List<ValidationFailure> { validationError };
            _mockValidator.Setup(x => x.Validate(consumption))
                .Returns(new FluentValidation.Results.ValidationResult(list));
            var service = new TariffComparisonService(_mockComparison.Object, _mockValidator.Object);

            // Act and Assert
            Action ex = () => service.GetProducts(consumption);
            ex.Should().Throw<Exception>();

        }


    }
}
