using API.ViewModels.Qualification;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Qualification
{
    public class CreateQualificationVMValidator : AbstractValidator<CreateQualificationVM>
    {
        public CreateQualificationVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Name).NotEmpty()
                                .MinimumLength(3)
                                .MaximumLength(50)
                                .MustAsync(async (value, cancelToken) =>
                                {
                                    return (!await unitOfWork.Qualifications.AlreadyExistAsync(value));
                                })
                                .WithMessage("This Name Already Exist!");
        }
    }
}
