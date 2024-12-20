using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMessengerAPI.Contracts.Profiles;

namespace MyMessengerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _profilesService;

        public ProfilesController(ProfilesService profilesService)
        {
            _profilesService = profilesService;
        }

        // Маршрут Профиль пользователя
        [Route("profile")]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Profile()
        {
            string? token = Request.Cookies["token"];

            if (token == null)
                return BadRequest();

            var result = await _profilesService.GetProfile(token);
            if (result.IsSuccess)
            {
                if (result.Value.Avatar != null)
                    return Ok(new ProfileDataResponse(result.Value.DisplayName, result.Value.Status, result.Value.Description, result.Value.SearchTag, result.Value.Avatar.FileName));
                else
                    return Ok(new ProfileDataResponse(result.Value.DisplayName, result.Value.Status, result.Value.Description, result.Value.SearchTag, null));
            }
            else 
                return BadRequest();
        }
    }
}
