using Narato.ResponseMiddleware.Models.Models;
using Narato.ResponseMiddleware.Models.Models.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace Narato.ResponseMiddleware.Models.Test.Models
{
    public class PagedTest
    {
        [Fact]
        public void CtorShouldDoItsJobTest()
        {
            var items = new List<string> { "1", "2", "3", "4", "5" };
            var paged = new Paged<string>(items, 3, 5, 1000);

            Assert.Equal(paged.Items, items);
            Assert.Equal(10, paged.Skip);
            Assert.Equal(5, paged.Take);
            Assert.Equal(1000, paged.Total);
        }

        [Fact]
        public void VarianceTest()
        {
            var items = new List<string> { "1", "2", "3", "4", "5" };
            var paged = new Paged<string>(items, 3, 5, 1000);

            Assert.True(paged is IPaged<object>);
        }
    }
}
