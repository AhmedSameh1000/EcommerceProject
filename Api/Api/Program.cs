using Core.Interfaces;
using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;
using InfraStructure.Repositories;
using Api.AutoMapperProfile;
using Api.MiddleWare;
using Api.Helpers;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using InfraStructure.Seeding;
using API.Models;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<Jwt>(builder.Configuration.GetSection("JWT"));

builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequiredLength = 5; // Set the desired password length here
    opt.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Constr")).UseLazyLoadingProxies();
});





builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddScoped<IInitializer, Initializer>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<ICartItemRepository,CartItemRepository>();
builder.Services.AddScoped<IReviewRepository,ReviewRepository>();





builder.Services.AddCors();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));





var app = builder.Build();

app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var Scope = app.Services.CreateScope();
var services = Scope.ServiceProvider;
var context=services.GetRequiredService<AppDbContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

try
{
    await context.Database.MigrateAsync();
}
catch (Exception ex)
{
    logger.LogError("Error Migration During Process");
}


app.UseStatusCodePagesWithReExecute("/Errors/{0}");
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseHttpsRedirection();
SeddData();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
void SeddData()
{
    using var scope = app.Services.CreateScope();
    var Initalizer = scope.ServiceProvider.GetRequiredService<IInitializer>();
    Initalizer.Intialize().Wait();
}