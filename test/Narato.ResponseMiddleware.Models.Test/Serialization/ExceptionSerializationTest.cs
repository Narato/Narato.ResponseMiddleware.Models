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
            try {
                var deserializedException = Clone(exception);
                Assert.Equal(deserializedException.ErrorCode, ErrorCode);
            }
            catch(Exception ex) {
                Assert.Null(ex.Message);
            }
        }

        [Fact]
        public void ExceptionWithFeedBackSerializationTest()
        {
            var ErrorCode = "EWFTest";
            var exception = new ExceptionWithFeedback(ErrorCode, "Test Message");
            try
            {
                var deserializedException = Clone(exception);
                Assert.Equal(deserializedException.ErrorCode, ErrorCode);
            }
            catch (SerializationException ex)
            {
                Assert.Null(ex.Message);
            }
        }

        [Fact]
        public void ForbiddenExceptionSerializationTest()
        {
            var ErrorCode = "FTest";
            var exception = new ForbiddenException(ErrorCode, "Test Feedback");
            try
            {
                var deserializedException = Clone(exception);
                Assert.Equal(deserializedException.ErrorCode, ErrorCode);
            }
            catch (SerializationException ex)
            {
                Assert.Null(ex.Message);
            }
        }

        [Fact]
        public void UnauthorizedExceptionSerializationTest()
        {
            var ErrorCode = "UATest";
            var exception = new UnauthorizedException(ErrorCode, "Test Feedback");
            try
            {
                var deserializedException = Clone(exception);
                Assert.Equal(deserializedException.ErrorCode, ErrorCode);
            }
            catch (SerializationException ex)
            {
                Assert.Null(ex.Message);
            }
        }

        [Fact]
        public void ValidationExceptionSerializationTest()
        {
            var testKey = "TestKey";
            var modelDictionary = new ModelValidationDictionary<string>() { };
            modelDictionary.Add(testKey, "TestValue");
            var exception = new ValidationException<string>(modelDictionary);
            try
            {
                var deserializedException = Clone(exception);
                Assert.Equal(1, deserializedException?.ValidationMessages?.Count);
                Assert.True(deserializedException?.ValidationMessages?.ContainsKey(testKey));
            }
            catch (SerializationException ex)
            {
                Assert.Null(ex.Message);
            }
            
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
