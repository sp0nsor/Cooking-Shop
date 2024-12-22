namespace CookMatch.API.Contacts.Users
{
    public record LoginUserRequest(
        string Email,
        string Password);
}
