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
    public class CreateJobSubGroupVMValidator : AbstractValidator<CreateJobSubGroupVM>
    {
        public CreateJobSubGroupVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ArabicName).NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(50)
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (!await unitOfWork.JobSubGroups.AlreadyExistArabicAsync(value));
                                      })
                                      .WithMessage("This Arabic Name Already Exist!");

            RuleFor(x => x.JobGroupId).NotEmpty()
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (await unitOfWork.JobGroups.IsValidIdAsync(value));
                                      })
                                      .WithMessage("This Job Group Not Found!");
        }
    }
}
