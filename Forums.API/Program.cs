using Forums.API.Data;
using Forums.API.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


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
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
