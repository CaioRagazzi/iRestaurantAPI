using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Dto.Auth
{
    public class AuthDtoRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
