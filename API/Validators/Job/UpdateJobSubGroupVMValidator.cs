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
    public class UpdateJobSubGroupVMValidator : AbstractValidator<UpdateJobSubGroupVM>
    {
        public UpdateJobSubGroupVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ArabicName).NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(50);

            RuleFor(x => x.JobGroupId).NotEmpty()
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (await unitOfWork.JobGroups.IsValidIdAsync(value));
                                      })
                                      .WithMessage("This Job Group Not Found!");
        }
    }
}
