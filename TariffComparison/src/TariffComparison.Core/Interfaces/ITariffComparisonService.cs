using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparison.Core.Interfaces
{
    public interface ITariffComparisonService
    {
        List<Tariff> GetProducts(double consumption);
    }
}
