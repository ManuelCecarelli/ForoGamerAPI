using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string ContentText { get; set; }

        public string? ContentImgURL { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }

        public User User { get; set; }

        public int IssueId { get; set; }

        public Issue Issue { get; set; }

        public int? ResponseTo { get; set; }

        public bool Censored { get; set; } = false;

        public Comment()
        {
        }

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
