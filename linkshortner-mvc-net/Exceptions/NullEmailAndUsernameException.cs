namespace linkshortner_mvc_net.Exceptions;

public class NullEmailAndUsernameException : Exception
{
    public NullEmailAndUsernameException(string message) : base(message: message)
    {
    }
}