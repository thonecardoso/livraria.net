// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using livraria.net.infra.Data;

namespace livraria.net.infra.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("livraria.net.domain.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 75,
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 264, DateTimeKind.Local).AddTicks(4759),
                            Name = "Stephen King"
                        },
                        new
                        {
                            Id = 2,
                            Age = 49,
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 265, DateTimeKind.Local).AddTicks(6385),
                            Name = "Joe Hill"
                        },
                        new
                        {
                            Id = 3,
                            Age = 57,
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 265, DateTimeKind.Local).AddTicks(6535),
                            Name = "Dan Brown"
                        },
                        new
                        {
                            Id = 4,
                            Age = 72,
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 265, DateTimeKind.Local).AddTicks(6537),
                            Name = "Ken Follett"
                        },
                        new
                        {
                            Id = 5,
                            Age = 89,
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 265, DateTimeKind.Local).AddTicks(6538),
                            Name = "Sidney Sheldon"
                        });
                });

            modelBuilder.Entity("livraria.net.domain.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("Chapters")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PublisherId");

                    b.HasIndex("UserId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 5,
                            Chapters = 12,
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(1868),
                            Isbn = "9780688002206",
                            Name = "O Outro Lado da Meia-noite",
                            Pages = 598,
                            PublisherId = 2
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 5,
                            Chapters = 12,
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3255),
                            Isbn = "978-85-01-09431-5",
                            Name = "Um estranho no espelho",
                            Pages = 352,
                            PublisherId = 2
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 5,
                            Chapters = 12,
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3260),
                            Isbn = "978-85-01-09400-1",
                            Name = "O reverso da medalha",
                            Pages = 592,
                            PublisherId = 2
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            Chapters = 12,
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3262),
                            Isbn = "978-8580417135",
                            Name = "Mestre das chamas",
                            Pages = 592,
                            PublisherId = 1
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 2,
                            Chapters = 12,
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3263),
                            Isbn = "978-8595083219",
                            Name = "Tempo estranho",
                            Pages = 448,
                            PublisherId = 1
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 2,
                            Chapters = 12,
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3265),
                            Isbn = "978-8599296134",
                            Name = "A estrada da noite",
                            Pages = 256,
                            PublisherId = 1
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 1,
                            Chapters = 12,
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3266),
                            Isbn = "978-8581050546",
                            Name = "A dança da morte",
                            Pages = 1248,
                            PublisherId = 3
                        },
                        new
                        {
                            Id = 8,
                            AuthorId = 1,
                            Chapters = 12,
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3268),
                            Isbn = "978-8581050485",
                            Name = "O iluminado",
                            Pages = 464,
                            PublisherId = 3
                        },
                        new
                        {
                            Id = 9,
                            AuthorId = 1,
                            Chapters = 12,
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3269),
                            Isbn = "978-8581052434",
                            Name = "Doutor sono",
                            Pages = 480,
                            PublisherId = 3
                        },
                        new
                        {
                            Id = 10,
                            AuthorId = 3,
                            Chapters = 12,
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3270),
                            Isbn = "978-9722520508",
                            Name = "Anjos e demônios",
                            Pages = 480,
                            PublisherId = 1
                        },
                        new
                        {
                            Id = 11,
                            AuthorId = 3,
                            Chapters = 12,
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3271),
                            Isbn = "978-6555651041",
                            Name = "O código Da Vinci",
                            Pages = 560,
                            PublisherId = 1
                        },
                        new
                        {
                            Id = 12,
                            AuthorId = 4,
                            Chapters = 12,
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3273),
                            Isbn = "978-8532527691",
                            Name = "Os pilares da terra",
                            Pages = 944,
                            PublisherId = 4
                        });
                });

            modelBuilder.Entity("livraria.net.domain.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FundationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "1111",
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 269, DateTimeKind.Local).AddTicks(6614),
                            FundationDate = new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Arqueiro"
                        },
                        new
                        {
                            Id = 2,
                            Code = "2222",
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 277, DateTimeKind.Local).AddTicks(2686),
                            FundationDate = new DateTime(1940, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Record"
                        },
                        new
                        {
                            Id = 3,
                            Code = "3333",
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 277, DateTimeKind.Local).AddTicks(2741),
                            FundationDate = new DateTime(1986, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Suma"
                        },
                        new
                        {
                            Id = 4,
                            Code = "4444",
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 277, DateTimeKind.Local).AddTicks(2749),
                            FundationDate = new DateTime(1975, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Rocco"
                        });
                });

            modelBuilder.Entity("livraria.net.domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 28,
                            Birthdate = new DateTime(1993, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2022, 5, 29, 11, 47, 17, 278, DateTimeKind.Local).AddTicks(7691),
                            Email = "isabelabatista@livraria.net",
                            Gender = 2,
                            Name = "Isabela Batista",
                            Password = "42119ca2398640f1a0322652cd91876f",
                            Username = "IsabelaBatista"
                        });
                });

            modelBuilder.Entity("livraria.net.domain.Models.Book", b =>
                {
                    b.HasOne("livraria.net.domain.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .IsRequired();

                    b.HasOne("livraria.net.domain.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .IsRequired();

                    b.HasOne("livraria.net.domain.Models.User", null)
                        .WithMany("Books")
                        .HasForeignKey("UserId");

                    b.Navigation("Author");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("livraria.net.domain.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("livraria.net.domain.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("livraria.net.domain.Models.User", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
