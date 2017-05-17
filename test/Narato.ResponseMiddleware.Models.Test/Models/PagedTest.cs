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
            Assert.Equal(paged.Skip, 10);
            Assert.Equal(paged.Take, 5);
            Assert.Equal(paged.Total, 1000);
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
