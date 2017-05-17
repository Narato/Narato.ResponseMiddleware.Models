using Narato.ResponseMiddleware.Models.Exceptions;
using Xunit;

namespace Narato.ResponseMiddleware.Models.Test.Exceptions
{
    public class EntityNotFoundExceptionTest
    {
        [Fact]
        public void MessageNotSetWithDefaultConstructorTest()
        {
            var ex = new EntityNotFoundException();

            Assert.True(string.IsNullOrEmpty(ex.Message));
        }
    }
}
