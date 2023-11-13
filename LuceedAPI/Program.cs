using LuceedAPI.Interfaces;
using LuceedAPI.Services;
using LuceedAPI.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddScoped<ILuceedApiService, LuceedApiService>();

var app = builder.Build();

app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();