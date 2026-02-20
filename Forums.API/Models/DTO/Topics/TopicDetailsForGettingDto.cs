using Forums.API.Models.DTO.Comments;

namespace Forums.API.Models.DTO.Topics;

public record TopicDetailsForGettingDto
(
    Guid Id,
    string Title,
    string Content,
    DateTime CreatedDate ,
    string ImageUrl,
    DateTime LastCommentDate ,
    bool CommentsAreAllowed ,
    List<CommentForGettingDto> Comments
);
