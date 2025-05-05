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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //restricciones en propiedades
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(30);
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.UserType).IsRequired();

            //indices
            builder.HasIndex(u => u.Email).IsUnique();

            //relaciones
            builder.HasMany(u => u.Issues)
               .WithOne(i => i.User)
               .HasForeignKey(i => i.UserId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Comments)
                   .WithOne(c => c.User)
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            //semilla de datos
            builder.HasData(CreateUserDataSeed());
        }

        private User[] CreateUserDataSeed()
        {
            User[] newUsers = [
                new User
                {
                    UserName = "Common User 1",
                    Email = "commonuser1@gmail.com",
                    Password = "user1",
                    UserType = Domain.Enums.UserType.CommonUser
                },
                new User
                {
                    UserName = "Common User 2",
                    Email = "commonuser2@gmail.com",
                    Password = "user2",
                    UserType = Domain.Enums.UserType.CommonUser
                },
                new User
                {
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                    Password = "admin",
                    UserType = Domain.Enums.UserType.Admin
                },
            ];

            return newUsers;
        }
    }
}
