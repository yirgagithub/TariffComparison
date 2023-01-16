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

        // Create tariffs using tariff factory
        // Order the tariffs by their AnnualCost
        public List<Tariff> CompareTariffs(double consumption)
        {
            var basic = TariffFactory.CreateTariffs(TariffType.Basic, consumption );
            var package = TariffFactory.CreateTariffs(TariffType.Packaged, consumption);
           
            var tariffs = new List<Tariff> { basic, package };

            return tariffs.OrderBy(p => p.AnnualCost).ToList();
        }
    }
}
