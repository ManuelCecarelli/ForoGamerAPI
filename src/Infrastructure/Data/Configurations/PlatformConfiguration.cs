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
    public class PlatformConfiguration : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.HasData(CreatePlatformDataSeed());
        }

        private Platform[] CreatePlatformDataSeed()
        {
            Platform[] newPlatforms = [

                new Platform
                {
                    Id = 1,
                    Name= "None",
                    Description = "Sin plataforma"
                },
                new Platform
                {
                    Id = 2,
                    Name= "PC",
                    Description = "Personal Computer"
                },
                new Platform
                {
                    Id = 3,
                    Name= "PS1",
                    Description = "Play Station 1"
                },
                new Platform
                {
                    Id = 4,
                    Name= "PS2",
                    Description = "Play Station 2"
                },
                new Platform
                {
                    Id = 5,
                    Name= "NES",
                    Description = "Nintendo Entertainment System"
                },
                new Platform
                {
                    Id = 6,
                    Name= "SNES",
                    Description = "Super Nintendo Entertainment System"
                },
            ];

            return newPlatforms;
        }
    }
}
