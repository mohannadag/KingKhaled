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
    public class UpdateJobVMValidator : AbstractValidator<UpdateJobVM>
    {
        public UpdateJobVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ArabicName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Code).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.WorkNatureAllowance).NotEmpty().GreaterThanOrEqualTo(0);

            RuleFor(x => x.MinGradeId).NotEmpty()
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (await unitOfWork.Grades.IsValidIdAsync(value));
                                      })
                                      .WithMessage("Min Grade Not Found!");

            RuleFor(x => x.MaxGradeId).NotEmpty()
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

            When(x => (x.MinGradeId > 0 && x.MaxGradeId > 0),
                () =>
                {
                    RuleFor(x => x).MustAsync(async (value, canselToken) =>
                    {
                        return await unitOfWork.Grades.IsValidMinGradeIdForMaxGradeIdAsync(value.MinGradeId, value.MaxGradeId);
                    })
                    .WithMessage("Min Grade Number Must be Less than or Equal to Max Grade Number!");
                });
        }
    }
}
