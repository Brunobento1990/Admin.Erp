using System.Net;

namespace Admin.Erp.Domain.Exceptions;

public class ErroApiException : Exception
{
    public HttpStatusCode? HttpStatusCode { get; set; }
    public ErroApiException(string message, HttpStatusCode? httpStatusCode = null) : base(message)
    {
        HttpStatusCode = httpStatusCode;
    }
}
