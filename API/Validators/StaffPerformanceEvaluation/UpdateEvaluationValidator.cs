using API.ViewModels.StaffPerformanceEvaluation;
using Data.UnitOfWorks;
using FluentValidation;

namespace API.Validators.StaffPerformanceEvaluation
{
    public class UpdateEvaluationValidator : AbstractValidator<UpdateEvaluationVM>
    {
        public UpdateEvaluationValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("theres is no Name");
            RuleFor(x => x.Score).NotEmpty().WithMessage("theres is no Name");
            RuleFor(x => x.DepartmentId).NotEmpty().MustAsync(async (value, cancelToken) =>
            {
                return (await unitOfWork.Departments.IsValidIdAsync(value));
            });
        

        }
    }
}
