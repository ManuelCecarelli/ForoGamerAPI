using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Platform
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<Issue> Issues { get; set; } = new List<Issue>();

        public Platform()
        {
        }

        public Platform(string name, string? description = null)
        {
            Name = name;
            Description = description;
        }
    }
}
