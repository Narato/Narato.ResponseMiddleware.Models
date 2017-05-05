namespace Narato.ResponseMiddleware.Models.Exceptions
{
    // This exception is used when you want to return a 5XX with an error message that does NOT get
    // hidden from the users in production (normal Exceptions their messages get hidden)
    public class ExceptionWithFeedback : BaseException
    {
        public ExceptionWithFeedback(string code, string message) : base(code, message)
        {
        }
    }
}
