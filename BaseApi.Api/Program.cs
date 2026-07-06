using BaseApi.Api.Configurations;
using BaseApi.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Api
builder.Services.AddApiConfiguration();

//Swagger
builder.Services.AddSwaggerConfiguration();

//Infrastructura
builder.Services.AddInfrastructure();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();

app.UseApplicationMiddleware();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
