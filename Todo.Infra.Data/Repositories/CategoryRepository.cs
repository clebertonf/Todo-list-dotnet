using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Interfaces;
using Todo.Infra.Data.Context;

namespace Todo.Infra.Data.Repositories;

public class CategoryRepository : ICategoryRespository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public CategoryRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<Category?>> GetCategoriesAsync()
    {
        return await _applicationDbContext.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int? id)
    {
        return await _applicationDbContext.Categories.FindAsync(id);
    }

    public async Task<Category> AddCategoryAsync(Category category)
    {
        await _applicationDbContext.Categories.AddAsync(category);
        await _applicationDbContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        // _applicationDbContext.Entry(category).State = EntityState.Modified;
        _applicationDbContext.Categories.Update(category);
        await _applicationDbContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> DeleteCategoryAsync(Category category)
    {
        _applicationDbContext.Categories.Remove(category);
        await _applicationDbContext.SaveChangesAsync();
        return category;
    }
}