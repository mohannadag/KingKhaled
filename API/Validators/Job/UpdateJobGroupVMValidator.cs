using API.ViewModels.JobGroup;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Job
{
    public class UpdateJobGroupVMValidator : AbstractValidator<UpdateJobGroupVM>
    {
        public UpdateJobGroupVMValidator()
        {
            RuleFor(x => x.ArabicName).NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(50);
        }
    }
}
