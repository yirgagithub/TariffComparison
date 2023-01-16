using TariffComparison.Core.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparison.Core.Services
{
    public class TariffComparisonService : ITariffComparisonService
    {
        private ITariffComparison _comparison;
        private readonly IValidator<double> _validator;

        public TariffComparisonService(ITariffComparison comparison, IValidator<double> validator)
        {
            _comparison = comparison;
            _validator = validator;
        }

        public List<Tariff> GetProducts(double consumption)
        {
            //duplicating consumption validation in service again but we might use this in another console application directly.
            var validationResult = _validator.Validate(consumption);
            if (validationResult == null || !validationResult.IsValid)
                throw new Exception("Consumption value must be greater than zero");

            return _comparison.CompareTariffs(consumption);
        }
    }
}
