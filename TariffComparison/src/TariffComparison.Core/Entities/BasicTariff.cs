using TariffComparison.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparison.Core.Entities
{
    public class BasicTariff : Tariff
    {
        //I recommend putting these values in a table(Lookup:- Key, Value table) so that when we change our mind we can easily change its value
        private const double MONTHLY_COST = 5;
        private const int MONTHS_IN_YEAR = 12;
        private const double CONSUMPUTION_COSTS = 0.22;
        public string Name { set; get; } = "basic electricity tariff";
        private double annualCost;
        public double AnnualCost
        {
            get { return MONTHLY_COST * MONTHS_IN_YEAR + (this.annualCost * CONSUMPUTION_COSTS); }
            set { this.annualCost = value; }
        }
    }
}
