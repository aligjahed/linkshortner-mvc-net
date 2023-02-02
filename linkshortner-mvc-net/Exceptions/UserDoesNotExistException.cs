namespace linkshortner_mvc_net.Exceptions;

public class UserDoesNotExistException : Exception
{
    public UserDoesNotExistException(string message) : base(message: message)
    {
    }
}