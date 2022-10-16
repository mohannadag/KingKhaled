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
    public class UpdateBranchVMValidator : AbstractValidator<UpdateBranchVM>
    {
        public UpdateBranchVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ArabicName).NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(10);

            RuleFor(x => x.EnglishName).NotEmpty()
                                       .MinimumLength(3)
                                       .MaximumLength(10);

            RuleFor(x => x.ShortArName).NotEmpty()
                                       .MinimumLength(3)
                                       .MaximumLength(10);

            RuleFor(x => x.ShortEnName).NotEmpty()
                                       .MinimumLength(3)
                                       .MaximumLength(10);

            RuleFor(x => x.DepartmentId).NotEmpty()
                                        .MustAsync(async (value, cancelToken) =>
                                        {
                                            return (await unitOfWork.Departments.IsValidIdAsync(value));
                                        })
                                        .WithMessage("Department Not Found!");
        }
    }
}
