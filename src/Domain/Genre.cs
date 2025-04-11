using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Genre(string name)
        {
            Name = name;
        }
    }
}
