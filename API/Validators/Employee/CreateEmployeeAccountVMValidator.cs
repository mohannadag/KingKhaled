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
    public class CreateEmployeeAccountVMValidator : AbstractValidator<CreateEmployeeAccountVM>
    {
        public CreateEmployeeAccountVMValidator(IUnitOfWork unitOfWork)
        {
            
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

            RuleFor(x => x.IBAN).NotEmpty()
                                .MinimumLength(5)
                                .MaximumLength(20)
                                .MustAsync(async (value, cancelToken) =>
                                {
                                    return (!await unitOfWork.EmployeeAccounts.AlreadyExistIBANAsync(value));
                                })
                                .WithMessage("This IBAN Already Exist!");

            RuleFor(x => x.AccountNumber).NotEmpty()
                                         .MinimumLength(5)
                                         .MaximumLength(20)
                                         .MustAsync(async (value, cancelToken) =>
                                         {
                                             return (!await unitOfWork.EmployeeAccounts.AlreadyExistNumberAsync(value));
                                         })
                                         .WithMessage("This Account Number Already Exist!");
        }
    }
}
