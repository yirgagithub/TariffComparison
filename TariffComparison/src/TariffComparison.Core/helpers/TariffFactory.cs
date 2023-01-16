using TariffComparison.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparison.Core.Entities
{
    // A factory class to create tariff types based on the tariff type passed an an argument
    // If invalid tariff type given it will throw an Exception
    public class TariffFactory 
    {
        public static Tariff CreateTariffs(TariffType type, double consumption)
        {
           switch(type){
                case TariffType.Basic:
                    return new BasicTariff(consumption);
                case TariffType.Packaged:
                    return new PackageTariff(consumption);
                default:
                     throw new Exception("Invalid value type for CreateTariffs TariffFactory");
            }
        }
    }
}
