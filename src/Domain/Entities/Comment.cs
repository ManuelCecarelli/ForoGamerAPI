using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string ContentText { get; set; }

        public string? ContentImgURL { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        public User User { get; set; }

        [Required]
        public Issue Issue { get; set; }

        public int? ResponseTo { get; set; }

        public bool Censored { get; set; } = false;

        public Comment(string contentText, User user, Issue issue, string? contentImgURL = null, int? responseTo = null)
        {
            ContentText = contentText;
            ContentImgURL = contentImgURL;
            User = user;
            Issue = issue;
            ResponseTo = responseTo;
        }
    }
}
