namespace CotacaoSeguroNotification.ValueObjects;

public class EmailValue : ValueObject
{
    public EmailValue(string address)
    {
        Address = address;
        Validate();
    }

    public sealed override void Validate()
    {
        IsInvalidEmail(Address, InvalidEmail);
    }

    public string Address { get; }
}