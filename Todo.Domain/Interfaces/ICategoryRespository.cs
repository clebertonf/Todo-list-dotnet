using Todo.Domain.Entities;

namespace Todo.Domain.Interfaces;

public interface ICategoryRespository
{
    Task<IEnumerable<Category?>> GetCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(int? id);
    Task<Category> AddCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category category);
    Task<Category> DeleteCategoryAsync(Category category);
}