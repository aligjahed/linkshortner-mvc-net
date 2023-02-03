namespace linkshortner_mvc_net.Exceptions;

public class UserIsAlreadyLoggedInException : Exception
{
    public UserIsAlreadyLoggedInException(string message) : base(message : message)
    {
    }
}