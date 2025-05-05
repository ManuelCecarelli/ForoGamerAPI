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

            //semilla de datos
            builder.HasData(CreateUserDataSeed());
        }

        private User[] CreateUserDataSeed()
        {
            User[] newUsers = [
                new User
                {
                    Id = 1,
                    UserName = "Common User 1",
                    Email = "commonuser1@gmail.com",
                    Password = "user1",
                    UserType = Domain.Enums.UserType.CommonUser,
                    RegistrationDate = DateTime.Parse("05/05/2025")
                },
                new User
                {
                    Id = 2,
                    UserName = "Common User 2",
                    Email = "commonuser2@gmail.com",
                    Password = "user2",
                    UserType = Domain.Enums.UserType.CommonUser,
                    RegistrationDate = DateTime.Parse("05/05/2025")
                },
                new User
                {
                    Id = 3,
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                    Password = "admin",
                    UserType = Domain.Enums.UserType.Admin,
                    RegistrationDate = DateTime.Parse("05/05/2025")
                },
            ];

            return newUsers;
        }
    }
}
