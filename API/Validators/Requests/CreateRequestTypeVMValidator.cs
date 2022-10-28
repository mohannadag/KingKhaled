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
    public class CreateRequestTypeVMValidator : AbstractValidator<CreateRequestTypeVM>
    {
        public CreateRequestTypeVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Name).NotEmpty()
                                .MinimumLength(3)
                                .MaximumLength(50)
                                .MustAsync(async (value, cancelToken) =>
                                {
                                    return (!await unitOfWork.RequestTypes.AlreadyExistAsync(value));
                                })
                                .WithMessage("This Name Already Exist!");
        }
    }
}
