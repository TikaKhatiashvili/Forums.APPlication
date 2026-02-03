using Forums.API.Data;
using Forums.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forums.API.Repository;

public class TopicRepository : BaseRepository<Topic, ApplicationDbContext>, ITopicRepository
{
    public TopicRepository(ApplicationDbContext context) : base(context)
    {
    }

}
