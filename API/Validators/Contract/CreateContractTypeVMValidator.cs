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
            RuleFor(x => x.IsDeserveTicket).NotEmpty();
            RuleFor(x => x.NumberOfTicket).GreaterThanOrEqualTo(0).LessThanOrEqualTo(10);

            RuleFor(x => x.ArabicName).NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(100)
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (!await unitOfWork.ContractTypes.AlreadyExistAsync(value));
                                      })
                                      .WithMessage("This ContractType Already Exist!");

            When(x => (x.IsDeserveTicket),
                () =>
                {
                    RuleFor(x => x.NumberOfTicket).GreaterThanOrEqualTo(1)
                    .WithMessage("NumberOfTicket Must be Greater Than 0 in case You Select IsDesrveTicket = True!");
                });
        }
    }
}
