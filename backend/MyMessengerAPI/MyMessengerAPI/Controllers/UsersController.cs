using Application.Services;
using Microsoft.AspNetCore.Mvc;
using MyMessengerAPI.Contracts.Users;

namespace MyMessengerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        // Регистрация пользователя
        [Route("[controller]/registration")]
        [HttpPost]
        public async Task<ActionResult> Registration(RegistrationUserRequest request, UsersService usersService)
        {
            var result = await usersService.Register(request.Login, request.Password);

            return Ok();
        }
    }
}
