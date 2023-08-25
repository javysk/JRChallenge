using JRChallenge.Application;
using JRChallenge.Application.Interfaces;
using JRChallenge.Application.Permission.Commands;
using JRChallenge.Application.Services;
using JRChallenge.Domain.UOW;
using JRChallenge.Infrastructure;
using JRChallenge.Infrastructure.Elasticsearch;
using JRChallenge.Infrastructure.Kafka;
using JRChallenge.Infrastructure.UOW;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

string  corsOrigins = "JRChallengeAPI";

// Add services to the container.
var cs = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<JRChallengeContext>(opt => opt.UseSqlServer(cs,
    m => m.MigrationsAssembly("JRChallenge.Infrastructure")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplication()
    .AddInfrastructure()

    .AddCors(options =>
    {
        options.AddPolicy(corsOrigins,
                          builder =>
                          {
                              builder.AllowAnyOrigin()
                                     .AllowAnyHeader()
                                     .AllowAnyMethod();
                          });
    })
    .AddTransient<IUnitOfWork, UnitOfWork>()
    .AddTransient<IPermissionService, PermissionService>()
    .AddTransient<IPermissionTypeService, PermissionTypeService>()

    .AddMediatR(x => x.RegisterServicesFromAssemblyContaining(typeof(CreatePermission)))
    .AddMediatR(x => x.RegisterServicesFromAssemblyContaining(typeof(Program)))

    .AddSingleton<IElasticsearchService, ElasticsearchService>()
    .AddSingleton<IKafkaProducer, KafkaProducer>()
    .Configure<ElasticsearchSettings>(builder.Configuration.GetSection("ElasticsearchSettings"));

;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(corsOrigins);

app.MapControllers();

app.Run();

public partial class Program { }