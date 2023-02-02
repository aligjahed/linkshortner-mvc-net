using linkshortner_mvc_net.Interfaces;

namespace linkshortner_mvc_net.Exceptions;

public class UsernameAlreadyExistException : Exception 
{
    public UsernameAlreadyExistException(string? message) : base(message: message)
    {
    }
    
}