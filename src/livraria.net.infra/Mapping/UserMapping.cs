using livraria.net.domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace livraria.net.infra.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired();
            builder.Property(x => x.Age)
                .IsRequired();
            builder.Property(x => x.Gender)
                .IsRequired();
            builder.Property(x => x.Email)
                .IsRequired();
            builder.Property(x => x.Username)
                .IsRequired();
            builder.Property(x => x.Password)
                .IsRequired();
            builder.Property(x => x.Birthdate)
                .IsRequired();
            builder.Property(x => x.CreatedAt);
        }
    }
}
