using AutoFixture;
using TariffComparison.Core.Interfaces;
using TariffComparison.Core.Entities;
using TariffComparison.Web.Api;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TariffComparison.Core.Validation;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
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
        public void GetProductsByConsumption_InvokeTariffComparissonService()
        {
            // Arrange
            var consumption = _fixture.Create<double>();
            _mockTariffComparisonService.Setup(x => x.GetProducts(consumption))
                 .Returns(new List<Tariff>());
            _mockValidator.Setup(x => x.Validate(consumption)).Returns(new FluentValidation.Results.ValidationResult());
            // Act
            var result =  _controller.GetProductsByConsumption(consumption);
            _mockTariffComparisonService.Verify(_service => _service.GetProducts(consumption), Times.Once);
        }

        [Fact]
        public void GetProductsByConsumption_ReturnsOkResult()
        {
            // Arrange
            var consumption = _fixture.Create<double>();
            _mockTariffComparisonService.Setup(x => x.GetProducts(consumption))
                 .Returns(new List<Tariff>());
            _mockValidator.Setup(x => x.Validate(consumption)).Returns(new FluentValidation.Results.ValidationResult());

            // Act
            var result =  _controller.GetProductsByConsumption(consumption);

            // Assert
            result.Should().BeOfType<OkObjectResult>();

        }

        [Fact]
        public void GetProductsByConsumption_ReturnsBadRequest()
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
    }

}