using Application.Services;
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
        [Route("registration")]
        [HttpPost]
        public async Task<ActionResult> Registration(RegistrationUserRequest request, UsersService usersService)
        {
            var result = await usersService.Registration(request.Login, request.Password);

            if (result.IsSuccess)
                return Ok("Пользователь успешно зарегистрирован");
            else
                return BadRequest(result.Error);
        }
    }
}
