using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Platform
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Platform(string name)
        {
            Name = name;
        }
    }
}
