using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            //restricciones en propiedades
            builder.Property(g => g.Name).IsRequired().HasMaxLength(30);

            //semilla de datos
            builder.HasData(CreateGenreDataSeed());
        }

        private Genre[] CreateGenreDataSeed()
        {
            Genre[] newGenres = [

                new Genre()
                {
                    Id = 1,
                    Name = "None",
                    Description = "Sin género"
                },
                new Genre()
                {
                    Id = 2,
                    Name = "RTS",
                    Description = "Real Time Strategy"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Sports",
                    Description = null
                },
                new Genre
                {
                    Id = 4,
                    Name = "Fighting",
                    Description = null
                },
                new Genre
                {
                    Id = 5,
                    Name = "Racing",
                    Description = null
                },
            ];

            return newGenres;
        }
    }
}
