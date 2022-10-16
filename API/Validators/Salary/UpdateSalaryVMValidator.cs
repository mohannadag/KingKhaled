using API.ViewModels.Salary;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Salary
{
    public class UpdateSalaryVMValidator : AbstractValidator<UpdateSalaryVM>
    {
        public UpdateSalaryVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.BasicSalary).NotEmpty().GreaterThan(0);

            RuleFor(x => x.GradeId).NotEmpty()
                                   .MustAsync(async (value, cancelToken) =>
                                   {
                                       return (await unitOfWork.Grades.IsValidIdAsync(value));
                                   })
                                   .WithMessage("Grade Not Found!");

            RuleFor(x => x.LevelId).NotEmpty()
                                   .MustAsync(async (value, cancelToken) =>
                                   {
                                       return (await unitOfWork.Levels.IsValidIdAsync(value));
                                   })
                                   .WithMessage("Grade Not Found!");

            When(x => (x.GradeId > 0 && x.LevelId > 0),
                () =>
                {
                    RuleFor(x => x).MustAsync(async (value, canselToken) =>
                    {
                        return await unitOfWork.Grades.IsValidLevelIdForGradeAsync(value.GradeId, value.LevelId);
                    })
                    .WithMessage("This Level are Not Valid for this Grade!");
                });
        }
    }
}
