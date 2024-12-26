using Microsoft.EntityFrameworkCore;
using SchoolApp.Business.Services;
using SchoolApp.DataAccess.Context;
using SchoolApp.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IClassRoomRepository, ClassRoomRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
