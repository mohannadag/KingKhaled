using API.ViewModels.Department;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Department
{
    public class UpdateDepartmentVMValidator : AbstractValidator<UpdateDepartmentVM>
    {
        public UpdateDepartmentVMValidator()
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
        }
    }
}
