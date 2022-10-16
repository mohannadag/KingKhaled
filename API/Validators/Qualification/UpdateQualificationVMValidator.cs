using API.ViewModels.Qualification;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Qualification
{
    public class UpdateQualificationVMValidator : AbstractValidator<UpdateQualificationVM>
    {
        public UpdateQualificationVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                                .MinimumLength(3)
                                .MaximumLength(50);
        }
    }
}
