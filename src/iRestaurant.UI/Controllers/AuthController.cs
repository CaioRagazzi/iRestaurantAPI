﻿using iRestaurant.Application.Dto.Auth;
using iRestaurant.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRestaurant.UI.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Auth(AuthDtoRequest authDtoRequest)
        {
            var response = await _authService.Auth(authDtoRequest);

            return Ok(response);
        }
    }
}