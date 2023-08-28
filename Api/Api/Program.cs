using Core.Interfaces;
using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;
using InfraStructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Api.AutoMapperProfile;
using Api.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Constr")).UseLazyLoadingProxies();
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("Corspolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
var app = builder.Build();
app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStatusCodePagesWithReExecute("/Errors/{0}");
app.UseHttpsRedirection();
app.UseCors("Corspolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();
using var Scope = app.Services.CreateScope();
var services = Scope.ServiceProvider;
var context=services.GetRequiredService<AppDbContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync();
}
catch (Exception ex)
{
    logger.LogError("Error Migration During Process");
}
app.Run();
