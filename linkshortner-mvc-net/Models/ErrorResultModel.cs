using System.Net;

namespace linkshortner_mvc_net.Models;

public class ErrorResultModel
{
    public string? Message { get; set; } = "";
    public int StatusCode { get; set; } = (int)HttpStatusCode.InternalServerError;
}