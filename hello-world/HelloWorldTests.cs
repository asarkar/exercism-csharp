using System.Diagnostics.CodeAnalysis;

[SuppressMessage("Design", "CA1050: Declare types in namespaces")]
public class HelloWorldTests
{
    [Fact]
    [SuppressMessage("Naming", "CA1707: Identifiers should not contain underscores")]
    public void Say_hi()
    {
        Assert.Equal("Hello, World!", HelloWorld.Hello());
    }
}