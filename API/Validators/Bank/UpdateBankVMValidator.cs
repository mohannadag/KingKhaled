using API.ViewModels.Bank;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Bank
{
    public class UpdateBankVMValidator : AbstractValidator<UpdateBankVM>
    {
        public UpdateBankVMValidator()
        {
            RuleFor(x => x.ArabicName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.EnglishName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Code).NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}
