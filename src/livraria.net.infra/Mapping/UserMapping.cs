using livraria.net.core.Enums;
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


            builder.HasData(
                new User
                {
                    Id = 1,
                    Name = "Isabela Batista",
                    Age = 28,
                    Gender = (Gender) 2,
                    Email = "isabelabatista@livraria.net",
                    Username = "IsabelaBatista",
                    Password = "42119ca2398640f1a0322652cd91876f",
                    Birthdate = System.DateTime.Parse("1993-09-29")
                }
            );
        }
    }
}
