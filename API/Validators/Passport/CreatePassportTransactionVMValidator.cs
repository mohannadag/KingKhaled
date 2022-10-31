using API.ViewModels.Passport;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Passport
{
    public class CreatePassportTransactionVMValidator : AbstractValidator<CreatePassportTransactionVM>
    {
        public CreatePassportTransactionVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.IssueDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.ExpireDate).NotEmpty().GreaterThan(x => x.IssueDate);

            RuleFor(x => x.Notes).MaximumLength(250);

            RuleFor(x => x.PassportId).NotEmpty()
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (await unitOfWork.Passports.IsValidIdAsync(value));
                                      })
                                      .WithMessage("Passport Not Found!");

            When(x => (x.IssueDate >= DateTime.Now),
                () =>
                {
                    RuleFor(x => x).MustAsync(async (value, canselToken) =>
                    {
                        return await unitOfWork.Passports.IsValidToExtendAsync(value.PassportId, value.IssueDate);
                    })
                    .WithMessage("This Passport Already Valid, You Can't Extend it until it Expired!");
                });
        }
    }
}
