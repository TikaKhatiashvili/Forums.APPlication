using Forums.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forums.API.Data;

public class ApplicationDbContext:DbContext
{
    //db context მინდა რომ მიიღოს რაღაც ოფშენები და მერე ეს ოფშენები გადასცეს მშობელს DbContext - ს
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public ApplicationDbContext()
    {

    }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
