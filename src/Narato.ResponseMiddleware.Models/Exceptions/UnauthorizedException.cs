namespace Narato.ResponseMiddleware.Models.Exceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException() : base() { }

        public UnauthorizedException(string code, string message)
            : base(code, message) { }
    }
}
