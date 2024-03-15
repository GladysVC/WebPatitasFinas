using Microsoft.Extensions.Configuration;
using PatasFinasAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<db_Patas_FinasContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("db_Patas_FinasConn")));
builder.Services.AddControllers().AddNewtonsoftJson();//con esta linea se esta usando la nueva dependecia (paquete)

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();


app.UseCors(opcion => {
    opcion.WithOrigins("*");
    opcion.AllowAnyMethod();
    opcion.AllowAnyHeader();
});

app.MapControllers();

app.Run();
