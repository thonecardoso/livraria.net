using livraria.net.core.Notificator;
using System.Collections.Generic;

namespace livraria.net.core.Contracts
{
    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void AddNotification(Notification notification);
    }
}
