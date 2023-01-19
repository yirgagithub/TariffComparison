using TariffComparison.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TariffComparison.Core.Validation
{
    public class ConsumptionValidation : AbstractValidator<double>
    {
        public ConsumptionValidation()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("Consumption is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("Consumption must be at least 1.");
        }
    }
}
