using MinimalAPiDemo.EndpointExtensions;

namespace MinimalAPiDemo.Endpoints;

public class HelloEndpoint : IEndpoint
{

    public HelloEndpoint()
    {
    }

    public string Pattern => "hello";
    public HttpMethod Method => HttpMethod.Get;

    public Delegate Handler => Handle;
    
    private string Handle()
    {
        // return $"hello world!, date is: {_dateUtils.GetDateNow()}";
        return "Hello world from endpoint!";

    }
}