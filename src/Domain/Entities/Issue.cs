using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Issue
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? VideoGame { get; set; }

        public string DescText { get; set; }

        public string? DescImgURL { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();

        public ICollection<Platform> Platforms { get; set; } = new List<Platform>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public bool Censored { get; set; } = false;

        public Issue()
        {
        }

        public Issue(string title, string descText, User user, string? videoGame = null, string? descImgURL = null)
        {
            Title = title;
            DescText = descText;
            DescImgURL = descImgURL;
            User = user;
            UserId = user.Id;
            VideoGame = videoGame;
        }
    }
}
