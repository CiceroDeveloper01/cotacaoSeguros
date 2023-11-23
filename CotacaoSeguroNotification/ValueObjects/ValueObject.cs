using CotacaoSeguroNotification.Errors;
using System.Text.RegularExpressions;

namespace CotacaoSeguroNotification.ValueObjects;

public class ValueObject
{
    public Error Notification { get; } = new Error();

    public virtual void Validate() { }

    protected void Fail(bool condition, ErrorDescription error)
    {
        if (condition)
            Notification.Add(error);
    }

    public bool IsValid()
    {
        return !Notification.HasErrors;
    }

    #region Validations

    protected void IsInvalidEmail(string s, ErrorDescription error)
    {
        const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        Fail(!Regex.IsMatch(s, pattern), error);
    }

    protected void IsInvalidCpf(string cpf, ErrorDescription error)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digito;
        int soma;
        int resto;
        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");
        if (cpf.Length != 11)
            Fail(cpf.Length != 11, error);
        tempCpf = cpf.Substring(0, 9);
        soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = resto.ToString();
        tempCpf = tempCpf + digito;
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = digito + resto.ToString();

        Fail(!cpf.EndsWith(digito), error);
    }


    #endregion

    #region Errors

    public static ErrorDescription InvalidEmail = new ErrorDescription("Invalid E-mail address", new Critical());
    public static ErrorDescription InvalidCpf = new ErrorDescription("Invalid CPF", new Critical());

    #endregion
}