namespace CookMatch.API.Contacts.Users
{
    public record RegisterUserRequest(
        string UserName,
        string Email,
        string Password);
}
