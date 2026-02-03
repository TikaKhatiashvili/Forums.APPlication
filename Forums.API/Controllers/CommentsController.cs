using Forums.API.Entities;
using Forums.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace Forums.API.Controllers;

[Route("api/comments")]
[ApiController]
public class CommentsController : Controller
{
    private readonly ICommentRepository _commentRepository;
    public CommentsController(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllComments()
    {
        var results = await _commentRepository.GetAllAsync();
        if (results.TotalCount == 0)
            return NotFound();
        return Ok(results.Items);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingleComment(Guid id)
    {
        var comment = await _commentRepository.GetAsync(c => c.Id == id, includProperties:"Topic");
        if (comment == null)
            return NotFound();
        return Ok(comment);
    }
    [HttpPost]
    public async Task<IActionResult> AddComment([FromBody] Comment comment)
    {
        await _commentRepository.AddAsync(comment);
        await _commentRepository.SaveAsync();
        return Ok();
    }
    [HttpPut]
    public async Task<IActionResult> UpdateComment([FromBody] Comment comment)
    {
        var commentToUpdate = await _commentRepository.GetAsync(c => c.Id == comment.Id);

        if(commentToUpdate== null)
            return NotFound();
        _commentRepository.Update(comment);
        await _commentRepository.SaveAsync();

        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(Guid id)
    {
        var comment = await _commentRepository.GetAsync(c => c.Id == id);
        if (comment == null)
            return NotFound();
        _commentRepository.Remove(comment);
        await _commentRepository.SaveAsync();

        return NoContent();
    }
}
