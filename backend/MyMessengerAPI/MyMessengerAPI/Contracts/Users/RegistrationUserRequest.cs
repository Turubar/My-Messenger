using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace MyMessengerAPI.Contracts.Users
{
    public record RegistrationUserRequest(
        [Required(ErrorMessage = "Заполните поле с логином")]
        [MinLength(User.MIN_LOGIN_LENGTH, ErrorMessage = "Слишком короткий логин")]
        [MaxLength(User.MAX_LOGIN_LENGTH, ErrorMessage = "Слишком длинный логин")]
        string Login,

        [Required(ErrorMessage = "Заполните поле с паролем")]
        [MinLength(User.MIN_PASSWORD_LENGTH, ErrorMessage = "Слишком короткий пароль")]
        [MaxLength(User.MAX_PASSWORD_LENGTH, ErrorMessage = "Слишком длинный пароль")] 
        string Password
        );
}
