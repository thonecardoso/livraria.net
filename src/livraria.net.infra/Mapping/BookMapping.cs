using livraria.net.domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace livraria.net.infra.Mapping
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired();
            builder.Property(x => x.Isbn)
                .IsRequired();
            builder.Property(x => x.Pages)
                .IsRequired();
            builder.Property(x => x.Chapters)
                .IsRequired();
            builder.Property(x => x.PublisherId)
                .IsRequired();
            builder.Property(x => x.AuthorId)
                .IsRequired();
            builder.Property(x => x.CreatedAt);

            builder.HasData(
               new Book
               {
                   Id = 1,
                   Name = "O Outro Lado da Meia-noite",
                   Chapters = 12,
                   PublisherId = 2,
                   AuthorId = 5,
                   Isbn = "9780688002206",
                   Pages = 598
               },
               new Book
               {
                   Id = 2,
                   Name = "Um estranho no espelho",
                   Chapters = 12,
                   PublisherId = 2,
                   AuthorId = 5,
                   Isbn = "978-85-01-09431-5",
                   Pages = 352
               },
               new Book
               {
                   Id = 3,
                   Name = "O reverso da medalha",
                   Chapters = 12,
                   PublisherId = 2,
                   AuthorId = 5,
                   Isbn = "978-85-01-09400-1",
                   Pages = 592
               },
               new Book
               {
                   Id = 4,
                   Name = "Mestre das chamas",
                   Chapters = 12,
                   PublisherId = 1,
                   AuthorId = 2,
                   Isbn = "978-8580417135",
                   Pages = 592
               },
               new Book
               {
                   Id = 5,
                   Name = "Tempo estranho",
                   Chapters = 12,
                   PublisherId = 1,
                   AuthorId = 2,
                   Isbn = "978-8595083219",
                   Pages = 448
               },
               new Book
               {
                   Id = 6,
                   Name = "A estrada da noite",
                   Chapters = 12,
                   PublisherId = 1,
                   AuthorId = 2,
                   Isbn = "978-8599296134",
                   Pages = 256
               },
               new Book
               {
                   Id = 7,
                   Name = "A dança da morte",
                   Chapters = 12,
                   PublisherId = 3,
                   AuthorId = 1,
                   Isbn = "978-8581050546",
                   Pages = 1248
               },
               new Book
               {
                   Id = 8,
                   Name = "O iluminado",
                   Chapters = 12,
                   PublisherId = 3,
                   AuthorId = 1,
                   Isbn = "978-8581050485",
                   Pages = 464
               },
               new Book
               {
                   Id = 9,
                   Name = "Doutor sono",
                   Chapters = 12,
                   PublisherId = 3,
                   AuthorId = 1,
                   Isbn = "978-8581052434",
                   Pages = 480
               },
               new Book
               {
                   Id = 10,
                   Name = "Anjos e demônios",
                   Chapters = 12,
                   PublisherId = 1,
                   AuthorId = 3,
                   Isbn = "978-9722520508",
                   Pages = 480
               },
               new Book
               {
                   Id = 11,
                   Name = "O código Da Vinci",
                   Chapters = 12,
                   PublisherId = 1,
                   AuthorId = 3,
                   Isbn = "978-6555651041",
                   Pages = 560
               },
               new Book
               {
                   Id = 12,
                   Name = "Os pilares da terra",
                   Chapters = 12,
                   PublisherId = 4,
                   AuthorId = 4,
                   Isbn = "978-8532527691",
                   Pages = 944
               }
           );
        }
    }
}
