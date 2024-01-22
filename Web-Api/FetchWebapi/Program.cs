using Microsoft.EntityFrameworkCore;
using FetchWebapi.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var allowedOrigin = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("myAppCors", policy =>
    {
        policy.WithOrigins(allowedorigin).AllowAnyHeader().AllowAnyMethod();
    });
//     options.AddPolicy("myAppCors", policy =>
// {
//     policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
// });
});
builder.Services.AddDbContext<Appdbcontext>(options=>options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),new MySqlServerVersion(new Version())));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// app.UseCors();
app.UseCors("myAppCors");
app.Run();
