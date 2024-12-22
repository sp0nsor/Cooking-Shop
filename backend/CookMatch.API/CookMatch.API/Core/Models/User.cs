namespace CookMatch.API.Core.Models
{
    public class User
    {
        private User(Guid id, string userName, string passwordHash, string email)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }

        public static(User User, string Error) Create(Guid id, string userName, string passwordHash, string email)
        {
            var error = string.Empty;

            if(string.IsNullOrEmpty(userName) 
                || string.IsNullOrEmpty(passwordHash) 
                || string.IsNullOrEmpty(email))
            {
                error = "Incorrect user data";
            }
            var user = new User(id, userName, passwordHash, email);

            return (user, error);
                        
        }
    }
}
