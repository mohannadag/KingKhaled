using API.ViewModels.Passport;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Passport
{
    public class UpdatePassportVMValidator : AbstractValidator<UpdatePassportVM>
    {
        public UpdatePassportVMValidator()
        {
            RuleFor(x => x.Issuer).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.PassportNumber).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.IssueDate).NotEmpty().LessThanOrEqualTo(DateTime.Now.AddDays(1));
            RuleFor(x => x.ExpireDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.Notes).MaximumLength(250);
        }
    }
}
