using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparison.Core.Interfaces
{
    public abstract class Tariff
    {

        public abstract string Name { get;}
        public abstract double AnnualCost { get;}
        protected double Consumption;

        public override string ToString()
        {
            return $"The Annual Tarrif for {Name} with consumtion {Consumption} is {AnnualCost}";
        }

    }
}
