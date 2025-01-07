using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Todo.Application.DTOS;

public class CategoryDto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required!")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Name")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Description is required!")]
    [MinLength(3)]
    [MaxLength(1000)]
    [DisplayName("Description")]
    public string? Description { get; set; }
}