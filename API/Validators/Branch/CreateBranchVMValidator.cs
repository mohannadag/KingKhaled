using API.ViewModels.Branch;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Branch
{
    public class CreateBranchVMValidator : AbstractValidator<CreateBranchVM>
    {
        public CreateBranchVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ArabicName).NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(10)
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (!await unitOfWork.Branches.AlreadyExistArabicNameAsync(value));
                                      })
                                      .WithMessage("This Branch Arabic Name Already Exist!");

            RuleFor(x => x.EnglishName).NotEmpty()
                                       .MinimumLength(3)
                                       .MaximumLength(10)
                                       .MustAsync(async (value, cancelToken) =>
                                       {
                                           return (!await unitOfWork.Branches.AlreadyExistEnglishNameAsync(value));
                                       })
                                       .WithMessage("This Branch English Name Already Exist!");

            RuleFor(x => x.ShortArName).NotEmpty()
                                       .MinimumLength(3)
                                       .MaximumLength(10)
                                       .MustAsync(async (value, cancelToken) =>
                                       {
                                           return (!await unitOfWork.Branches.AlreadyExistShortArNameAsync(value));
                                       })
                                       .WithMessage("This Branch Short Arabic Name Already Exist!");

            RuleFor(x => x.ShortEnName).NotEmpty()
                                       .MinimumLength(3)
                                       .MaximumLength(10)
                                       .MustAsync(async (value, cancelToken) =>
                                       {
                                           return (!await unitOfWork.Branches.AlreadyExistShortEnNameAsync(value));
                                       })
                                       .WithMessage("This Branch Short English Name Already Exist!");

            RuleFor(x => x.DepartmentId).NotEmpty()
                                        .MustAsync(async (value, cancelToken) =>
                                        {
                                            return (await unitOfWork.Departments.IsValidIdAsync(value));
                                        })
                                        .WithMessage("Department Not Found!");
        }
    }
}
