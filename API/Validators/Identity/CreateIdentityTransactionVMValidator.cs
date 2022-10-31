using API.ViewModels.Identity;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Identity
{
    public class CreateIdentityTransactionVMValidator : AbstractValidator<CreateIdentityTransactionVM>
    {
        public CreateIdentityTransactionVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Notes).NotEmpty().MinimumLength(3).MaximumLength(250);

            RuleFor(x => x.IssueDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.ExpireDate).NotEmpty().GreaterThan(x => x.IssueDate);

            RuleFor(x => x.JobVisaId).NotEmpty()
                                     .MustAsync(async (value, cancelToken) =>
                                     {
                                         return (await unitOfWork.JobVisa.IsValidIdAsync(value));
                                     })
                                     .WithMessage("Job Visa Not Found!");

            RuleFor(x => x.IdentityId).NotEmpty()
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (await unitOfWork.Identities.IsValidIdAsync(value));
                                      })
                                      .WithMessage("Identity Not Found!");

            When(x => (x.IssueDate >= DateTime.Now),
                () =>
                {
                    RuleFor(x => x).MustAsync(async (value, canselToken) =>
                    {
                        return await unitOfWork.Identities.IsValidToExtendAsync(value.IdentityId, value.IssueDate);
                    })
                    .WithMessage("This Identity Already Valid, You Can't Extend it until it Expired!");
                });
        }
    }
}
