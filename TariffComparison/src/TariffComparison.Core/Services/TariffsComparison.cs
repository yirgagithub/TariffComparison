using TariffComparison.Core.Entities;
using TariffComparison.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparison.Core.Services
{
    public class TariffsComparison: ITariffComparison
    {

        public List<Tariff> CompareTariffs(double consumption)
        {
            var basic = TariffFactory.CreateProducts(TariffType.Basic, consumption );
            var package = TariffFactory.CreateProducts(TariffType.Packaged, consumption);
           
            var products = new List<Tariff> { basic, package };

            return products.OrderBy(p => p.AnnualCost).ToList();
        }
    }
}
