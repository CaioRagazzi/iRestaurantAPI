using iRestaurant.Application.Dto.User;
using iRestaurant.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRestaurant.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRestaurantController : ControllerBase
    {
        private readonly IUserRestaurantService _userRestaurantService;

        public UserRestaurantController(IUserRestaurantService userRestaurantService)
        {
            _userRestaurantService = userRestaurantService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateLogin(UserLoginDtoRequest userDtoRequest)
        {
            await _userRestaurantService.CreateLogin(userDtoRequest);

            return Ok();
        }
    }
}
