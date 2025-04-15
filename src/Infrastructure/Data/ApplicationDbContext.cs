using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Platform>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Genre>().HasData(CreateGenreDataSeed());
            modelBuilder.Entity<Platform>().HasData(CreatePlatformDataSeed());

            base.OnModelCreating(modelBuilder);
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
