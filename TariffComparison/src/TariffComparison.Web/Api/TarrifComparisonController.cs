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

        public TarrifComparisonController(ITariffComparisonService tariffComparisonService)
        {
            _tariffComparisonService = tariffComparisonService;
        }

        // validates the input using fluent validation if error it returns BadRequest
        // if valid it will get products from _tariffComparisonService  
        // GET: api/tarrifcomparison
        [HttpGet("{consumption:double}")]
        public IActionResult GetProductsByConsumption( double consumption)
        {
            var result = _tariffComparisonService.GetProducts(consumption);
            return Ok(result);
        }
    }
}
