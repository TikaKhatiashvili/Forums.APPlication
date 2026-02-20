using System.ComponentModel.DataAnnotations;

namespace Forums.API.Models.DTO.Comments;

public class CommentForGettingDto
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime CommentDate { get; set; } 
}
