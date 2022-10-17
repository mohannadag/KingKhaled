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
    public class UpdateIdentityVMValidator : AbstractValidator<UpdateIdentityVM>
    {
        public UpdateIdentityVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Issuer).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.IssueDate).NotEmpty().LessThanOrEqualTo(DateTime.Now.AddDays(1));
            RuleFor(x => x.ExpireDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IdentityType).NotEmpty().IsInEnum();

            RuleFor(x => x.EmployeeId).NotEmpty()
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (await unitOfWork.Employees.IsValidIdAsync(value));
                                      })
                                      .WithMessage("Employee Not Found!");

            RuleFor(x => x.JobVisaId).NotEmpty()
                                     .MustAsync(async (value, cancelToken) =>
                                     {
                                         return (await unitOfWork.JobVisa.IsValidIdAsync(value));
                                     })
                                     .WithMessage("Job Visa Not Found!");
        }
    }
}
