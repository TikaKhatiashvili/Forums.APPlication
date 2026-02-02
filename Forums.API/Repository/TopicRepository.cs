using Forums.API.Data;
using Forums.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forums.API.Repository;

public class TopicRepository : ITopicRepository
{
    private readonly ApplicationDbContext _context;
    public TopicRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task AddNewTopicAsync(Topic entity)
    {
        throw new NotImplementedException();
    }

    public Task<Topic> DeleteSingleTopicAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Topic>> GetAllTopicsAsync()
    {
        return await _context.Topics.ToListAsync();    }

    public Task<Topic> GetSingleTopicAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateNewTopicAsync(Topic entity)
    {
        throw new NotImplementedException();
    }
}
