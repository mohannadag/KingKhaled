using API.ViewModels.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators.Requests
{
    public class UpdateRequestTypeVMValidator : AbstractValidator<UpdateRequestTypeVM>
    {
        public UpdateRequestTypeVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                                .MinimumLength(3)
                                .MaximumLength(50);
        }
    }
}
