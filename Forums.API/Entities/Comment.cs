using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Forums.API.Entities;

public class Comment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public DateTime CommentDate { get; set; } = DateTime.Now;

    [ForeignKey(nameof(Topic))]
    public Guid TopicId { get; set; }
    public Topic Topic { get; set; }

    [Required]
    [ForeignKey(nameof(Author))]
    public string AuthorId { get; set; }
    public ApplicationUser Author { get; set; }
}
