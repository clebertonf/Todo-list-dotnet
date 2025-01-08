using Microsoft.AspNetCore.Mvc;
using Todo.Application.DTOS;
using Todo.Application.Interfaces;

namespace Todo.API.Controllers;

[ApiController]
[Route("api/")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetCategories()
    {
        return Ok(await _categoryService.GetCategoriesAsync());
    }
    
    [HttpGet("categories/{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        return Ok(await _categoryService.GetCategoryByIdAsync(id));
    }

    [HttpPost("category")]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryDto request)
    {
        await _categoryService.CreateCategoryAsync(request);
        return CreatedAtAction(nameof(GetCategoryById), new { id = request.Id }, request);
    }

    [HttpPut("category")]
    public async Task<IActionResult> UpdateCategory([FromBody] CategoryDto request, int id)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        await _categoryService.UpdateCategoryAsync(request);
        return NoContent();
    }

    [HttpDelete("category/{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return NoContent();
    }
}