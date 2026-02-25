using System.Net;

namespace Forums.API.Models;

public class CommonResponse
{
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public object Result { get; set; }
    
}

