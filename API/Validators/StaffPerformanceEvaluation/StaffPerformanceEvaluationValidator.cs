using API.ViewModels.JobGroup;
using API.ViewModels.StaffPerformanceEvaluation;
using Data.UnitOfWorks;
using FluentValidation;

namespace API.Validators.StaffPerformanceEvaluation
{
    public class StaffPerformanceEvaluationValidator : AbstractValidator<EmploymentPerformanceEvaluationVM>
    {
        public StaffPerformanceEvaluationValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.EmployeeId).NotEmpty()
                                .MustAsync(async (value, cancelToken) =>
                                {
                                    return (await unitOfWork.Employees.IsValidIdAsync(value));
                                })
                                .WithMessage("this employee is not in the job!");

            RuleFor(x => x.StartDateEvaluation.DayOfYear).NotEmpty().GreaterThanOrEqualTo(DateTime.Now.DayOfYear)
                                       
                                       .WithMessage("date time for start Evaluation is not valid!");
            RuleFor(x => x.EndDateEvaluation.DayOfYear).NotEmpty().GreaterThanOrEqualTo(DateTime.Now.DayOfYear)

                                  .WithMessage("date time for end Evaluation is not valid!");
            RuleFor(x => x.EvaluationType).NotEmpty().WithMessage("Evaluation Kind Is Empty");
            RuleFor(x => x).MustAsync(async (value, cancelToken) =>
            {
                return (await unitOfWork.EmploymentPerformanceEvaluation.CanTackEvaluation((int)value.EvaluationType, value.EmployeeId));
            }).WithMessage("Can't tack this evaluation at this time ");
        }
    }
}
