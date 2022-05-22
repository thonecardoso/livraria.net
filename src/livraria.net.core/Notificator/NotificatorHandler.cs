using livraria.net.core.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace livraria.net.core.Notificator
{
    public class NotificatorHandler : INotificator
    {

        private List<Notification> _notifications { get; set; }
        public NotificatorHandler()
        {
            _notifications = new();
        }
        public void AddNotification(Notification notificacao)
        {
            _notifications.Add(notificacao);
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}
