using Microsoft.EntityFrameworkCore;
using TrackAPI.Data;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using TrackAPI.Interfaces;
using TrackAPI.Repository;
using TrackAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using OfficeOpenXml;
using TrackAPI.Controllers;



var builder = WebApplication.CreateBuilder(args);
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<TrackDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

//builder.Services.AddCors(p => p.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()));
 builder.Services.Configure<IISServerOptions>(options =>
    {
        options.MaxRequestBodySize = int.MaxValue; // Set maximum request body size to the maximum value
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",new OpenApiInfo {Title="YourApi" , Version="v1"});

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert token",
        Name = "Authroization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference= new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            }
        },
        new string[]{}
        }
    });
   

});
 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        };
    });



builder.Services.AddScoped<IUser,AddUserRepo>();
builder.Services.AddScoped<ADDUSERServices,ADDUSERServices>();

builder.Services.AddScoped<ILogin,LoginRepo>();
builder.Services.AddScoped<LoginService,LoginService>();

builder.Services.AddTransient<AddUserController>();
builder.Services.AddTransient<BatchController>();


builder.Services.AddScoped<IBatch,BatchRepo>();
builder.Services.AddScoped<BatchServices,BatchServices>();

builder.Services.AddScoped<ITask,AddTaskRepo>();
builder.Services.AddScoped<AddTaskServices,AddTaskServices>();

builder.Services.AddScoped<ITaskSub,TaskSubRepository>();
builder.Services.AddScoped<TaskSubServices,TaskSubServices>();

builder.Services.AddScoped<IRating,RatingRepo>();
builder.Services.AddScoped<RatingServices,RatingServices>();

builder.Services.AddScoped<IDailyUpdate,DailyUpdateRepo>();
builder.Services.AddScoped<DailyUpdateService,DailyUpdateService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        c=>{c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();
