using linkshortner_mvc_net.Interfaces;

namespace linkshortner_mvc_net.Exceptions;

public class PasswordsDoNotMatchException : Exception
{
    public PasswordsDoNotMatchException(string? message) : base(message: message)
    {
    }
    
}