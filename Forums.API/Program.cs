using Forums.API.Data;
using Forums.API.Middleware;
using Forums.API.Repository;
using Forums.API.Services;
using Forums.API.Services.Mapping;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Information("String Forum.API");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//EntityFramwork ის Db კონტექსტები ესე რეგისტრირდება // builder.Configuration - ის დახმარებით ვიღებთ appsettings.json - დან კავშრის სტრინგს
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
//ერთიცალი სტრინგის აღება appsettings.json - დან
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetValue("Tika:Misamarti")));
// თუ მასივი მაქვს
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.Getსეცტიონ("key")));
//DI
builder.Services.AddScoped<ITopicRepository,TopicRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
//builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<ITopicService, TopicService>();

//ეს კრიფავს ინფორმაცია Appsettings.json-დან
builder.Host.UseSerilog((context,configuration)=> configuration.ReadFrom.Configuration(context.Configuration));

var config = new TypeAdapterConfig();
MappingConfig.RegisterMappings(config);
builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
