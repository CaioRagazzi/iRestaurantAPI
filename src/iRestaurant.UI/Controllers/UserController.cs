using iRestaurant.Application.Dto.User;
using iRestaurant.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iRestaurant.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            var response = await _userService.GetAll(page, pageSize);

            return Ok(response);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(UserDtoRequest userDtoRequest)
        {
            await _userService.Create(userDtoRequest);

            return Ok();
        }
    }
}
