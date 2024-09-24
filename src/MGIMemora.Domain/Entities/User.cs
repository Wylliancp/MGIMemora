namespace MGIMemora.Domain.Entities
{
    public class User : Entity
    {
        public User(string email, string password, string[] roles)
        {
            Email = email;
            Password = password;
            Roles = roles;
            DateCreate = DateTime.Now;
        }

        public String Email { get; private set; } = default!;
        public String Password { get; private set; } = default!;
        public String[] Roles { get; private set; } = default!;

        public void UpdateRoles(String[] roles)
        {
            this.Roles = roles;
            DateUpdate = DateTime.Now;
        }

        public void UpdateEmail(String email)
        {
            this.Email = email;
            DateUpdate = DateTime.Now;
        }

    }
}