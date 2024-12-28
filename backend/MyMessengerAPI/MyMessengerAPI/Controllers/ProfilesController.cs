using Application.Services;
using Core.Models;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMessengerAPI.Contracts.Profiles;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        // Маршрут для получения профиля пользователя
        [Route("profile/{searchTag?}")]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Profile(string? searchTag)
        {
            // Получаем токен из кук и проверяем его

            string? token = Request.Cookies["token"];

            if (token == null)
                return BadRequest();

            // ---

            // Проверяем параметр searchTag (для получения чужого профиля),
            // вызываем нужный метод в зависимости от значения

            Result<Profile> result;
            bool isMyProfile = false;

            if (searchTag == null)
            {
                result = await _profilesService.GetProfileByToken(token);
                isMyProfile = true;
            }
            else
                result = await _profilesService.GetProfileBySearchTag(searchTag);
            
            // ---

            if (result.IsSuccess)
            {
                if (!isMyProfile)
                    isMyProfile = searchTag == result.Value.SearchTag;

                //if (result.Value.Avatar != null)
                //    return Ok(new ProfileDataResponse(result.Value.DisplayName, result.Value.Status, result.Value.Description, result.Value.SearchTag, result.Value.Avatar.FileName, isMyProfile));
                //else
                //    return Ok(new ProfileDataResponse(result.Value.DisplayName, result.Value.Status, result.Value.Description, result.Value.SearchTag, null, isMyProfile));

                return Ok(new ProfileDataResponse(result.Value.DisplayName, result.Value.Status, result.Value.Description, result.Value.SearchTag, "ava.png", isMyProfile));
            }
            else 
                return BadRequest(new
                {
                    errors = new
                    {
                        message = result.Error
                    }
                });
        }
    }
}
