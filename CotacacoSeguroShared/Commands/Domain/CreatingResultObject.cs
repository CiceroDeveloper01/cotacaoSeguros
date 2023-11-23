using CotacacoSeguroShared.Commands.Interfaces;

namespace CotacacoSeguroShared.Commands.Domain;

public class CreatingResultObject : ICommandResult
{
    public CreatingResultObject(int codeReturn, bool success, string message, object? resultObject = null)
    {
        Success = success;
        Message = message;
        ResultObject = resultObject;
        CodeReturn = codeReturn;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public object? ResultObject { get; set; }
    public int CodeReturn { get; set; }
}