# QueryStringHelper

C# Helper library for building Query string

Use the static method to create a query string from a dictionary:

```C#
Dictionary<string, int> parameters = new()
{
    ["a"] = 1,
    ["b"] = 2
};
string queryString = QueryStringHelper.BuildQueryString(parameters);
Console.WriteLine(queryString); //a=1&b=2
```

Use the UriBuilder extension method to add the query string to the a URI:

```C#
Dictionary<string, string> parameters = new()
{
    ["a"] = "1",
    ["b"] = "2"
};
UriBuilder builder = new UriBuilder("http://www.sample.com")
    .AddQueryString(parameters);
string uri = builder.Uri.ToString();
Console.WriteLine(uri); //http://www.sample.com/?a=1&b=2
```
