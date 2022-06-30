
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MinimalAPiDemo;
using MinimalAPiDemo.EndpointExtensions;
using MinimalAPiDemo.Services;

var builder = WebApplication.CreateBuilder(args);
// services registration
builder.Services.AddSingleton<IDateUtils, DateUtils>();
// auth
builder.Services.AddAuthorization();
builder.AddBearerAuthentication();
// swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// auth
app.UseAuthentication();
app.UseAuthorization();

// configure endpoints, middleware

app.MapGet("/", () => "Hello World!");

app.UseSwagger();
app.UseSwaggerUI();
app.MapMinimalEndpoints();
app.Run("http://localhost:9000/");
