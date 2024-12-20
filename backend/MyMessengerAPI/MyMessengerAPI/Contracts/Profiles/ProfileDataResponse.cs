using Core.Models;

namespace MyMessengerAPI.Contracts.Profiles
{
    public record ProfileDataResponse(string DisplayName, string Status, string Description, string SearchTag, string? pathToAvatar);
}
