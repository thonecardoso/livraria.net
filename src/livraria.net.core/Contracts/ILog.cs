using System.Threading.Tasks;

namespace livraria.net.core.Contracts
{
    public interface ILog
    {
        Task Information(int id, string message, string operationType);
        Task Error(int id, string message, string operationType);
    }
}
