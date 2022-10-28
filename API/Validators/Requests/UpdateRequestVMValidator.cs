using API.ViewModels.Requests;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Requests
{
    public class UpdateRequestVMValidator : AbstractValidator<UpdateRequestVM>
    {
        public UpdateRequestVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.RequestReason).NotEmpty().MinimumLength(10).MaximumLength(250);
            RuleFor(x => x.Notes).MaximumLength(500);
            RuleFor(x => x.Receiver).NotEmpty().MinimumLength(5).MaximumLength(250);

            RuleFor(x => x.RequestNumber).NotEmpty()
                                         .MinimumLength(3)
                                         .MaximumLength(50);

            RuleFor(x => x.EmployeeId).NotEmpty()
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (await unitOfWork.Employees.IsValidIdAsync(value));
                                      })
                                      .WithMessage("Employee Not Found!");

            RuleFor(x => x.RequestTypeId).NotEmpty()
                                         .MustAsync(async (value, cancelToken) =>
                                         {
                                             return (await unitOfWork.RequestTypes.IsValidIdAsync(value));
                                         })
                                         .WithMessage("RequestType Not Found!");
        }
    }
}
