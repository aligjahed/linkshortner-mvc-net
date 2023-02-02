namespace linkshortner_mvc_net.Exceptions;

public class WrongCredentialsException : Exception
{
    public WrongCredentialsException(string message) : base(message: message)
    {
    }
}