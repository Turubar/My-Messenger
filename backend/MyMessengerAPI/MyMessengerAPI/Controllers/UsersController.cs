using Application.Services;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using MyMessengerAPI.Contracts.Users;

namespace MyMessengerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;
        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
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

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login(LoginUserRequest request, UsersService usersService)
        {
            var token = await usersService.Login(request.Login, request.Password);
            if (token.IsFailure)
                return BadRequest(new
                {
                    errors = new
                    {
                        message = token.Error
                    }
                });

            Response.Cookies.Append("token", token.Value);

            return Ok();
        }
    }
}
