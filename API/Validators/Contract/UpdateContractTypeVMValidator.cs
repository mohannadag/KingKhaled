using API.ViewModels.Contracts;
using Core.Models.EmployeesInfo;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Contract
{
    public class UpdateContractTypeVMValidator : AbstractValidator<UpdateContractTypeVM>
    {
        public UpdateContractTypeVMValidator()
        {
            RuleFor(x => x.Notes).MaximumLength(250);
            RuleFor(x => x.AnnualVacationPerDay).NotEmpty().InclusiveBetween(1, 30);

            RuleFor(x => x.ArabicName).NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(100);
        }
    }
}
