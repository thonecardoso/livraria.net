using livraria.net.test.Config;
using System.Linq;
using Xunit;

namespace livraria.net.test.Dto
{
    [Collection(nameof(TestCollection))]
    public class PublisherDTOTests
    {
        private readonly DTOFixtureTest _fixture;

        public PublisherDTOTests(DTOFixtureTest fixture)
        {
            _fixture = fixture;
        }

        [Trait("Category", "Tests PublisherDTO")]
        [Fact(DisplayName = "Validate Valid PublisherDTO")]
        public void PublisherDTO_ValidateModel_WhenAValidPublisherDTOIsInformedItShouldBeInvalid()
        {
            // Arrange
            var validPublisherDTO = _fixture.GenerateValidPublisherDTO();

            // Act
            var validatedPublisherDTO = _fixture.ValidateModel(validPublisherDTO);

            // Assert
            Assert.True(validatedPublisherDTO.IsValid);
        }

        [Trait("Category", "Tests PublisherDTO")]
        [Fact(DisplayName = "Validate Invalid PublisherDTO")]
        public void PublisherDTO_ValidateModel_WhenInvalidPublisherDTOIsInformedItShouldBeInvalid()
        {
            // Arrange
            var invalidPublisherDTO = _fixture.GenerateInvalidPublisherDTO();

            // Act
            var validatedPublisherDTO = _fixture.ValidateModel(invalidPublisherDTO);

            // Assert
            Assert.False(validatedPublisherDTO.IsValid);
            Assert.Equal(3, validatedPublisherDTO.ErrorMessages.Count());
            Assert.True(validatedPublisherDTO.ErrorMessages.Contains("O campo Nome precisa ter entre 2 e 50 caracteres"));
            Assert.True(validatedPublisherDTO.ErrorMessages.Contains("O campo Código precisa ser fornecido"));
            Assert.True(validatedPublisherDTO.ErrorMessages.Contains("O campo Data de fundação precisa ser fornecido"));
        }
    }
}
