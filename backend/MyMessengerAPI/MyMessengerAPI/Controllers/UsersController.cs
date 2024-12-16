﻿using Application.Services;
using CSharpFunctionalExtensions;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyMessengerAPI.Contracts.Users;

namespace MyMessengerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;
        private readonly IOptions<JwtOptions> _jwtOptions;

        public UsersController(UsersService usersService, IOptions<JwtOptions> jwtOptions)
        {
            _usersService = usersService;
            _jwtOptions = jwtOptions;
        }

        // Маршрут для регистрации новых пользователей
        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> Registration(RegistrationUserRequest request, UsersService usersService)
        {
            var result = await usersService.Registration(request.Login, request.Password);

            if (result.IsSuccess)
                return Ok();
            else
                return BadRequest(new
                {
                    errors = new
                    {
                        message = result.Error
                    }
                });
        }

        // Маршрут для аутентификации пользователей
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login(LoginUserRequest request, UsersService usersService)
        {
            var token = await usersService.Login(request.Login, request.Password);

            if (token.IsSuccess)
            {
                Response.Cookies.Append("token", token.Value, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTimeOffset.UtcNow.AddHours(_jwtOptions.Value.ExpiresHours)
                });

                return Ok();
            }
            else
            {
                return BadRequest(new
                {
                    errors = new
                    {
                        message = token.Error
                    }
                });
            }
        }
    }
}
