using Narato.ResponseMiddleware.Models.Models;
using Narato.StringExtensions;
using Xunit;

namespace Narato.ResponseMiddleware.Models.Test.Deserialization
{
    public class ValidationErrorContentDeserializationTest
    {
        [Fact]
        public void TestValidationErrorContentCanGetDeserialized()
        {
            var json = "{\"validationMessages\":{\"meep\":[\"moop\"]}}";

            var vec = json.FromJson<ValidationErrorContent<string>>();
            Assert.IsType<ModelValidationDictionary<string>>(vec.ValidationMessages);

            var messages = vec.ValidationMessages as ModelValidationDictionary<string>;

            Assert.Contains("meep", messages.Keys);
            Assert.Contains("moop", messages["meep"]);
        }
    }
}
