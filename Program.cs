
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MinimalAPiDemo;
using MinimalAPiDemo.EndpointExtensions;
using MinimalAPiDemo.Services;

var builder = WebApplication.CreateBuilder(args);
#region  config
// // services registration
// builder.Services.AddSingleton<IDateUtils, DateUtils>();
// // auth
// builder.AddBearerAuthentication();
// // swagger
// builder.AddSwagger();
#endregion config

var app = builder.Build();
#region  config
// // auth
// app.UseBearerAuthentication();
// // swagger
// app.UseSwaggerAndUI();
// // map endpoints
// app.MapMinimalEndpoints();
#endregion config
// configure endpoints
app.MapGet("/", () => "Hello World!");
app.Run("http://localhost:9000/");
