using livraria.net.test.Config;
using System.Linq;
using Xunit;

namespace livraria.net.test.Dto
{
    [Collection(nameof(TestCollection))]
    public class BookRequestDTOTests
    {
        private readonly DTOFixtureTest _fixture;

        public BookRequestDTOTests(DTOFixtureTest fixture)
        {
            _fixture = fixture;
        }

        [Trait("Category", "Tests BookRequestDTO")]
        [Fact(DisplayName = "Validate Valid BookRequestDTO")]
        public void BookRequestDTO_ValidateModel_WhenAValidBookRequestDTOIsInformedItShouldBeInvalid()
        {
            // Arrange
            var validBookRequestDTO = _fixture.GenerateValidBookRequestDTO();

            // Act
            var validatedBookRequestDTO = _fixture.ValidateModel(validBookRequestDTO);

            // Assert
            Assert.True(validatedBookRequestDTO.IsValid);
        }

        [Trait("Category", "Tests BookRequestDTO")]
        [Fact(DisplayName = "Validate Invalid BookRequestDTO")]
        public void BookRequestDTO_ValidateModel_WhenInvalidBookRequestDTOIsInformedItShouldBeInvalid()
        {
            // Arrange
            var invalidBookRequestDTO = _fixture.GenerateInvalidBookRequestDTO();

            // Act
            var validatedBookRequestDTO = _fixture.ValidateModel(invalidBookRequestDTO);

            // Assert
            Assert.False(validatedBookRequestDTO.IsValid);
            Assert.Equal(6, validatedBookRequestDTO.ErrorMessages.Count());
            Assert.True(validatedBookRequestDTO.ErrorMessages.Contains("O campo Nome precisa ter entre 2 e 50 caracteres"));
            Assert.True(validatedBookRequestDTO.ErrorMessages.Contains("O campo Isbn precisa ser fornecido"));
            Assert.True(validatedBookRequestDTO.ErrorMessages.Contains("O campo Paginas precisa ser fornecido e deve ter um valor válido entre 1 e 5000"));
            Assert.True(validatedBookRequestDTO.ErrorMessages.Contains("O campo Capitulos precisa ser fornecido e deve ter um valor válido entre 1 e 200"));
            Assert.True(validatedBookRequestDTO.ErrorMessages.Contains("O campo Id da Editora precisa ser fornecido"));
            Assert.True(validatedBookRequestDTO.ErrorMessages.Contains("O campo Id do Autor precisa ser fornecido"));
        }
    }
}
