using CookMatch.API.Core.Abstractions.Auth;
using CookMatch.API.Core.Abstractions.Repositories;
using CookMatch.API.Core.Abstractions.Services;
using CookMatch.API.Core.Models;

namespace CookMatch.API.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher passwordHasher;
        private readonly IUsersRepository usersRepository;
        private readonly IJwtProvider jwtProvider;

        public UserService(IPasswordHasher passwordHasher,
            IUsersRepository usersRepository,
            IJwtProvider jwtProvider)
        {
            this.passwordHasher = passwordHasher;
            this.usersRepository = usersRepository;
            this.jwtProvider = jwtProvider;
        }

        public async Task Register(string name, string email, string password)
        {
            var passwordHash = passwordHasher.Generate(password);

            var (user, error) = User.Create(Guid.NewGuid(), name, passwordHash, email);

            if (!string.IsNullOrEmpty(error))
            {
                throw new Exception(error);
            }

            await usersRepository.Add(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await usersRepository.GetByEmail(email);

            var result = passwordHasher.Verify(password, user.PasswordHash);

            if (!result)
            {
                throw new Exception("Fail to login");
            }

            var token = jwtProvider.GenerateToken(user);

            return token;
        }

    }
}
