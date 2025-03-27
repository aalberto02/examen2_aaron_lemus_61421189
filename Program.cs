using examen2_aaron_lemus_61421189.Context;
using examen2_aaron_lemus_61421189.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseDB")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyOrigin().AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Examen 2",
        Version = "v1.0",
        Description = "Documentacion de API para proyecto de clase de examen 2 Programacion Movil"
    });
}
    );

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TaskService>();

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");
app.Run();