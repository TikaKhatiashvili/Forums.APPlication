using Forums.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forums.API.Data;

public class ApplicationDbContext:DbContext
{
    //db context მინდა რომ მიიღოს რაღაც ოფშენები და მერე ეს ოფშენები გადასცეს მშობელს DbContext - ს
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
   //ბაზაში ინფორმაცია გავაყოლო C# დან 
   protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var topicalId = new Guid("1c03c62e-b299-483a-ac61-cfa2fa0878c9");
        var topicalId2 = new Guid("1ae2f862-c948-458e-88dd-b1ac4e047648");
        var topicalId3 = new Guid ("922477dc-b396-439d-aefa-8a251a671c43");
        var commentId = new Guid("d8aac92c-411a-4b8e-af15-8cb9a70e7044");
        var commentId2 = new Guid("c5bd2734-c5ba-4928-994b-12260cac0297");

        var crDate=new DateTime(2026, 2, 2);
        var lcDate = new DateTime(2026, 2, 2);

        modelBuilder.Entity<Topic>().HasData(
            new Topic()
            {
                Id = topicalId,
                Title = "First Topic",
                Content = "This is the content of the first topic.",
                CreatedDate = crDate,
                ImageUrl = null,
                LastCommentDate = DateTime.Now,
                CommentsAreAllowed = true                   
            },
              new Topic()
              {
                  Id = topicalId2,
                  Title = "Second Topic",
                  Content = "This is the content of the second topic.",
                  CreatedDate = crDate,
                  ImageUrl = null,
                  LastCommentDate = DateTime.Now,
                  CommentsAreAllowed = true
              }
              ,
              new Topic()
              {
                  Id = topicalId3,
                  Title = "Third Topic",
                  Content = "This is the content of the third topic.",
                  CreatedDate = crDate,
                  ImageUrl = null,
                  LastCommentDate = DateTime.Now,
                  CommentsAreAllowed = true
              }
            );

      

        modelBuilder.Entity<Comment>().HasData(
                new Comment()
                {
                    Id = commentId,
                    CommentDate = lcDate.AddDays(1),
                    Content = "This is the content of the first COMENT.",
                    TopicId = topicalId
                },
                  new Comment()
                  {
                      Id = commentId2,
                      CommentDate = lcDate.AddDays(2),
                      Content = "This is the content of the SECOND COMENT.",
                      TopicId = topicalId2
                  }
                );
    }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
