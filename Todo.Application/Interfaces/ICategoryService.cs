using Todo.Application.DTOS;
using Task = System.Threading.Tasks.Task;

namespace Todo.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
    Task<CategoryDto> GetCategoryByIdAsync(int? id);
    Task  CreateCategoryAsync(CategoryDto categoryDto);
    Task  UpdateCategoryAsync(CategoryDto categoryDto);
    Task DeleteCategoryAsync(int? id);
}