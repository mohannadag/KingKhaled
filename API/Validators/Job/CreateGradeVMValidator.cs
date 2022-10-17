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
    public class CreateGradeVMValidator : AbstractValidator<CreateGradeVM>
    {
        public CreateGradeVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Name).NotEmpty()
                                .MinimumLength(3)
                                .MaximumLength(50)
                                .MustAsync(async (value, cancelToken) =>
                                {
                                    return (!await unitOfWork.Grades.AlreadyExistArabicAsync(value));
                                })
                                .WithMessage("This Grade Already Exist!");

            RuleFor(x => x.GradeNumber).NotEmpty()
                                       .MustAsync(async (value, cancelToken) =>
                                       {
                                           return (!await unitOfWork.Grades.AlreadyExistNumberAsync(value));
                                       })
                                       .WithMessage("This Grade Number Already Exist!");
        }
    }
}
