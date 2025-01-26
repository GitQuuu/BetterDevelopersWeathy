using System.Net;

namespace Services;

/// <summary>
/// This a generic service result object Use in service layer to return a proper error response so upper layer can decide what to do with the response
/// </summary>
/// <typeparam name="T">The responseType</typeparam>
/// <remarks>Why? Because its adheres to separation of concern principle</remarks>
public class ServiceResult<T> where T : class?
{
    public HttpStatusCode? HttpResponse { get; private set; }
    public string? Message { get; private set; }
    public bool Success { get; private set; }
    public T? Data { get; private set; }

    public ServiceResult()
    {
		
    }

    public ServiceResult(bool success, HttpStatusCode? httpResponse, string? message, T? data = null)
    {
        Success      = success;
        HttpResponse = httpResponse;
        Message      = message;
        Data         = data;
    }
	
    public ServiceResult(bool success, HttpStatusCode? httpResponse, T? data = null)
    {
        Success      = success;
        HttpResponse = httpResponse;
        Data         = data;
    }
}