using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace MyMessengerAPI.Contracts.Users
{
    public record LoginUserRequest(
        [Required(ErrorMessage = "Заполните поле с логином")]
        string Login,

        [Required(ErrorMessage = "Заполните поле с паролем")]
        string Password);
}
