using Microsoft.AspNetCore.Authorization;

namespace MinimalAPiDemo.EndpointExtensions;

public static class EndpointExtensions
{
    public static IEndpointRouteBuilder MapMinimalEndpoints(this IEndpointRouteBuilder app)
    {
        // discover endpoints
        var endpointsTypes = typeof(IEndpoint).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IEndpoint)));

        // map endpoints
        foreach (var endpointType in endpointsTypes)
        {
            var endpoint = (IEndpoint)ActivatorUtilities.CreateInstance(app.ServiceProvider, endpointType);
            var authorizeAttribute = System.Attribute.GetCustomAttributes(endpointType).FirstOrDefault(a => a.GetType() == typeof(AuthorizeAttribute));
            if (authorizeAttribute != null)
            {
                app.MapMethods(endpoint.Pattern, new[] { endpoint.Method.ToString() }, endpoint.Handler).RequireAuthorization();
            }
            else
            {
                app.MapMethods(endpoint.Pattern, new[] { endpoint.Method.ToString() }, endpoint.Handler);
            }
        }
        return app;
    }
}