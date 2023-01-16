using TariffComparison.Core.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TariffComparison.Web.Api
{
    /// <summary>
    /// A comparison endpoint 
    /// </summary>
    public class TarrifComparisonController : BaseApiController
    {
        private readonly ITariffComparisonService _tariffComparisonService;
        private readonly IValidator<double> _validator;

        public TarrifComparisonController(ITariffComparisonService tariffComparisonService, IValidator<double> validator)
        {
            _tariffComparisonService = tariffComparisonService;
            _validator = validator;
        }

        // GET: api/tarrifcomparison
        [HttpGet("{consumption:double}")]
        public IActionResult GetProductsByConsumption( double consumption)
        {
            var validators = _validator.Validate(consumption);
            if (validators == null || !validators.IsValid)
                return BadRequest(validators != null ? validators.Errors : "Error in consumption");

            var result = _tariffComparisonService.GetProducts(consumption);
            return Ok(result);
        }
    }
}
