using Microsoft.EntityFrameworkCore;
using AccountabilityApp.Data;
using AccountabilityApp.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AccountabilityAppDbContext>(opt => opt.UseInMemoryDatabase("AccountabilityDbd"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();

app.Run();
