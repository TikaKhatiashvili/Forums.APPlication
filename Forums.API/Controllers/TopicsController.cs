using Forums.API.Entities;
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
    //[HttpGet]
    //public async Task<IActionResult> GetAllTopics()
    //{
    //    var results = await _topicRepository.GetAllAsync();
    //    if (results.TotalCount == 0)
    //        return NotFound();
    //    return Ok(results);
    //}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingleTopic(Guid id)
    {
        var topic = await _topicRepository.GetAsync(c => c.Id == id, includProperties: "Comments");
        if (topic == null)
            return NotFound();
        return Ok(topic);
    }
    //[HttpPost]
    //public async Task<IActionResult> AddTopic([FromBody] Topic topic)
    //{
    //    await _topicRepository.AddAsync(topic);
    //    await _topicRepository.SaveAsync();
    //    return Ok();
    //}
    //[HttpPut]
    //public async Task<IActionResult> UpdateTopic([FromBody] Topic topic)
    //{
    //    var topicToUpdate = await _topicRepository.GetAsync(c => c.Id == topic.Id);

    //    if (topicToUpdate == null)
    //        return NotFound();
    //    _topicRepository.Update(topic);
    //    await _topicRepository.SaveAsync();

    //    return Ok();
    //}
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteTopic(Guid id)
    //{
    //    var topic = await _topicRepository.GetAsync(c => c.Id == id);
    //    if (topic == null)
    //        return NotFound();
    //    _topicRepository.Remove(topic);
    //    await _topicRepository.SaveAsync();

    //    return NoContent();
    //}
}
