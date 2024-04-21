namespace Services.Services.Base;

public class Response<T>(T data, bool success)
{
    public bool Success { get; set; } = success;
    public T Data { get; set; } = data; 
}