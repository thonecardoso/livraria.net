using livraria.net.test.Config;
using System.Linq;
using Xunit;

namespace livraria.net.test.Dto
{
    [Collection(nameof(TestCollection))]
    public class AuthorDTOTests
    {
        private readonly DTOFixtureTest _fixture;

        public AuthorDTOTests(DTOFixtureTest fixture)
        {
            _fixture = fixture;
        }

        [Trait("Category", "Tests AuthorDTO")]
        [Fact(DisplayName = "Validate Valid AuthorDTO")]
        public void AuthorDTO_ValidateModel_WhenAValidAuthorDTOIsInformedItShouldBeInvalid()
        {
            // Arrange
            var validAuthorDTO = _fixture.GenerateValidAuthorDTO();

            // Act
            var validatedAuthor = _fixture.ValidateModel(validAuthorDTO);

            // Assert
            Assert.True(validatedAuthor.IsValid);
        }

        [Trait("Category", "Tests AuthorDTO")]
        [Fact(DisplayName = "Validate Invalid AuthorDTO")]
        public void AuthorDTO_ValidateModel_WhenInvalidAuthorDTOIsInformedItShouldBeInvalid()
        {
            // Arrange
            var invalidAuthorDTO = _fixture.GenerateInvalidAuthorDTO();

            // Act
            var validatedAuthor = _fixture.ValidateModel(invalidAuthorDTO);

            // Assert
            Assert.False(validatedAuthor.IsValid);
            Assert.Equal(2, validatedAuthor.ErrorMessages.Count());
            Assert.True(validatedAuthor.ErrorMessages.Contains("O campo nome precisa ser fornecido"));
            Assert.True(validatedAuthor.ErrorMessages.Contains("O campo Idade do Autor precisa estar entre 1 e 120"));
        }
    }
}
