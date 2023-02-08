namespace linkshortner_mvc_net.Exceptions;

public class RedirectIdAlreadyExistException : Exception
{
    public RedirectIdAlreadyExistException(string message) : base(message: message)
    {
    }
}