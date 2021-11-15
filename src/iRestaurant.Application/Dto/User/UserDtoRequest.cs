using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Dto.User
{
    public class UserDtoRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
