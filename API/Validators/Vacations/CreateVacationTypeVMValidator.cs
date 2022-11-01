using API.ViewModels.Vacations;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Vacations
{
    public class CreateVacationTypeVMValidator : AbstractValidator<CreateVacationTypeVM>
    {
        public CreateVacationTypeVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.DurationPerDay).NotEmpty().InclusiveBetween(1, 30);
            RuleFor(x => x.ArabicName).NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(100)
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (!await unitOfWork.VacationTypes.AlreadyExistAsync(value));
                                      })
                                      .WithMessage("This VacationType Already Exist!");
        }
    }
}
