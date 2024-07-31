using Microsoft.EntityFrameworkCore;
using AccountabilityApp.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AccountabilityAppDbContext>(opt => opt.UseInMemoryDatabase("AccountabilityDbd"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();

app.Run();
