using API.ViewModels.Allowance;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Allowance
{
    public class CreateAllowanceTypeVMValidator : AbstractValidator<CreateAllowanceTypeVM>
    {
        public CreateAllowanceTypeVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ArabicName).NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(50)
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (!await unitOfWork.AllowanceTypes.AlreadyExistArabicAsync(value));
                                      })
                                      .WithMessage("This Allowance Already Exist!");
        }
    }
}
