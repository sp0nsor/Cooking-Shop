using CookMatch.API.Contacts.Users;
using CookMatch.API.Core.Abstractions.Services;

namespace CookMatch.API.Endpoints
{
    public static class UsersEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("register", Register);
            app.MapPost("login", Login);

            return app;
        }

        private static async Task<IResult> Register(
            RegisterUserRequest request,
            IUserService userService)
        {
            await userService.Register(
                request.UserName,
                request.Email,
                request.Password);

            return Results.Ok();
        }

        private static async Task<IResult> Login(
            LoginUserRequest request,
            IUserService userService,
            HttpContext httpContext)
        {
            var token = await userService.Login(request.Email, request.Password);

            httpContext.Response.Cookies.Append("my-cookies", token);

            return Results.Ok();
        }
    }
}
