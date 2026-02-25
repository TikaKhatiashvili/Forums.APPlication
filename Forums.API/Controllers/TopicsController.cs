using Forums.API.Entities;
using Forums.API.Models;
using Forums.API.Models.DTO.Topics;
using Forums.API.Repository;
using Forums.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace Forums.API.Controllers;
[Route("api/topics")]
[ApiController]
public class TopicsController : Controller
{
    private readonly ITopicService _topicService;
    public TopicsController(ITopicService topicService)
    {
       _topicService = topicService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTopics([FromQuery] int? pageNumber=1, [FromQuery] int?pageSize=10)
    {
       var result = await _topicService.GetAllTopicsAsync(pageNumber,pageSize);

        var response = new CommonResponse
        {
            Message = "Topics retrieved successfuly",
            StatusCode = HttpStatusCode.OK,
            IsSuccess=true,
            Result = new
            {
                Topics = result.Item1,
                TotalCount = result.Item2
            }
        };
        return StatusCode(Convert.ToInt32(response.StatusCode), response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingleTopic(Guid id)
    {
        var result = await _topicService.GetTopicDetailsForGettingAsync(id);

        var response = new CommonResponse
        {
            Message = "Topics retrieved successfuly",
            StatusCode = HttpStatusCode.OK,
            IsSuccess = true,
            Result = result
        };
        return StatusCode(Convert.ToInt32(response.StatusCode), response);
        }
    [HttpPost]
    public async Task<IActionResult> AddNewTopic([FromBody] TopicForCreatingDto topic)
    {
        var result=await _topicService.AddNewTopicAsync(topic);
        var response = new CommonResponse
        {
            Message = "Topics added successfuly",
            StatusCode = HttpStatusCode.Created,
            IsSuccess = true,
            Result = result
        };
        return StatusCode(Convert.ToInt32(response.StatusCode), response);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateTopic([FromBody] TopicForUpdatingDto topic)
    {
        var result= await _topicService.UpdateNewTopicAsync(topic);
        var response = new CommonResponse
        {
            Message = $"Topic with id: {topic.Id} update successfully",
            StatusCode = HttpStatusCode.OK,
            IsSuccess = true,
            Result = result
        };
        return StatusCode(Convert.ToInt32(response.StatusCode), response);
        
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTopic(Guid id)
    {
        var result=await _topicService.DeleteTopicAsync(id);
        var response = new CommonResponse
        {
            Message = $"Topic with id: {id} deleted successfully",
            StatusCode = HttpStatusCode.OK,
            IsSuccess = true,
            Result = result
        };
        return StatusCode(Convert.ToInt32(response.StatusCode), response);

       }
}
