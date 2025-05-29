using Microsoft.EntityFrameworkCore;
using GymMembership.DATA.Entities;
using GymMembership.DATA.Configurations;
using GymMembership.DATA.Infastructures;
using GymMembership.DAL.Repositories;
using GymMembership.API.Controllers;
using GymMembership.DATA;
using GymMembership.SERVICE;
using GymMembership.SERVICE.DTOs;
using GymMembership.SERVICE.Interfaces;
using GymMembership.SERVICE.Mapper;

var builder = WebApplication.CreateBuilder(args);

//This code registers the GymMembershipDbContext with the app's services and configures it to use SQL Server.
//It reads the connection string named "GymConnectionString" from appsettings.json to connect to the database.
builder.Services.AddDbContext<GymMembershipDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration
            .GetConnectionString("GymConnectionString")); // i should add this connection string in appsetting.Json
});


// i need JWT tokens implementation in there ...

//in there i should add builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();


//Dependency Injection (DI) , Register , Repositories , Controllers ..

//Register InterFaces ..
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMembershipService, MembershipService>();
builder.Services.AddScoped<IAdminService, AdminService>();

//Register Repositories ...
builder.Services.AddScoped<IGymClassRepository, GymClassRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserService, UserService>();

//Register Controllers ...
builder.Services.AddControllers();

builder.Services.AddControllers();

//Add the Swagger generator to the services collection in Program.cs:
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();




