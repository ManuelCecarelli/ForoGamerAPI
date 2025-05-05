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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            //restricciones en propiedades
            builder.Property(c => c.ContentText).IsRequired();
            //builder.Property(c => c.User).IsRequired();
            builder.Property(c => c.UserId).IsRequired();
            //builder.Property(c => c.Issue).IsRequired();
            builder.Property(c => c.IssueId).IsRequired();
        }
    }
}
