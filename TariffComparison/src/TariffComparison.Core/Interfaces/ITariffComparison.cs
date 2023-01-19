using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparison.Core.Interfaces
{
    public interface ITariffComparison
    {
        List<Tariff> CompareTariffs(double consumption);
    }
}
