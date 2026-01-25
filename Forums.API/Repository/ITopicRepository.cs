using Forums.API.Entities;

namespace Forums.API.Repository;

public interface ITopicRepository
{
    Task<List<Topic>> GetAllTopicsAsync();
}
