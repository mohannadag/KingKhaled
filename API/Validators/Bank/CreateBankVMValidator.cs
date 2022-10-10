using API.ViewModels.Bank;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Bank
{
    public class CreateBankVMValidator : AbstractValidator<CreateBankVM>
    {
        public CreateBankVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ArabicName).NotEmpty()
                                      .MinimumLength(3)
                                      .MaximumLength(50)
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (!await unitOfWork.Banks.AlreadyExistArAsync(value));
                                      })
                                      .WithMessage("This Arabic Name Already Exist!");

            RuleFor(x => x.EnglishName).NotEmpty()
                                       .MinimumLength(3)
                                       .MaximumLength(50)
                                       .MustAsync(async (value, cancelToken) =>
                                       {
                                           return (!await unitOfWork.Banks.AlreadyExistEnAsync(value));
                                       })
                                       .WithMessage("This English Name Already Exist!");

            RuleFor(x => x.Code).NotEmpty()
                                .MinimumLength(3)
                                .MaximumLength(50)
                                .MustAsync(async (value, cancelToken) =>
                                {
                                    return (!await unitOfWork.Banks.AlreadyExistEnAsync(value));
                                })
                                .WithMessage("This Bank Code Already Exist!");
        }
    }
}
