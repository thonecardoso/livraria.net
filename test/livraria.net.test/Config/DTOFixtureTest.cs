using Bogus;
using Bogus.DataSets;
using livraria.net.api.Dto;
using System;
using Xunit;
using static Bogus.DataSets.Name;
using G = livraria.net.api.Enums;

namespace livraria.net.test.Config
{
    [CollectionDefinition(nameof(TestCollection))]
    public class TestCollection : ICollectionFixture<DTOFixtureTest>
    {
    }

    public class DTOFixtureTest : IDisposable
    {
        public AuthorDTO GenerateValidAuthorDTO()
        {
            var faker = new Faker("pt_BR");
            var gender = faker.PickRandom<Name.Gender>();
            var name = faker.Name.FirstName(gender);
            var surname = faker.Name.LastName(gender);
            var age = faker.Random.Int(20, 100);
            var validAuthor = new Faker<AuthorDTO>("pt_BR")
               .CustomInstantiator(f => new AuthorDTO 
               { 
                   Name = name + " " + surname, 
                   Age = age,
               });
            return validAuthor;

        }

        public AuthorDTO GenerateInvalidAuthorDTO()
        {
            return new AuthorDTO
            {
                Name = "",
                Age = 150, 
            };
        }

        public BookRequestDTO GenerateValidBookRequestDTO()
        {
            var faker = new Faker("pt_BR");
            var name = string.Join(" ",faker.Lorem.Words(3));
            var isbn = Guid.NewGuid().ToString().Replace("-", "");
            var pages = faker.Random.Int(20, 100);
            var chapters = faker.Random.Int(5, 20);
            var publisherId = faker.Random.Int(1, int.MaxValue);
            var authorId = faker.Random.Int(1, int.MaxValue);
            var validBookRequestDTO = new Faker<BookRequestDTO>("pt_BR")
               .CustomInstantiator(f => new BookRequestDTO
               {
                   Name = name,
                   Isbn = isbn,
                   Pages = pages,
                   Chapters = chapters,
                   PublisherId = publisherId,
                   AuthorId = authorId,
               });
            return validBookRequestDTO;

        }

        public BookRequestDTO GenerateInvalidBookRequestDTO()
        {
            return new BookRequestDTO
            {
                Name = "a",
                Isbn = null,
                Pages = 0,
                Chapters = 0,
                PublisherId = 0,
                AuthorId = 0,
            };
        }

        public PublisherDTO GenerateValidPublisherDTO()
        {
            var faker = new Faker("pt_BR");
            var name = string.Join(" ", faker.Lorem.Words(3));
            var code = Guid.NewGuid().ToString().Replace("-", "");
            var fundationDate = faker.Date.PastOffset().DateTime;
            var validPublisherDTO = new Faker<PublisherDTO>("pt_BR")
               .CustomInstantiator(f => new PublisherDTO
               {
                   Name = name,
                   Code = code,
                   FundationDate = fundationDate
               });
            return validPublisherDTO;

        }

        public PublisherDTO GenerateInvalidPublisherDTO()
        {
            return new PublisherDTO
            {
                Name = "a",
                Code = null,
                FundationDate = null,
            };
        }

        public UserDTO GenerateValidUserDTO()
        {
            var faker = new Faker("pt_BR");
            var gender = faker.PickRandom<Name.Gender>();
            var name = faker.Name.FirstName(gender);
            var surname = faker.Name.LastName(gender);
            var age = faker.Random.Int(20, 100);
            var userGender = gender == Gender.Male ? G.Gender.MALE : G.Gender.FEMALE;
            var username = name + surname;
            var email = faker.Internet.Email(username);
            var password = Guid.NewGuid().ToString().Replace("-", "");
            var days = (int)(age * 365.25) + faker.Random.Int(0, 362);
            var birthdate = DateTime.Now.AddDays(-days);
            var validUserDTO = new Faker<UserDTO>("pt_BR")
               .CustomInstantiator(f => new UserDTO
               {
                   Name = name + " " + surname,
                   Gender = userGender,
                   Age = age,
                   Birthdate = birthdate,
                   Email = email,
                   Password = password,
                   Username = username, 
                   
               });
            return validUserDTO;

        }

        public UserDTO GenerateInvalidUserDTO()
        {
            return new UserDTO
            {
                Name = "a",
                Gender = (G.Gender) 12,
                Age = 0,
                Birthdate = null,
                Email = null,
                Password = null,
                Username = null,
            };
        }

        public ValidatedObject ValidateModel(object model)
        {
            return ModelValidator.Validate(model);
        }

        public void Dispose()
        {
        }
    }

}
