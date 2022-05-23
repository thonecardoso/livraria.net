using System.Threading.Tasks;

namespace livraria.net.domain.Contracts.Logger
{
    public interface ILog
    {
        Task Information(int Id, string Message, string OperationType);
        Task Error(int Id, string Message, string OperationType);
    }
}
