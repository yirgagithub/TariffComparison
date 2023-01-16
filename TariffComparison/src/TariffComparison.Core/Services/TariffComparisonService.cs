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

        public TariffComparisonService(ITariffComparison comparison)
        {
            _comparison = comparison;
        }

        public List<Tariff> GetProducts(double consumption)
        {
            return _comparison.CompareTariffs(consumption);
        }
    }
}
