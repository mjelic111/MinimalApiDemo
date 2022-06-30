using Microsoft.AspNetCore.Authorization;
using MinimalAPiDemo.EndpointExtensions;
using MinimalAPiDemo.Services;

namespace MinimalAPiDemo.Endpoints;

[Authorize]
public class TestEndpoint : IEndpoint
{
    private readonly IDateUtils _dateUtils;

    public TestEndpoint(IDateUtils dateUtils)
    {
        _dateUtils = dateUtils;
    }

    public string Pattern => "test/{age:int}";
    public HttpMethod Method => HttpMethod.Get;

    public Delegate Handler => Handle;
    
    private string Handle(int age)
    {
        return $"Test hello world!, age is: {age}, date is {_dateUtils.GetDateNow()}";

    }
}