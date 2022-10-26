using API.ViewModels.Allowance;
using API.ViewModels.EmploymentApplications;
using Data.UnitOfWorks;
using FluentValidation;

namespace API.Validators.EmploymentApplications
{
    public class EmploymentApplicationsVMValidator : AbstractValidator<EmploymentApplicationsVM>
    {
        public EmploymentApplicationsVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ArabicName).NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(50)
                                      .WithMessage("This Employment Applications Name is empty!");
            RuleFor(x => x.EmploymentNumber).NotEmpty().WithMessage("the employment application number is empty");
            RuleFor(e=>e.JobId).NotEmpty()
             .MustAsync(async (value, cancelToken) =>
             {
                 return (await unitOfWork.Jobs.IsValidIdAsync(value));
             })
            .WithMessage("the employment application number Already Exist ");
            RuleFor(e => e.PhoneNumber).NotEmpty().WithMessage("This Employment Applications phone number is empty");
            RuleFor(e => e.Religion).NotEmpty().WithMessage("the Religion is empty");
            RuleFor(e => e.NationalityID).NotEmpty()
                .MustAsync(async (value, cancelToken) =>
            {
                return (await unitOfWork.Nationalities.IsValidIdAsync(value));
            });
            RuleFor(e => e.JobVisaID).NotEmpty()
                .MustAsync(async (value, cancelToken) =>
                {
                   return( await unitOfWork.JobVisa.IsValidIdAsync(value));
                });

        }
    }
}
