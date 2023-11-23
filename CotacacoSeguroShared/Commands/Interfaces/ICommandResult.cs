namespace CotacacoSeguroShared.Commands.Interfaces;

public interface ICommandResult
{
    int CodeReturn { get; set; }
    bool Success { get; set; }
    string Message { get; set; }
    object? ResultObject { get; set; }
}
