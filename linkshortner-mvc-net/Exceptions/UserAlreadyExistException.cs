using linkshortner_mvc_net.Interfaces;

namespace linkshortner_mvc_net.Exceptions;

public class UserAlreadyExistException : Exception 
{
    public UserAlreadyExistException(string? message) : base(message: message)
    {
    }
    
}