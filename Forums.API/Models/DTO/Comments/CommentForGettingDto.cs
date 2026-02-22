using System.ComponentModel.DataAnnotations;

namespace Forums.API.Models.DTO.Comments;

public record CommentForGettingDto(
    Guid Id,
    string Content,
    DateTime CommentDate
    );
