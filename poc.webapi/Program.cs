using Microsoft.AspNetCore.Authorization;
using poc;
using poc.Application;
using poc.Infrastructure;
using poc.webapi.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, FlexibleAuthorizationPolicyProvider>();

builder.Services.AddCors(ctx =>
{
    ctx.AddPolicy("AllowAll", cfg =>
    {
        cfg.AllowAnyOrigin();
        cfg.AllowAnyMethod();
        cfg.AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors(cfg =>
{
    cfg.AllowAnyOrigin();
    cfg.AllowAnyMethod();
    cfg.AllowAnyHeader();
});

app.MapControllers();

app.Run();