using FluentValidation;
using iRestaurant.Application.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRestaurant.UI.Validators
{
    public class UserValidator : AbstractValidator<UserDtoRequest>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
