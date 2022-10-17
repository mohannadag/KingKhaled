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
    public class CreateJobVMValidator : AbstractValidator<CreateJobVM>
    {
        public CreateJobVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.WorkNatureAllowance).NotEmpty().GreaterThanOrEqualTo(0);

            RuleFor(x => x.Code).NotEmpty()
                                .MinimumLength(3)
                                .MaximumLength(10)
                                .MustAsync(async (value, cancelToken) =>
                                {
                                    return (!await unitOfWork.Jobs.AlreadyExistCodeAsync(value));
                                })
                                .WithMessage("This Code Already Exist!");

            RuleFor(x => x.ArabicName).NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(10)
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (!await unitOfWork.Jobs.AlreadyExistArabicAsync(value));
                                      })
                                      .WithMessage("This Job Name Already Exist!");

            RuleFor(x => x.MinGradeId).NotEmpty().LessThan(x => x.MaxGradeId)
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (await unitOfWork.Grades.IsValidIdAsync(value));
                                      })
                                      .WithMessage("Min Grade Not Found!");

            RuleFor(x => x.MaxGradeId).NotEmpty().GreaterThan(x => x.MinGradeId)
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (await unitOfWork.Grades.IsValidIdAsync(value));
                                      })
                                      .WithMessage("Max Grade Not Found!");

            RuleFor(x => x.JobSubGroupId).NotEmpty()
                                         .MustAsync(async (value, cancelToken) =>
                                         {
                                             return (await unitOfWork.JobSubGroups.IsValidIdAsync(value));
                                         })
                                         .WithMessage("Job Sub Group Not Found!");

        }
    }
}
