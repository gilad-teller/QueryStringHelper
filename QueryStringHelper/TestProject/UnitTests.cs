using Net.TellerApps.QueryStringHelper;

namespace TestProject
{
    public class UnitTests
    {
        [Fact]
        public void SingleParameterTest()
        {
            Dictionary<string, string> parameters = new()
            {
                ["a"] = "1"
            };
            string queryString = QueryStringHelper.BuildQueryString(parameters);
            Assert.Equal("a=1", queryString);
        }

        [Fact]
        public void MultipleParametersTest()
        {
            Dictionary<string, string> parameters = new()
            {
                ["a"] = "1",
                ["b"] = "2"
            };
            string queryString = QueryStringHelper.BuildQueryString(parameters);
            Assert.Equal("a=1&b=2", queryString);
        }

        [Fact]
        public void IntegerParameterTest()
        {
            Dictionary<string, int> parameters = new()
            {
                ["a"] = 1,
                ["b"] = 2
            };
            string queryString = QueryStringHelper.BuildQueryString(parameters);
            Assert.Equal("a=1&b=2", queryString);
        }

        [Fact]
        public void IntegerKeyTest()
        {
            Dictionary<int, string> parameters = new()
            {
                [1] = "a",
                [2] = "b"
            };
            string queryString = QueryStringHelper.BuildQueryString(parameters);
            Assert.Equal("1=a&2=b", queryString);
        }

        [Fact]
        public void UriParameterTest()
        {
            Dictionary<string, string> parameters = new()
            {
                ["a"] = "http://www.sample.com",
                ["b"] = "2"
            };
            string queryString = QueryStringHelper.BuildQueryString(parameters);
            Assert.Equal("a=http%3a%2f%2fwww.sample.com&b=2", queryString);
        }

        [Fact] public void WhitespaceParameterTest()
        {
            Dictionary<string, string> parameters = new()
            {
                ["a"] = "foo bar",
                ["b"] = "2"
            };
            string queryString = QueryStringHelper.BuildQueryString(parameters);
            Assert.Equal("a=foo+bar&b=2", queryString);
        }

        [Fact]
        public void NullParametersTest()
        {
            Dictionary<string, string> parameters = null;
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => _ = QueryStringHelper.BuildQueryString(parameters));
            Assert.Equal("parameters", exception.ParamName);
        }

        [Fact]
        public void NullKeyTest()
        {
            List<KeyValuePair<string, string>> parameters = new()
            {
                new KeyValuePair<string, string>(null, "a")
            };
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => _ = QueryStringHelper.BuildQueryString(parameters));
            Assert.Equal("Key", exception.ParamName);
        }

        [Fact]
        public void UriBuilderTest()
        {
            Dictionary<string, string> parameters = new()
            {
                ["a"] = "1",
                ["b"] = "2"
            };
            UriBuilder builder = new UriBuilder("http://www.sample.com").AddQueryString(parameters);
            string uri = builder.Uri.ToString();
            Assert.Equal("http://www.sample.com/?a=1&b=2", uri);
        }
    }
}