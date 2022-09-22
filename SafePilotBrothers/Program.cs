using Microsoft.OpenApi.Models;
using SafePilotBrothers.Model;
using SafePilotBrothers.Model.Interfaces;
using SafePilotBrothers.Services;
using SafePilotBrothers.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
//Настройка сервисов.

builder.Services.AddSwaggerGen(genOptions =>
{
    genOptions.SwaggerDoc("v1", new OpenApiInfo {Title = "SafePilotBrothers", Version = "v1"});
});

builder.Services.AddControllers();
builder.Services.AddSingleton<IStickService, StickService>();
builder.Services.AddSingleton<ISafe, Safe>();

var app = builder.Build();
//Настройка приложения.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();