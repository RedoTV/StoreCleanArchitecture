using StoreCleanArchitecture.Application;
using StoreCleanArchitecture.Infrastructure;
using StoreCleanArchitecture.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

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

app.UseCors(build => build.AllowAnyOrigin());

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();