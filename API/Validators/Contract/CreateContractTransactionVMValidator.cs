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
    public class CreateContractTransactionVMValidator : AbstractValidator<CreateContractTransactionVM>
    {
        public CreateContractTransactionVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Notes).MaximumLength(250);

            RuleFor(x => x.StartDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.EndDate).NotEmpty().GreaterThan(x => x.StartDate);

            RuleFor(x => x.ContractId).NotEmpty()
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (await unitOfWork.Contracts.IsValidIdAsync(value));
                                      })
                                      .WithMessage("Contract Not Found!");

            RuleFor(x => x.ContractTypeId).NotEmpty()
                                          .MustAsync(async (value, cancelToken) =>
                                          {
                                              return (await unitOfWork.ContractTypes.IsValidIdAsync(value));
                                          })
                                          .WithMessage("ContractType Not Found!");

            When(x => (x.StartDate >= DateTime.Now),
                () =>
                {
                    RuleFor(x => x).MustAsync(async (value, canselToken) =>
                    {
                        return await unitOfWork.Contracts.IsValidToExtendAsync(value.ContractId, value.StartDate);
                    })
                    .WithMessage("This Contract Already Valid, You Can't Extend it until it Expired!");
                });

        }
    }
}
