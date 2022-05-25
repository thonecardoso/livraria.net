using System.Threading.Tasks;

namespace livraria.net.core.Contracts.Logger
{
    public interface ILog
    {
        Task<bool> Information(int id, string message, string operationType);
        Task<bool> Error(int id, string message, string operationType);
    }
}
