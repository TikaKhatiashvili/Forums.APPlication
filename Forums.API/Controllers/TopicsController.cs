using Forums.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Forums.API.Controllers;
[Route("api/topics")]
[ApiController]
public class TopicsController : Controller
{
    private readonly ITopicRepository _topicRepository;
    public TopicsController(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllTopics()
    { var results = await _topicRepository.GetAllTopicsAsync();
        if(results.Count>0)
        { return Ok(results); 
        }
        return NotFound();
    }
}
