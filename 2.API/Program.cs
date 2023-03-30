using _1.Data.Context;
using _1.Data.Repo;
using Microsoft.EntityFrameworkCore;
using static _1.Data.IRepo.IAllRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IAllRepo<>), typeof(AllRepo<>));
builder.Services.AddDbContext<DatabaseContext>(c => c.UseSqlServer("Server=DESKTOP-JNDR021\\SQLEXPRESS;Database=Net106;Trusted_Connection=True;"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
    .SetIsOriginAllowed((host) => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
