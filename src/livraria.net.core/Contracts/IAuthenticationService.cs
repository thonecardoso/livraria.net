using livraria.net.core.Dto;
using System.Threading.Tasks;

namespace livraria.net.core.Contracts
{
    public interface IAuthenticationService
    {
        Task<string> TokenGenerate(AuthenticateUserDTO authenticateUserDTO);
    }
}
