using TariffComparison.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparison.Core.Entities
{
    public class TariffFactory 
    {
        public static Tariff CreateProducts(TariffType type, double consumption)
        {
           switch(type){
                case TariffType.Basic:
                    return new BasicTariff{ AnnualCost = consumption };
                case TariffType.Packaged:
                    return new PackageTariff { AnnualCost = consumption };
                default:
                     throw new Exception("Invalid value type for createProducts ProductFactory");
            }
        }
    }
}
