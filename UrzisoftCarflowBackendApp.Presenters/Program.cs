using Azure.Storage.Blobs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UrzisoftCarflowBackendApp.DatabaseInfrastructure;
using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Repositories;
using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Services;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.Presenters.Settings;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<BlobStorageSettings>(builder.Configuration.GetSection(nameof(BlobStorageSettings)));
var blobStorageSettings = builder.Configuration.GetSection(nameof(BlobStorageSettings)).Get<BlobStorageSettings>();

builder.Services.AddSingleton(blobService => new BlobServiceClient(blobStorageSettings.ConnectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IModelRepository, ModelRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IFuelRepository, FuelRepository>();
builder.Services.AddScoped<IGasStationRepository, GasStationRepository>();
builder.Services.AddScoped<ICarServiceRepository, CarServiceRepository>();
builder.Services.AddScoped<ICarWashStationRepository, CarWashStationRepository>();
builder.Services.AddScoped<IImageStorageService, ImageStorageService>();
builder.Services.AddMediatR(typeof(IUseCasesAssemblyMarker));

var jwtSettings = builder.Configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
     options.SaveToken = true;
     options.RequireHttpsMetadata = false;
     options.TokenValidationParameters = new TokenValidationParameters()
     {
         ValidateIssuer = true,
         ValidateAudience = false,
         ValidAudience = jwtSettings.ValidAudience,
         ValidIssuer = jwtSettings.ValidIssuer,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
     };
 });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ActivePolicy", policy =>
          policy.RequireRole("Active"));
});

builder.Services.AddMediatR(typeof(IUseCasesAssemblyMarker));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
