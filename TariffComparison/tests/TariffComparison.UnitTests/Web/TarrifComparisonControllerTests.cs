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

        private readonly TarrifComparisonController _controller;

        public TarrifComparisonControllerTests()
        {
            _fixture = new Fixture();
            _mockTariffComparisonService = new Mock<ITariffComparisonService>();
            _controller = new TarrifComparisonController(_mockTariffComparisonService.Object);
        }



        [Fact]
        public void GetProductsByConsumption_Should_Return_OkObjectResult_When_Valid_Consumption()
        {
            // Arrange
            var consumption = _fixture.Create<double>();
            _mockTariffComparisonService.Setup(x => x.GetProducts(consumption))
                 .Returns(new List<Tariff>());

            // Act
            var result = _controller.GetProductsByConsumption(consumption);

            // Assert
            result.Should().BeOfType<OkObjectResult>();

        }

        [Fact]
        public void GetProductsByConsumption_Should_Verify_TariffComparisonServiceCalledOnce_When_Valid_Consumption()
        {
            // Arrange
            var consumption = _fixture.Create<double>();
            _mockTariffComparisonService.Setup(x => x.GetProducts(consumption))
                 .Returns(new List<Tariff>());
           
            // Act
            var result = _controller.GetProductsByConsumption(consumption);
            _mockTariffComparisonService.Verify(_service => _service.GetProducts(consumption), Times.Once);
        }

    }

}