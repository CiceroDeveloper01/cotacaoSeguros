using CotacaoSeguroNotification.Interfaces.Errors;
using CotacaoSeguroNotification.Notifications;

namespace CotacaoSeguroNotification.Errors;

public class ErrorDescription : Description
{
    public ILevel Level { get; }

    public ErrorDescription(string message, ILevel level, params string[] args)
        : base(message, args)
    {
        Level = level;
    }
}