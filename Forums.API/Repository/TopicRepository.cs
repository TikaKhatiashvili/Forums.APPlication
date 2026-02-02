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

    public async Task AddNewTopicAsync(Topic entity)
    {
        await _context.Topics.AddAsync(entity);
        await _context.SaveChangesAsync();

    }

    public async Task<Topic> DeleteSingleTopicAsync(Guid id)
    {
        var topic = await _context.Topics.FirstOrDefaultAsync(c => c.Id == id);
        if (topic != null)
        {
            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
        }
        return topic;
    }

    public async Task<(List<Topic> Topics, int TotalCount)> GetAllTopicsAsync(int pagen = 1, int pages = 10)
    {
        return (
            await _context.Topics.Skip((pagen - 1) * pages).Take(pages).ToListAsync(),
            await _context.Topics.CountAsync()
            );
    }

    public async Task<Topic> GetSingleTopicAsync(Guid id)
    {
        return await _context.Topics.FirstOrDefaultAsync(c => c.Id == id);
    }


    public async Task UpdateNewTopicAsync(Topic entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
