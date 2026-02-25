using System.ComponentModel.DataAnnotations;

namespace Forums.API.Models.DTO.Comments;

public record CommentForUpdatingDto
    (
    [Required]Guid Id,
    [Required] string Content
    );
