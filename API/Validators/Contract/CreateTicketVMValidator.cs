using API.ViewModels.Tickets;
using Data.UnitOfWorks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Contract
{
    public class CreateTicketVMValidator : AbstractValidator<CreateTicketVM>
    {
        public CreateTicketVMValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Notes).MaximumLength(250);
            RuleFor(x => x.Departure).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.Arrival).NotEmpty().GreaterThanOrEqualTo(x => x.Departure);

            RuleFor(x => x.TicketNumber).NotEmpty()
                                        .MinimumLength(3)
                                        .MaximumLength(100)
                                        .MustAsync(async (value, cancelToken) =>
                                        {
                                            return (!await unitOfWork.Tickets.AlreadyExistAsync(value));
                                        })
                                        .WithMessage("This Ticket Number Already Exist!");

            RuleFor(x => x.ContractId).NotEmpty()
                                      .MustAsync(async (value, cancelToken) =>
                                      {
                                          return (await unitOfWork.Contracts.IsValidIdAsync(value));
                                      })
                                      .WithMessage("Contract Not Found!");
        }
    }
}
