using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Dto.Auth
{
    public class GoogleAuthDtoRequest
    {
        public string AccessToken { get; set; }
        public string IdToken { get; set; }
        public string RefreshToken { get; set; }
        public string Type { get; set; }
        public GoogleUser User { get; set; }
    }

    public class GoogleUser
    {
        public string Email { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
    }
}
