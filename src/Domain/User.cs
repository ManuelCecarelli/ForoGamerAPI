using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime RegistrationDate { get; private set; } = DateTime.Now;

        public string? ProfilePhotoURL { get; set; }

        public bool Censored { get; set; } = false;

        public ICollection<Issue>? Issues { get; set; } = new List<Issue>();

        public User(string userName, string email, string password, string? profilePhotoURL = null)
        {
            UserName = userName;
            Email = email;
            Password = password;
            ProfilePhotoURL = profilePhotoURL;
        }
    }
}
