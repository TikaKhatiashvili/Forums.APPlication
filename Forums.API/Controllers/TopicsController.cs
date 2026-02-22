using Forums.API.Entities;
using Forums.API.Repository;
using Forums.API.Services;
using Microsoft.AspNetCore.Mvc;

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
       
        if(result.Item1.Count>0)
        {
            return Ok(new
            {
                Topics = result.Item1,
                TopicsCount = result.totalCount
            });
        }
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingleTopic(Guid id)
    {
        var result = await _topicService.GetTopicDetailsForGettingAsync(id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();

    }
    //[HttpPost]
    //public async Task<IActionResult> AddTopic([FromBody] Topic topic)
    //{
    //}
    //[HttpPut]
    //public async Task<IActionResult> UpdateTopic([FromBody] Topic topic)
    //{

    //}
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteTopic(Guid id)
    //{

    //}
}
