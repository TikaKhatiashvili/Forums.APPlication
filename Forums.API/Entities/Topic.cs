using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forums.API.Entities;

public class Topic
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Title { get; set; }

    [Required]  
    public string Content { get; set; }

    [Required] //მხოლოდ თარიღი
    [Column(TypeName ="Date")]
    public DateTime CreatedDate { get; set; }= DateTime.Now; // ჩაწერის მომენტში დრო

    public string ImageUrl { get; set; }

    [Required]
    [Column(TypeName = "Date")]
    public DateTime LastCommentDate { get; set; }

    public bool CommentsAreAllowed { get; set; } = true;
    public List<Comment> Comments { get; set;} 
}
