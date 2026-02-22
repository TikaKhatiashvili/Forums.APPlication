using Forums.API.Entities;
using Forums.API.Models.DTO.Comments;
using Forums.API.Models.DTO.Topics;
using Mapster;
namespace Forums.API.Services.Mapping;

public static class MappingConfig
{
    public static void RegisterMappings(TypeAdapterConfig config)
    {
        config.NewConfig<TopicForCreatingDto, Topic>()
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.ImageUrl, src => src.ImageUrl);

        config.NewConfig<Topic, TopicListForGettingDto>()
           .Map(dest => dest.Id, src => src.Id)
           .Map(dest => dest.Title, src => src.Title)
           .Map(dest => dest.CreatedDate, src => src.CreatedDate);

        config.NewConfig<Topic, TopicDetailsForGettingDto>()
          .Map(dest => dest.Id, src => src.Id)
          .Map(dest => dest.Title, src => src.Title)
          .Map(dest => dest.Content, src => src.Content)
          .Map(dest => dest.CreatedDate, src => src.CreatedDate)
          .Map(dest => dest.ImageUrl, src => src.ImageUrl)
          .Map(dest => dest.LastCommentDate, src => src.LastCommentDate)
          .Map(dest => dest.CommentsAreAllowed, src => src.CommentsAreAllowed)
          .Map(dest => dest.Comments, src => src.Comments);

        config.NewConfig<Comment, CommentForCreatingDto>()
         .Map(dest => dest.Content, src => src.Content)
         .Map(dest => dest.TopicId, src => src.TopicId);

        config.NewConfig<Comment, CommentForGettingDto>()
         .Map(dest => dest.Id, src => src.Id)
         .Map(dest => dest.Content, src => src.Content)
         .Map(dest => dest.CommentDate, src => src.CommentDate);

        config.NewConfig<Comment, CommentForUpdatingDto>()
         .Map(dest => dest.Id, src => src.Id)
         .Map(dest => dest.Content, src => src.Content);
    }
}

