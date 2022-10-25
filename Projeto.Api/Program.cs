using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Projeto.Infra;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
var cs = configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<ProjetoContext>(options =>
{
    options.UseSqlServer(cs, x =>
    {
        x.MigrationsAssembly("Projeto.Infra");
    });
});

builder.Services.AddServicesFrom(new[]
{
    "Projeto.Application",
    "Projeto.Infra"
});
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Projeto Api", Version = "v1" });
});

var cors = "allow";
builder.Services.AddCors(options =>
{
    options.AddPolicy(cors, policy =>
    {
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto API V1");
});

app.UseRouting();

app.UseHsts();
app.UseCors(cors);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();