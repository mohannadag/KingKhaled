using API.ViewModels.StaffPerformanceEvaluation;
using API.ViewModels.StaffShifts.EmploymentShifts;
using Core.Models.StaffPerformanceEvaluation;
using Data.UnitOfWorks;
using FluentValidation;

namespace API.Validators.StaffPerformanceEvaluation
{
    public class EvaluationValidator : AbstractValidator<EvaluationVM>
    {
        public EvaluationValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("theres is no Name");
            RuleFor(x => x.Score).NotEmpty().WithMessage("theres is no Name");
            RuleFor(x => x.DepartmentId).NotEmpty().MustAsync(async (value, cancelToken) =>
            {
                return (await unitOfWork.Departments.IsValidIdAsync(value));
            });
            RuleFor(x => x).MustAsync(async (value, cancelToken) =>
            {
                return (await unitOfWork.Evaluation.IsValidToAddEvaluation(value.DepartmentId,(int)value.EvaluationKind));
            });
            
        }
    }
}
