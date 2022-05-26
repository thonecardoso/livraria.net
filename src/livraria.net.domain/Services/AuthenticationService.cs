using livraria.net.core.Contracts;
using livraria.net.core.Dto;
using livraria.net.domain.Contracts.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace livraria.net.domain.Services
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _repository;

        public AuthenticationService(INotificator notificator, IConfiguration configuration, IUserRepository repository) : base(notificator)
        {
            _configuration = configuration;
            _repository = repository;
        }

        public async Task<string> TokenGenerate(AuthenticateUserDTO authenticateUser)
        {
            var FoundUser = await _repository.Find(user => user.Username == authenticateUser.Username);
            var user = FoundUser.FirstOrDefault();

            if (user == null)
            {
                AddNotification("Userename or password invalid!");
                return null;
            }

            if (user.Password != authenticateUser.Password)
            {
                AddNotification("Userename or password invalid!");
                return null;
            }

            var secret = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtConfigurations:Secret").Value);
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return token;
        }
    }
}
