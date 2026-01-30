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

        Guid topicalId = Guid.NewGuid();
        Guid topicalId2 = Guid.NewGuid();
        Guid topicalId3 = Guid.NewGuid();
        Guid commentId = Guid.NewGuid();
        Guid commentId2 = Guid.NewGuid();
        modelBuilder.Entity<Topic>().HasData(
            new Topic()
            {
                Id = topicalId,
                Title = "First Topic",
                Content = "This is the content of the first topic.",
                CreatedDate = DateTime.Now,
                ImageUrl = null,
                LastCommentDate = DateTime.Now,
                CommentsAreAllowed = true                   
            },
              new Topic()
              {
                  Id = topicalId2,
                  Title = "Second Topic",
                  Content = "This is the content of the second topic.",
                  CreatedDate = DateTime.Now,
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
                  CreatedDate = DateTime.Now,
                  ImageUrl = null,
                  LastCommentDate = DateTime.Now,
                  CommentsAreAllowed = true
              }
            );

      

        modelBuilder.Entity<Comment>().HasData(
                new Comment()
                {
                    Id = commentId,
                    CommentDate = DateTime.Now.AddDays(1),
                    Content = "This is the content of the first COMENT.",
                    TopicId = topicalId
                },
                  new Comment()
                  {
                      Id = commentId2,
                      CommentDate = DateTime.Now.AddDays(2),
                      Content = "This is the content of the SECOND COMENT.",
                      TopicId = topicalId2
                  }
                );
    }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
