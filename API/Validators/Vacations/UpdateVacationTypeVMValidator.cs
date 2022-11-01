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
    public class UpdateVacationTypeVMValidator : AbstractValidator<UpdateVacationTypeVM>
    {
        public UpdateVacationTypeVMValidator()
        {
            RuleFor(x => x.DurationPerDay).NotEmpty().InclusiveBetween(1, 30);
            RuleFor(x => x.ArabicName).NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(100);
        }
    }
}
