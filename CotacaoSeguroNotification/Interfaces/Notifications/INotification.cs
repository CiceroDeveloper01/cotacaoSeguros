using CotacaoSeguroNotification.Notifications;

namespace CotacaoSeguroNotification.Interfaces.Notifications;

public interface INotification
{
    IList<object> List { get; }
    bool HasNotifications { get; }

    bool Includes(Description error);
    void Add(Description error);
}