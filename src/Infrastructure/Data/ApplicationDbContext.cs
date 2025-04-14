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
            //base.OnModelCreating(modelBuilder); //revisar

            modelBuilder.Entity<Genre>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Platform>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Genre>().HasData(CreateGenreDataSeed());
            modelBuilder.Entity<Platform>().HasData(CreatePlatformDataSeed());
        }

        private Genre[] CreateGenreDataSeed()
        {
            Genre[] newGenres = [

                new Genre("None", "Sin género"),
                new Genre("RTS", "Real Time Strategy"),
                new Genre("Sports"),
                new Genre("Fighting"),
                new Genre("Racing")
            ];

            return newGenres;
        }

        private Platform[] CreatePlatformDataSeed()
        {
            Platform[] newPlatforms = [

                new Platform("None", "Sin plataforma"),
                new Platform("PC", "Personal Computer"),
                new Platform("PS1", "Play Station 1"),
                new Platform("PS2", "Play Station 2"),
                new Platform("NES", "Nintendo Entertnaiment System"),
                new Platform("SNES", "Super Nintendo Entertnaiment System")
            ];

            return newPlatforms;
        }
    }
}
