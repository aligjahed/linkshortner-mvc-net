namespace linkshortner_mvc_net.Exceptions;

public class UnauthorizedRequestException : Exception
{
    public UnauthorizedRequestException(string message) : base(message: message)
    {
    }
}