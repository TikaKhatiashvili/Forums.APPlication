using Forums.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forums.API.Repository;

public interface ICommentRepository : IBaseRepository<Comment, DbContext>
{
}
