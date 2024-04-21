namespace Services.Services.Base;

public class Response<T>(T data, bool success, IEnumerable<string> messages = null)
{
    public bool Success { get; set; } = success;
    public T Data { get; set; } = data;
    public IEnumerable<string> Messages { get; set; } = messages;
}