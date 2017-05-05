namespace Narato.ResponseMiddleware.Models.Exceptions
{
    public class ForbiddenException : BaseException
    {
        public ForbiddenException() : base() { }

        public ForbiddenException(string code, string message)
            : base(code, message) { }
    }
}
