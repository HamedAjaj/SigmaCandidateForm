using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SigmaTestTask.Domain;
using System.Reflection.Emit;

namespace SigmaTestTask.Repository.Data.Config
{
    public class ContactConfigurations : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {

            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(c=>c.FirstName).HasMaxLength(50);
            builder.Property(c=>c.LastName).HasMaxLength(50);
            builder.Property(c=>c.Comment).HasMaxLength(500);
        }
    }
}
