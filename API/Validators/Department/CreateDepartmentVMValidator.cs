using API.ViewModels.Department;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Department
{
    public class CreateDepartmentVMValidator : AbstractValidator<CreateDepartmentVM>
    {
        public CreateDepartmentVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ArabicName).NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(10)
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (!await unitOfWork.Departments.AlreadyExistArabicNameAsync(value));
                                      })
                                      .WithMessage("This Department Arabic Name Already Exist!");

            RuleFor(x => x.EnglishName).NotEmpty()
                                       .MinimumLength(3)
                                       .MaximumLength(10)
                                       .MustAsync(async (value, cancelToken) =>
                                       {
                                           return (!await unitOfWork.Departments.AlreadyExistEnglishNameAsync(value));
                                       })
                                       .WithMessage("This Department English Name Already Exist!");

            RuleFor(x => x.ShortArName).NotEmpty()
                                       .MinimumLength(3)
                                       .MaximumLength(10)
                                       .MustAsync(async (value, cancelToken) =>
                                       {
                                           return (!await unitOfWork.Departments.AlreadyExistShortArNameAsync(value));
                                       })
                                       .WithMessage("This Department Short Arabic Name Already Exist!");

            RuleFor(x => x.ShortEnName).NotEmpty()
                                       .MinimumLength(3)
                                       .MaximumLength(10)
                                       .MustAsync(async (value, cancelToken) =>
                                       {
                                           return (!await unitOfWork.Departments.AlreadyExistShortEnNameAsync(value));
                                       })
                                       .WithMessage("This Department Short English Name Already Exist!");
        }
    }
}
