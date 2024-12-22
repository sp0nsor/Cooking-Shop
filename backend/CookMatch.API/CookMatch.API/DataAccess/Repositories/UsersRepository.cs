using CookMatch.API.Core.Abstractions.Repositories;
using CookMatch.API.Core.Enums;
using CookMatch.API.Core.Models;
using CookMatch.API.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookMatch.API.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly CookMatchDbContext context;

        public UsersRepository(CookMatchDbContext context)
        {
            this.context = context;
        }

        public async Task Add(User user)
        {
            var roleEntity = await context.Roles
                .SingleOrDefaultAsync(r => r.Id == (int)Role.User)
                ?? throw new InvalidOperationException();

            var userEntity = new UserEntity()
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
                Roles = [roleEntity]
            };

            await context.Users.AddAsync(userEntity);
            await context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();

            var (user, error) = User.Create(userEntity.Id, userEntity.UserName, userEntity.PasswordHash, userEntity.Email);

            return user;
        }

        public async Task<ICollection<Permission>> GetUserPermissions(Guid userId)
        {
            var roles = await context.Users
                .AsNoTracking()
                .Include(u => u.Roles)
                .ThenInclude(u => u.Permissions)
                .Where(u => u.Id == userId)
                .Select(u => u.Roles)
                .ToArrayAsync();

            return roles
                .SelectMany(r => r)
                .SelectMany(r => r.Permissions)
                .Select(p => (Permission)p.Id)
                .ToList();
        }
    }
}
