using Narato.ResponseMiddleware.Models.Models;
using Narato.ResponseMiddleware.Models.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Narato.ResponseMiddleware.Models.Test.Models
{
    public class ModelValidationDictionaryTest
    {
        [Fact]
        public void AddNullFieldShouldThrowTest()
        {
            var testDict = new ModelValidationDictionary<string>();

            Assert.Throws<ArgumentNullException>(() => testDict.Add(null, "meep"));
        }

        [Fact]
        public void AddNullValueShouldThrowTest()
        {
            var testDict = new ModelValidationDictionary<string>();

            Assert.Throws<ArgumentNullException>(() => testDict.Add("meep", null));
        }

        [Fact]
        public void AddShouldCreateNewListTest()
        {
            var testDict = new ModelValidationDictionary<string>();

            testDict.Add("test", "meep");

            Assert.IsType<List<string>>(testDict["test"]);
            Assert.Equal(1, testDict["test"].Count);
            Assert.Equal("meep", testDict["test"].First());
        }

        [Fact]
        public void AddShouldAppendToExistingListTest()
        {
            var testDict = new ModelValidationDictionary<string>();

            testDict.Add("test", "meep");
            testDict.Add("test", "meep2");

            Assert.IsType<List<string>>(testDict["test"]);
            Assert.Equal(2, testDict["test"].Count);
            Assert.Equal("meep", testDict["test"].First());
            Assert.Equal("meep2", testDict["test"].Last());
        }

        [Fact]
        public void AddShouldThrowWhenAddingSameItemTest()
        {
            var testDict = new ModelValidationDictionary<string>();

            testDict.Add("test", "meep");

            var ex = Assert.Throws<Exception>(() => testDict.Add("test", "meep"));
            Assert.Equal("item for field test was already added to validationDictionary: meep", ex.Message);
        }

        [Fact]
        public void VarianceTest()
        {
            var testDict = new ModelValidationDictionary<string>();
            testDict.Add("meep", "moop");

            var castedTestDict = testDict as IModelValidationDictionary<object>;
            Assert.NotNull(castedTestDict);
            Assert.Equal("moop", castedTestDict.Values.First().First());
            Assert.True(testDict is IModelValidationDictionary<object>);
        }

        [Fact]
        public void AddAnotherDictionaryShouldWorkTest()
        {
            var firstDict = new ModelValidationDictionary<string>();
            firstDict.Add("meep", "moop");
            firstDict.Add("meep1", "meepmeep");

            var destinationDict = new ModelValidationDictionary<string>();
            destinationDict.Add("meep", "moopmoop");

            destinationDict.Add(firstDict);

            Assert.Equal(2, destinationDict["meep"].Count);
            Assert.Equal("meepmeep", destinationDict["meep1"].First());
        }
    }
}
