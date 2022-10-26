using API.ViewModels.EntryCard;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Employee
{
    public class UpdateEntryCardVMValidator : AbstractValidator<UpdateEntryCardVM>
    {
        public UpdateEntryCardVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.SecurityNumber).NotEmpty().MinimumLength(3).MaximumLength(10);
            RuleFor(x => x.SecurityIssueDate).NotEmpty().LessThanOrEqualTo(DateTime.Now.AddDays(1));
            RuleFor(x => x.SecurityIssueDateHijri).NotEmpty();
            RuleFor(x => x.SecurityExpireDate).NotEmpty().GreaterThanOrEqualTo(x => x.SecurityIssueDate);
            RuleFor(x => x.SecurityExpireDateHijri).NotEmpty();

            RuleFor(x => x.DepartmentNumber).NotEmpty().MaximumLength(3).MaximumLength(10);
            RuleFor(x => x.DepartmentExpireDate).GreaterThanOrEqualTo(x => DateTime.Now.AddDays(1));
            RuleFor(x => x.DepartmentExpireDateHijri).NotEmpty();

            RuleFor(x => x.EmployeeId).NotEmpty()
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (await unitOfWork.Employees.IsValidIdAsync(value));
                                      })
                                      .WithMessage("Employee Not Found!");
        }
    }
}
