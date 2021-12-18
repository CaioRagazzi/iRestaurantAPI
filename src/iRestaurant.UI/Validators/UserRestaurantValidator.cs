using FluentValidation;
using iRestaurant.Application.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRestaurant.UI.Validators
{
    public class UserRestaurantValidator : AbstractValidator<UserLoginDtoRequest>
    {
        public UserRestaurantValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.RestaurantName).NotEmpty().NotNull();
        }
    }
}
