using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Todo.Domain.Entities;

namespace Todo.Application.DTOS;

public class TaskDTO
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Title is required!")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Title")]
    public string? Title { get;  set; }
    
    [Required(ErrorMessage = "Description is required!")]
    [MinLength(3)]
    [MaxLength(1000)]
    [DisplayName("Description")]
    public string? Description { get;  set; }
    
    [Required(ErrorMessage = "DueDate is required!")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime DueDate { get;  set; }
    
    [Required(ErrorMessage = "IsCompleted is required!")]
    public bool IsCompleted { get;  set; }
    
    public int CategoryId { get; set; }
    
    [DisplayName("Category")]
    [JsonIgnore]
    public Category? Category { get; set; }
}