using API.ViewModels.Nationality;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Nationality
{
    public class CreateNationalityVMValidator : AbstractValidator<CreateNationalityVM>
    {
        public CreateNationalityVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ArabicName).NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(50)
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (!await unitOfWork.Nationalities.AlreadyExistArabicAsync(value));
                                      })
                                      .WithMessage("This Arabic Name Already Exist!");

            RuleFor(x => x.EnglishName).NotEmpty()
                                       .MinimumLength(3)
                                       .MaximumLength(50)
                                       .MustAsync(async (value, cancelToken) =>
                                       {
                                           return (!await unitOfWork.Nationalities.AlreadyExistEnglishAsync(value));
                                       })
                                       .WithMessage("This English Name Already Exist!");
        }
    }
}
