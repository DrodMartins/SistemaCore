using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.Notification
{
    public class NotificationHandle : INotificationHandler<NotificationDomain>
    {
        private List<NotificationDomain> _notification;

        public NotificationHandle()
        {
            _notification = new List<NotificationDomain>();
        }

        public Task Handle(NotificationDomain notification, CancellationToken cancellationToken)
        {
            _notification.Add(notification);

            return Task.CompletedTask;
        }

        public virtual List<NotificationDomain> GetNotifications()
        {
            return _notification;
        }

        public virtual bool HasNotifications()
        {
            return _notification.Any();
        }

        public void Dispose()
        {
            _notification = new List<NotificationDomain>();
        }
    }
}
