using TariffComparison.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparison.Core.Entities
{
    public class PackageTariff : Tariff
    {
        //I recommend putting these values in a table(Lookup:- Key, Value table) so that when we change our mind we can easily change its value
        private const double THRESHOLD_CONSUMPTION_VALUE = 4000;
        private const double THRESHOLD_CONSUMPTION_PRICE = 800;
        private const double CONSUMPUTION_COSTS = 0.3;
        public string Name { set; get; } = "Packaged tariff";
        private double annualCost;
        public double AnnualCost
        {
            get { return (this.annualCost <= THRESHOLD_CONSUMPTION_VALUE) ? THRESHOLD_CONSUMPTION_PRICE : (THRESHOLD_CONSUMPTION_PRICE + (this.annualCost - THRESHOLD_CONSUMPTION_VALUE) * CONSUMPUTION_COSTS); }
            set { this.annualCost = value; }
        }
    }
}
