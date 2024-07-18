using Serilog;
using Serilog.Events;
using StoreCleanArchitecture.Application;
using StoreCleanArchitecture.Infrastucture;
using StoreCleanArchitecture.Infrastucture.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastucture(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(builder => builder.AllowAnyOrigin());

app.MapGraphQL();
app.MapControllers();

app.Run();
