namespace linkshortner_mvc_net.Exceptions;

public class UrlDoesNotExistException : Exception
{
    public UrlDoesNotExistException(string message) : base(message: message)
    {
    }
}