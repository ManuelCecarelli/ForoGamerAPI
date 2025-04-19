using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public static GenreDTO Create(Genre genre)
        {
            var dto = new GenreDTO();

            dto.Id = genre.Id;
            dto.Name = genre.Name;
            dto.Description = genre.Description;

            return dto;
        }

        public static List<GenreDTO> CreateList(IEnumerable<Genre> genres)
        {
            List<GenreDTO> listDTO = [];

            foreach (var g in genres)
            {
                listDTO.Add(Create(g));
            }

            return listDTO;
        }
    }
}
