using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string ContentText { get; set; }

        public string? ContentImgURL { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        [Required]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public int IssueId { get; set; }

        [Required]
        public Issue Issue { get; set; }

        public int? ResponseTo { get; set; }

        public bool Censored { get; set; } = false;

        public Comment(string contentText, User user, Issue issue, string? contentImgURL = null, int? responseTo = null)
        {
            ContentText = contentText;
            ContentImgURL = contentImgURL;
            User = user;
            UserId = user.Id;
            Issue = issue;
            IssueId = issue.Id;
            ResponseTo = responseTo;
        }
    }
}
