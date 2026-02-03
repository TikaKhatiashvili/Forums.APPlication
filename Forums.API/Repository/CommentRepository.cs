using Forums.API.Data;
using Forums.API.Entities;

namespace Forums.API.Repository;

public class CommentRepository : BaseRepository<Comment, ApplicationDbContext>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext context) : base(context)
    {
    }

}