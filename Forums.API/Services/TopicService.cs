using Forums.API.Models.DTO.Topics;
using Forums.API.Repository;

namespace Forums.API.Services;

public class TopicService : ITopicService
{
    private readonly ITopicRepository _topicRepository;
    public TopicService(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }
    public async Task<int> AddNewTopicAsync(TopicForCreatingDto model)
    {
        return 0;
        //await _topicRepository.AddAsync(model);
        //return await _topicRepository.SaveAsync();
    }

    public async Task<int> DeleteTopicAsync(Guid topicId)
    {
        var topicToDelete = await _topicRepository.GetAsync(t => t.Id == topicId);
        if (topicToDelete != null)
        {
            _topicRepository.Remove(topicToDelete);
            return await _topicRepository.SaveAsync();
        }
        return 0;
    }

    public async Task<List<TopicListForGettingDto>> GetAllTopicsAsync(int? pageNumber = 1, int? pageSize = 10)
    {
        return null;

        //var result = await _topicRepository.GetAllAsync(pageNumber: pageNumber, pageSize: pageSize);
        //if (result.Items.Count > 0)
        //{
        //    return result;
        //}
        //return Enumerable.Empty<TopicListForGettingDto>().ToList();
    }

    public async Task<TopicDetailsForGettingDto> GetTopicDetailsForGettingAsync(Guid topicId)
    {
        return null;

        //var result = await _topicRepository.GetAsync(t => t.Id == topicId, includProperties:"Comments");
        //return result;
       }

    public async Task<int> UpdateNewTopicAsync(TopicForUpdatingDto model)
    {
        var topicToUpdate = await _topicRepository.GetAsync(t => t.Id == model.Id);
        if (topicToUpdate != null)
        {
            _topicRepository.Update(topicToUpdate);
            return await _topicRepository.SaveAsync();
        }
        return 0;
    }
}
