using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string? ProfilePhotoURL { get; set; }

        public bool Censored { get; set; }

        public ICollection<Issue> Issues { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public UserType UserType { get; set; }
    }
}
