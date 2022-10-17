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
    public class CreateLevelVMValidator : AbstractValidator<CreateLevelVM>
    {
        public CreateLevelVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Name).NotEmpty()
                                .MinimumLength(3)
                                .MaximumLength(50)
                                .MustAsync(async (value, cancelToken) =>
                                {
                                    return (!await unitOfWork.Levels.AlreadyExistArabicAsync(value));
                                })
                                .WithMessage("This Level Already Exist!");

            RuleFor(x => x.LevelNumber).NotEmpty()
                                       .MustAsync(async (value, cancelToken) =>
                                       {
                                           return (!await unitOfWork.Levels.AlreadyExistNumberAsync(value));
                                       })
                                       .WithMessage("This Level Number Already Exist!");
        }
    }
}
