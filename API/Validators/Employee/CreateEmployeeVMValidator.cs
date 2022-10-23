using API.ViewModels.Employee;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Employee
{
    public class CreateEmployeeVMValidator : AbstractValidator<CreateEmployeeVM>
    {
        public CreateEmployeeVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Phone).NotEmpty().MinimumLength(10).MaximumLength(13);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Address).NotEmpty().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.BirthDate).NotEmpty().LessThan(DateTime.Now);
            RuleFor(x => x.BirthDateHijri).NotEmpty();
            RuleFor(x => x.PlaceOfBirth).NotEmpty().MinimumLength(3).MaximumLength(25);

            RuleFor(x => x.Gender).NotEmpty().IsInEnum();
            RuleFor(x => x.Religion).NotEmpty().IsInEnum();
            RuleFor(x => x.MarritalStatus).NotEmpty().IsInEnum();

            RuleFor(x => x.ArabicName).NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(50);

            RuleFor(x => x.EnglishName).NotEmpty()
                                       .MinimumLength(3)
                                       .MaximumLength(50);

            RuleFor(x => x.JobVacancyId).NotEmpty()
                                        .MustAsync(async (value, cancelToken) =>
                                        {
                                            return (await unitOfWork.JobVacancy.IsValidIdAsync(value));
                                        })
                                        .WithMessage("Job Not Found!");

            RuleFor(x => x.GradeId).NotEmpty()
                                   .MustAsync(async (value, cancelToken) =>
                                   {
                                       return (await unitOfWork.Grades.IsValidIdAsync(value));
                                   })
                                   .WithMessage("Grade Not Found!");

            RuleFor(x => x.LevelId).NotEmpty()
                                   .MustAsync(async (value, cancelToken) =>
                                   {
                                       return (await unitOfWork.Levels.IsValidIdAsync(value));
                                   })
                                   .WithMessage("Level Not Found!");

            RuleFor(x => x.BranchId).NotEmpty()
                                    .MustAsync(async (value, cancelToken) =>
                                    {
                                        return (await unitOfWork.Branches.IsValidIdAsync(value));
                                    })
                                    .WithMessage("Branche Not Found!");

            RuleFor(x => x.NationalityId).NotEmpty()
                                         .MustAsync(async (value, cancelToken) =>
                                         {
                                             return (await unitOfWork.Nationalities.IsValidIdAsync(value));
                                         })
                                         .WithMessage("Nationality Not Found!");

            RuleFor(x => x.QualificationId).NotEmpty()
                                           .MustAsync(async (value, cancelToken) =>
                                           {
                                               return (await unitOfWork.Qualifications.IsValidIdAsync(value));
                                           })
                                           .WithMessage("Qualification Not Found!");

            When(x => (x.LevelId > 0 && x.GradeId > 0),
                () =>
                {
                    RuleFor(x => x).MustAsync(async (value, canselToken) =>
                    {
                        return await unitOfWork.Salaries.IsValidSalaryAsync(value.LevelId, value.GradeId);
                    })
                    .WithMessage("There is No Salary for this Grade and Level!");
                });

            When(x => (x.JobVacancyId > 0 && x.GradeId > 0),
                () =>
                {
                    RuleFor(x => x).MustAsync(async (value, canselToken) =>
                    {
                        return await unitOfWork.JobVacancy.IsValidJobVacancyIdForGradeAsync(value.JobVacancyId, value.GradeId);
                    })
                    .WithMessage("This JobVacancy is Not Suitable for this Employee Depend on Grade and Level!");
                });
        }
    }
}
