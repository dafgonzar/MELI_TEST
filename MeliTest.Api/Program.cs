using MeliTest.Core.Interface;
using MeliTest.Core.Interfaces;
using MeliTest.Core.Services;
using MeliTest.Infrastructure.Data;
using MeliTest.Infrastructure.Filters;
using MeliTest.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
    options.Filters.Add(typeof(FilterOfExcepcion));
});

// Cadena de Conexión para MySql
builder.Services.AddDbContext<MeliTestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"))
);

// Dependencias propias - (Inyeccion de dependencias)
builder.Services.AddTransient<IContainerRepository, DivisionRepository>();
builder.Services.AddTransient<IContainerService, ContainersService>();


//   Para la configuración del Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MeliTest.Api", Version = "v1" });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

// Validaciones y Filtros
builder.Services.AddMvc(options => { }
).AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});




var app = builder.Build();

// Configure the HTTP request pipeline.  IWebHostEnvironment

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MeliTest.Api v1"));

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UseSwagger();
//    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EcopetrolPlaneacion.Api v1"));
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
