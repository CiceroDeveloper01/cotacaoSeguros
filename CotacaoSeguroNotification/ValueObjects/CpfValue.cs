using System.Net;

namespace CotacaoSeguroNotification.ValueObjects;

public class CpfValue : ValueObject
{
    public CpfValue(string cpf)
    {
        Cpf = cpf;
        Validate();
    }

    public sealed override void Validate()
    {
        IsInvalidCpf(Cpf, InvalidCpf);
    }

    public string Cpf { get; }
}
