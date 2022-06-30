namespace MinimalAPiDemo.EndpointExtensions;

public interface IEndpoint
{
    public string Pattern { get; }
    public HttpMethod Method { get; }
    public Delegate Handler { get; }
}