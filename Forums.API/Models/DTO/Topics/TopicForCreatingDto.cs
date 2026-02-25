using System.ComponentModel.DataAnnotations;

namespace Forums.API.Models.DTO.Topics;

public record TopicForCreatingDto
(
    [Required]
    [MaxLength(50)]
    string Title,
    [Required]
    string Content,
    string ImageUrl
    //, 
    // DateTime CreatedDate,
    // DateTime LastCommentDate,
    //bool CommentsAreAllowed

    );
