using CotacaoSeguroNotification.Interfaces.Notifications;

namespace CotacaoSeguroNotification.Notifications;

public abstract class Notification : INotification
{
    public IList<object> List { get; } = new List<object>();
    public bool HasNotifications => List.Any();

    public bool Includes(Description error)
    {
        return List.Contains(error);
    }

    public void Add(Description description)
    {
        List.Add(description);
    }
}