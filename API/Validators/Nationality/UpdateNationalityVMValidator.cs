using API.ViewModels.Nationality;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Nationality
{
    public class UpdateNationalityVMValidator : AbstractValidator<UpdateNationalityVM>
    {
        public UpdateNationalityVMValidator()
        {
            RuleFor(x => x.ArabicName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.EnglishName).NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}
