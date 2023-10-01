using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShareCrypt;
using ShareCrypt.Data;
using ShareCrypt.DbAccess;
using ShareCrypt.Interfaces;
using ShareCrypt.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();

builder.Services.AddSingleton<IUserData, UserData>();
/*builder.Services.AddScoped<IOwnedFfRepo, OwnedFfRepo>();
builder.Services.AddScoped<ISharedRepo, SharedRepo>();
builder.Services.AddScoped<IFfRepo, FfRepo>();*/

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(Options => {

    Options.UseSqlServer(builder.Configuration.GetConnectionString("DF"));


});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureApi();
app.UseAuthorization();

app.MapControllers();

app.Run();
