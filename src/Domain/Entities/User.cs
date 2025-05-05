using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required, StringLength(25, MinimumLength = 4)]
        public string UserName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime RegistrationDate { get; private set; } = DateTime.UtcNow;

        public string? ProfilePhotoURL { get; set; }

        public bool Censored { get; set; } = false;

        public ICollection<Issue> Issues { get; set; } = new List<Issue>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public UserType UserType { get; set; }

        public User()
        {
        }

        public User(string userName, string email, string password, UserType userType, string? profilePhotoURL = null)
        {
            UserName = userName;
            Email = email;
            Password = password;
            ProfilePhotoURL = profilePhotoURL;
            UserType = userType;
        }
    }
}
