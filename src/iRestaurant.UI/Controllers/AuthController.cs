using iRestaurant.Application.Dto.Auth;
using iRestaurant.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iRestaurant.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Auth([FromBody]AuthDtoRequest authDtoRequest)
        {
            var response = await _authService.Auth(authDtoRequest);

            return Ok(response);
        }

        //[HttpPost("google")]
        //public async Task<IActionResult> GoogleAuth([FromBody]GoogleAuthDtoRequest googleAuthDtoRequest)
        //{
        //    var response = await _authService.GoogleAuth(googleAuthDtoRequest);

        //    return Ok(response);
        //}
    }
}
