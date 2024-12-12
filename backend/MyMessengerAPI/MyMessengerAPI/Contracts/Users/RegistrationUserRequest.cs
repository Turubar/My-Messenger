using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace MyMessengerAPI.Contracts.Users
{
    public record RegistrationUserRequest(
        [Required][MinLength(User.MIN_LOGIN_LENGTH)][MaxLength(User.MAX_LOGIN_LENGTH)] string Login,
        [Required][MinLength(User.MIN_PASSWORD_LENGTH)][MaxLength(User.MAX_PASSWORD_LENGTH)] string Password
        );
}
