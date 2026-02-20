namespace Forums.API.Models.DTO.Topics;

public record TopicListForGettingDto
        
    (
    Guid Id,
    string Title,
    DateTime CreatedDate
    );
