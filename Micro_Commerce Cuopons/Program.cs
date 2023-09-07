using Micro_Commerce_Cuopons.Data;
using Micro_Commerce_Cuopons.Extensions;
using Micro_Commerce_Cuopons.Services;
using Micro_Commerce_Cuopons.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject Db Context for Use

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

// Register Services

builder.Services.AddScoped<ICouponInterface , CouponService > ();


//Register Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//On Run apply any Pending Migrations
app.UseMigration();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
