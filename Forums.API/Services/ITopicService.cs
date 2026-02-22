using Forums.API.Models.DTO.Topics;

namespace Forums.API.Services;

public interface ITopicService
{
    Task<(List<TopicListForGettingDto>, int totalCount)> GetAllTopicsAsync(int? pageNumber, int? pageSize);
    Task<TopicDetailsForGettingDto> GetTopicDetailsForGettingAsync(Guid topicId);
    Task<int>AddNewTopicAsync(TopicForCreatingDto model);
    Task<int> UpdateNewTopicAsync(TopicForUpdatingDto model);
    Task<int>DeleteTopicAsync(Guid topicId);
}
