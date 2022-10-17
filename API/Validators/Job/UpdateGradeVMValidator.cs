using API.ViewModels.JobGroup;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Job
{
    public class UpdateGradeVMValidator : AbstractValidator<UpdateGradeVM>
    {
        public UpdateGradeVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                                .MinimumLength(3)
                                .MaximumLength(50);

            RuleFor(x => x.GradeNumber).NotEmpty();
        }
    }
}
