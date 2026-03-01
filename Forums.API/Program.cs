using Forums.API;
using Forums.API.Data;
using Forums.API.Entities;
using Forums.API.Middleware;
using Forums.API.Repository;
using Forums.API.Services;
using Forums.API.Services.Mapping;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

Log.Information("String Forum.API");
//Controllers

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//Swagger

builder.Services.AddSwaggerGen();
//DbContext

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
//Repository
builder.Services.AddScoped<ITopicRepository,TopicRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

//Service
builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<IAuthService, AuthService>();
//Serilog

builder.Host.UseSerilog((context,configuration)=> configuration.ReadFrom.Configuration(context.Configuration));
//Mapster

var config = new TypeAdapterConfig();
MappingConfig.RegisterMappings(config);
builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

// Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;

                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseDbAutoUpdate();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
