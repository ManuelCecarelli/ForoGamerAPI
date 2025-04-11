using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Issue
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string DescText { get; set; }

        public string? DescImgURL { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        public User User { get; set; }

        public ICollection<Genre>? Genres { get; set; } = new List<Genre>();

        public ICollection<Platform>? Platforms { get; set; } = new List<Platform>();

        public ICollection<Comment>? Comments { get; set; } = new List<Comment>();

        public bool Censored { get; set; } = false;

        public Issue(string title, string descText, User user, string? descImgURL = null)
        {
            Title = title;
            DescText = descText;
            DescImgURL = descImgURL;
            User = user;
        }
    }
}
