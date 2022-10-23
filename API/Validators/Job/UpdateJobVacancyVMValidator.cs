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
    public class UpdateJobVacancyVMValidator : AbstractValidator<UpdateJobVacancyVM>
    {
        public UpdateJobVacancyVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.VacantNumber).NotEmpty();
            RuleFor(x => x.Notes).MaximumLength(100);

            RuleFor(x => x.JobId).NotEmpty()
                                        .MustAsync(async (value, cancelToken) =>
                                        {
                                            return (await unitOfWork.Jobs.IsValidIdAsync(value));
                                        })
                                        .WithMessage("Job Not Found!");

            RuleFor(x => x.BranchId).NotEmpty()
                                        .MustAsync(async (value, cancelToken) =>
                                        {
                                            return (await unitOfWork.Branches.IsValidIdAsync(value));
                                        })
                                        .WithMessage("Branch Not Found!");

            RuleFor(x => x.BranchId).NotEmpty()
                                        .MustAsync(async (value, cancelToken) =>
                                        {
                                            return (await unitOfWork.Branches.IsAllowedToAddVacanyAsync(value));
                                        })
                                        .WithMessage("This Branch Reach to the Maximum Limit to Add Job Vacancy!");
        }
    }
}
