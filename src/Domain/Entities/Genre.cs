using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public Genre(string name, string? description = null)
        {
            Name = name;
            Description = description;
        }
    }
}
