using Forums.API.Entities;

namespace Forums.API.Repository;

public interface ITopicRepository
{
    Task<(List<Topic>Topics,int TotalCount)> GetAllTopicsAsync(int pagen=1,int pages=10);
    Task<Topic> GetSingleTopicAsync(Guid id);
    Task AddNewTopicAsync(Topic entity);
    Task UpdateNewTopicAsync(Topic entity);
    Task<Topic> DeleteSingleTopicAsync(Guid id);
}
