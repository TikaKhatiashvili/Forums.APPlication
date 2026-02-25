using System.ComponentModel.DataAnnotations;

namespace Forums.API.Models.DTO.Comments;

public record CommentForCreatingDto
    (
    [Required]
    string Content,
    [Required]
    Guid TopicId
    //DateTime CommentDate
    );
