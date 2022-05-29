using livraria.net.domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace livraria.net.infra.Mapping
{
    public class PublisherMapping : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired();
            builder.Property(x => x.Code)
                .IsRequired();
            builder.Property(x => x.FundationDate)
                .IsRequired();
            builder.HasMany(x => x.Books);
            builder.Property(x => x.CreatedAt);

            builder.HasData(
                new Publisher
                {
                    Id = 1,
                    Name = "Arqueiro",
                    Code = "1111",
                    FundationDate = DateTime.Parse("2011-01-01"),
                },
                new Publisher
                {
                    Id = 2,
                    Name = "Record",
                    Code = "2222",
                    FundationDate = DateTime.Parse("1940-01-01")
                },
                new Publisher
                {
                    Id = 3,
                    Name = "Suma",
                    Code = "3333",
                    FundationDate = DateTime.Parse("1986-01-01")
                },
                new Publisher
                {
                    Id = 4,
                    Name = "Rocco",
                    Code = "4444",
                    FundationDate = DateTime.Parse("1975-03-12")
                }
            );
        }
    }
}