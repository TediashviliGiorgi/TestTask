using Microsoft.EntityFrameworkCore;
using TestTask.Application.Commands.Users;
using TestTask.Application.Services.Hashing;
using TestTask.Domain.Interfaces;
using TestTask.Infrastructure;
using TestTask.Infrastructure.Persistence.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateUserCommandHandler)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(DeleteUserCommandHandler)));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppToDB")));


builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
