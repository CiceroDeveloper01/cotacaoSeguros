using CotacaoSeguroNotification.Interfaces.Errors;

namespace CotacaoSeguroNotification.Errors;

public class Critical : ILevel
{
    public string Description { get; }

    public Critical(string description = "Critical")
    {
        Description = description;
    }

    public override string ToString()
    {
        return Description;
    }

}