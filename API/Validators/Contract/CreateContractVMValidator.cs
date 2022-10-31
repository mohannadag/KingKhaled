using API.ViewModels.Contracts;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Contract
{
    public class CreateContractVMValidator : AbstractValidator<CreateContractVM>
    {
        public CreateContractVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Notes).MaximumLength(250);

            RuleFor(x => x.StartDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.EndDate).NotEmpty().GreaterThan(x => x.StartDate);

            RuleFor(x => x.ContractNumber).NotEmpty()
                                          .MinimumLength(3)
                                          .MaximumLength(10)
                                          .MustAsync(async (value, cancelToken) =>
                                          {
                                              return (!await unitOfWork.Contracts.AlreadyExistContractNumberAsync(value));
                                          })
                                          .WithMessage("This Contract Number Already Exist!");

            RuleFor(x => x.ContractTypeId).NotEmpty()
                                          .MustAsync(async (value, cancelToken) =>
                                          {
                                              return (await unitOfWork.ContractTypes.IsValidIdAsync(value));
                                          })
                                          .WithMessage("ContractType Not Found!");

            RuleFor(x => x.EmployeeId).NotEmpty()
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (await unitOfWork.Employees.IsValidIdAsync(value));
                                      })
                                      .WithMessage("Employee Not Found!");

            RuleFor(x => x.EmployeeId).NotEmpty()
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (!await unitOfWork.Contracts.AlreadyExistForEmployeeAsync(value));
                                      })
                                      .WithMessage("Employee Already Have Contract, You Can Extend the End Date!");
        }
    }
}
