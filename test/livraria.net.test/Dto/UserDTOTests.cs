using livraria.net.test.Config;
using System.Linq;
using Xunit;

namespace livraria.net.test.Dto
{
    [Collection(nameof(TestCollection))]
    public class UserDTOTests
    {
        private readonly DTOFixtureTest _fixture;

        public UserDTOTests(DTOFixtureTest fixture)
        {
            _fixture = fixture;
        }

        [Trait("Category", "Tests UserDTO")]
        [Fact(DisplayName = "Validate Valid UserDTO")]
        public void UserDTO_ValidateModel_WhenAValidUserDTOIsInformedItShouldBeInvalid()
        {
            // Arrange
            var validUserDTO = _fixture.GenerateValidUserDTO();

            // Act
            var validatedUserDTO = _fixture.ValidateModel(validUserDTO);

            // Assert
            Assert.True(validatedUserDTO.IsValid);
        }

        [Trait("Category", "Tests UserDTO")]
        [Fact(DisplayName = "Validate Invalid UserDTO")]
        public void UserDTO_ValidateModel_WhenInvalidUserDTOIsInformedItShouldBeInvalid()
        {
            // Arrange
            var invalidUserDTO = _fixture.GenerateInvalidUserDTO();

            // Act
            var validatedUserDTO = _fixture.ValidateModel(invalidUserDTO);

            // Assert
            Assert.False(validatedUserDTO.IsValid);
            Assert.Equal(6, validatedUserDTO.ErrorMessages.Count());
            Assert.True(validatedUserDTO.ErrorMessages.Contains("O campo Nome precisa ter entre 2 e 50 caracteres"));
            Assert.True(validatedUserDTO.ErrorMessages.Contains("O campo Idade do Usuário precisa estar entre 1 e 120"));
            Assert.True(validatedUserDTO.ErrorMessages.Contains("O campo e-mail precisa ser fornecido"));
            Assert.True(validatedUserDTO.ErrorMessages.Contains("O campo Username precisa ser fornecido"));
            Assert.True(validatedUserDTO.ErrorMessages.Contains("O campo Password precisa ser fornecido"));
            Assert.True(validatedUserDTO.ErrorMessages.Contains("O campo Data de Nascimento precisa ser fornecido"));
        }
    }
}
