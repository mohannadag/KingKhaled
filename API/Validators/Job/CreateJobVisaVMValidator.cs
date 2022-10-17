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
    public class CreateJobVisaVMValidator : AbstractValidator<CreateJobVisaVM>
    {
        public CreateJobVisaVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Name).NotEmpty()
                                .MinimumLength(3)
                                .MaximumLength(50)
                                .MustAsync(async (value, cancelToken) =>
                                {
                                    return (!await unitOfWork.JobVisa.AlreadyExistAsync(value));
                                })
                                .WithMessage("This Name Already Exist!");
        }
    }
}
