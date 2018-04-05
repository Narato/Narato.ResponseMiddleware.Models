using Narato.ResponseMiddleware.Models.Exceptions;
using Narato.ResponseMiddleware.Models.Models;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Xunit;

namespace Narato.ResponseMiddleware.Models.Test.Serialization
{
    public class ExceptionSerializationTest
    {
        [Fact]
        public void EntityNotFoundSerializationTest()
        {
            var ErrorCode = "Test";
            var exception = new EntityNotFoundException(ErrorCode, "Test Message");
            var deserializedException = Clone(exception);
            Assert.Equal(deserializedException.ErrorCode, ErrorCode);
        }

        [Fact]
        public void ExceptionWithFeedBackSerializationTest()
        {
            var ErrorCode = "EWFTest";
            var exception = new ExceptionWithFeedback(ErrorCode, "Test Message");
            var deserializedException = Clone(exception);
            Assert.Equal(deserializedException.ErrorCode, ErrorCode);
        }

        [Fact]
        public void ForbiddenExceptionSerializationTest()
        {
            var ErrorCode = "FTest";
            var exception = new ForbiddenException(ErrorCode, "Test Feedback");
            var deserializedException = Clone(exception);
            Assert.Equal(deserializedException.ErrorCode, ErrorCode);
        }

        [Fact]
        public void UnauthorizedExceptionSerializationTest()
        {
            var ErrorCode = "UATest";
            var exception = new UnauthorizedException(ErrorCode, "Test Feedback");
            var deserializedException = Clone(exception);
            Assert.Equal(deserializedException.ErrorCode, ErrorCode);
        }

        [Fact]
        public void ValidationExceptionSerializationTest()
        {
            var testKey = "TestKey";
            var modelDictionary = new ModelValidationDictionary<string>() { };
            modelDictionary.Add(testKey, "TestValue");
            var exception = new ValidationException<string>(modelDictionary);
            var deserializedException = Clone(exception);
            Assert.Equal(1, deserializedException?.ValidationMessages?.Count);
            Assert.True(deserializedException?.ValidationMessages?.ContainsKey(testKey));
        }

        public static Stream Serialize(object source)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter.Serialize(stream, source);
            return stream;
        }

        public static T Deserialize<T>(Stream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            stream.Position = 0;
            return (T)formatter.Deserialize(stream);
        }

        public static T Clone<T>(T source)
        {
            return Deserialize<T>(Serialize(source));
        }
    }
}
