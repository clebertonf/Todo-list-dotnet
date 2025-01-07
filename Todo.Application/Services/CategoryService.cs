using AutoMapper;
using Todo.Application.DTOS;
using Todo.Application.Interfaces;
using Todo.Domain.Entities;
using Todo.Domain.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Todo.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRespository _categoryRespository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRespository categoryRespository, IMapper mapper)
    {
        _categoryRespository = categoryRespository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
    {
        var categories = await _categoryRespository.GetCategoriesAsync();
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int? id)
    {
        var category = await _categoryRespository.GetCategoryByIdAsync(id);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task CreateCategoryAsync(CategoryDto categoryDto)
    {
       var category = _mapper.Map<Category>(categoryDto);
       await _categoryRespository.AddCategoryAsync(category);
    }

    public async Task UpdateCategoryAsync(CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _categoryRespository.UpdateCategoryAsync(category);
    }

    public async Task DeleteCategoryAsync(int? id)
    {
        var category = await _categoryRespository.GetCategoryByIdAsync(id);
        await _categoryRespository.DeleteCategoryAsync(category);
    }
}