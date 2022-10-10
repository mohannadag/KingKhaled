using API.ViewModels.EmployeeAccount;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Employee
{
    public class UpdateEmployeeAccountVMValidator : AbstractValidator<UpdateEmployeeAccountVM>
    {
        public UpdateEmployeeAccountVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.IBAN).NotEmpty().MinimumLength(5).MaximumLength(20);
            RuleFor(x => x.AccountNumber).NotEmpty().MinimumLength(5).MaximumLength(20);

            RuleFor(x => x.EmployeeId).NotEmpty()
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (await unitOfWork.Employees.IsValidIdAsync(value));
                                      })
                                      .WithMessage("Employee Not Found!");

            RuleFor(x => x.BankId).NotEmpty()
                                  .MustAsync(async (value, cancelToken) =>
                                  {
                                      return (await unitOfWork.Banks.IsValidIdAsync(value));
                                  })
                                  .WithMessage("Bank Not Found!");
        }
    }
}
