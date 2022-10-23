using API.ViewModels.Allowance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Allowance
{
    public class UpdateAllowanceTypeVMValidator : AbstractValidator<UpdateAllowanceTypeVM>
    {
        public UpdateAllowanceTypeVMValidator()
        {
            RuleFor(x => x.ArabicName).NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}
