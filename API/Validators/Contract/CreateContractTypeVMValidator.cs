using API.ViewModels.Contracts;
using Core.Models.EmployeesInfo;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Contract
{
    public class CreateContractTypeVMValidator : AbstractValidator<CreateContractTypeVM>
    {
        public CreateContractTypeVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Notes).MaximumLength(250);
            RuleFor(x => x.AnnualVacationPerDay).NotEmpty().InclusiveBetween(1, 30);

            RuleFor(x => x.ArabicName).NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(100)
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (!await unitOfWork.ContractTypes.AlreadyExistAsync(value));
                                      })
                                      .WithMessage("This ContractType Already Exist!");
        }
    }
}
