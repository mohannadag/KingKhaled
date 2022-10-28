using API.ViewModels.StaffShifts.WorkShift;
using Data.UnitOfWorks;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace API.Validators.StaffShifts
{
    public class CreateWorkShitsValidator : AbstractValidator<WorkShiftsVM>
    {
        public CreateWorkShitsValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("theres is no Name");
            RuleFor(x=>x.StartShift).NotEmpty().WithMessage("theres is no Start Date");
            RuleFor(x => x.EndShift).NotEmpty().WithMessage("theres is no End Date");

        }
    }
}
