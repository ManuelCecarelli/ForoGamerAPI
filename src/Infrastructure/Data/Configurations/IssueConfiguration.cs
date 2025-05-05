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
    public class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            //restricciones en propiedades
            builder.Property(i => i.Title).IsRequired().HasMaxLength(50);
            builder.Property(i => i.DescText).IsRequired();
            builder.Property(i => i.UserId).IsRequired();
            builder.Property(i => i.User).IsRequired();

            //relaciones
            builder.HasOne(i => i.User)
                .WithMany(u => u.Issues);

            builder.HasMany(i => i.Comments)
                .WithOne(c => c.Issue)
                .HasForeignKey(c => c.IssueId);

            builder.HasMany(i => i.Genres);

            builder.HasMany(i => i.Platforms);
        }
    }
}
