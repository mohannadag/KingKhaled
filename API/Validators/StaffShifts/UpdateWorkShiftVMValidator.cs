using API.ViewModels.StaffShifts.EmploymentShifts;
using API.ViewModels.StaffShifts.WorkShift;
using Data.UnitOfWorks;
using FluentValidation;

namespace API.Validators.StaffShifts
{
    public class UpdateWorkShiftVMValidator : AbstractValidator<UpdateEmploymentShiftsVM>
    {
        public UpdateWorkShiftVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.WorkShiftsId).NotEmpty().MustAsync(async (value, cancelToken) =>
            {
                return (await unitOfWork.WorkShifts.IsValidIdAsync(value));
            });


            RuleFor(x => x.MonthDuration.Month).NotEmpty().GreaterThanOrEqualTo(DateTime.Now.Month)
                                   .WithMessage("Month Duration is not true value!");
            RuleFor(x => x.DayNumber).NotEmpty().GreaterThan(0)

                         .WithMessage("Month Duration is not true value!");
            RuleFor(x => x.EmployeeId).NotEmpty()
                                   .MustAsync(async (value, cancelToken) =>
                                   {
                                       return (await unitOfWork.Employees.IsValidIdAsync(value));
                                   })
                                   .WithMessage("Employee Not Found!");
        }
    }
}

