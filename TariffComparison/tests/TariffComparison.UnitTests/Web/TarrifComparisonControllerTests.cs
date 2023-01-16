using AutoFixture;
using TariffComparison.Core.Interfaces;
using TariffComparison.Web.Api;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;
using FluentValidation;
using FluentValidation.Results;

namespace TarrifComparison.Controller
{
    public class TarrifComparisonControllerTests
    {
        private readonly Fixture _fixture;
        private readonly Mock<ITariffComparisonService> _mockTariffComparisonService;
        Mock<IValidator<double>> _mockValidator;

        private readonly TarrifComparisonController _controller;

        public TarrifComparisonControllerTests()
        {
            _fixture = new Fixture();
            _mockTariffComparisonService = new Mock<ITariffComparisonService>();
            _mockValidator = new Mock<IValidator<double>>(MockBehavior.Strict);
            _controller = new TarrifComparisonController(_mockTariffComparisonService.Object, _mockValidator.Object);
        }



        [Fact]
        public void GetProductsByConsumption_Should_Return_OkObjectResult_When_Valid_Consumption()
        {
            // Arrange
            var consumption = _fixture.Create<double>();
            _mockTariffComparisonService.Setup(x => x.GetProducts(consumption))
                 .Returns(new List<Tariff>());
            _mockValidator.Setup(x => x.Validate(consumption)).Returns(new FluentValidation.Results.ValidationResult());

            // Act
            var result = _controller.GetProductsByConsumption(consumption);

            // Assert
            result.Should().BeOfType<OkObjectResult>();

        }

        [Fact]
        public void GetProductsByConsumption_Should_Return_BadRequestObjectResult_When_InValid_Consumption()
        {
            // Arrange
            var consumption = 0;
            _mockTariffComparisonService.Setup(x => x.GetProducts(consumption))
                 .Returns(new List<Tariff>());
            var validationError = new ValidationFailure { PropertyName = "Consumption", ErrorMessage = "Consumption must be greater than zero" };
            List<ValidationFailure> list = new List<ValidationFailure> { validationError };
            _mockValidator.Setup(x => x.Validate(consumption))
                .Returns(new FluentValidation.Results.ValidationResult(list));

            // Act
            var result = _controller.GetProductsByConsumption(consumption);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();

        }

        [Fact]
        public void GetProductsByConsumption_Should_Verify_TariffComparisonServiceCalledOnce_When_Valid_Consumption()
        {
            // Arrange
            var consumption = _fixture.Create<double>();
            _mockTariffComparisonService.Setup(x => x.GetProducts(consumption))
                 .Returns(new List<Tariff>());
            _mockValidator.Setup(x => x.Validate(consumption)).Returns(new FluentValidation.Results.ValidationResult());
            // Act
            var result = _controller.GetProductsByConsumption(consumption);
            _mockTariffComparisonService.Verify(_service => _service.GetProducts(consumption), Times.Once);
        }

        [Fact]
        public void GetProductsByConsumption_Should_Verify_TariffComparisonServiceNeverCalled_When_InValid_Consumption()
        {
            // Arrange
            var consumption = 0;
            _mockTariffComparisonService.Setup(x => x.GetProducts(consumption))
                 .Returns(new List<Tariff>());
            var validationError = new ValidationFailure { PropertyName = "Consumption", ErrorMessage = "Consumption must be greater than zero" };
            List<ValidationFailure> list = new List<ValidationFailure> { validationError };
            _mockValidator.Setup(x => x.Validate(consumption))
                .Returns(new FluentValidation.Results.ValidationResult(list));

            // Act
            var result = _controller.GetProductsByConsumption(consumption);
            _mockTariffComparisonService.Verify(_service => _service.GetProducts(consumption), Times.Never);
        }


    }

}