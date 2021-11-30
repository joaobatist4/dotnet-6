using Dotnet6.Extensions;
using Dotnet6.Routes;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureContext();
builder.Services.AddMediatR(typeof(Program).Assembly);

var app = builder.Build();

app.MapProductRoutes();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   
    app.UseSwaggerUI();
}

await app.RunAsync();
