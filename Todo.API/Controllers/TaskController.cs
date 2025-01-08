using Microsoft.AspNetCore.Mvc;
using Todo.Application.Interfaces;
using TaskDTO = Todo.Application.DTOS.TaskDTO;
namespace Todo.API.Controllers;

[ApiController]
[Route("api/")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("tasks")]
    public async Task<IActionResult> GetTasksAsync()
    {
        return Ok(await _taskService.GetAllTasksAsync());
    }

    [HttpGet("tasks/{id}")]
    public async Task<IActionResult> GetTaskByIdAsync(int id)
    {
        return Ok(await _taskService.GetTaskByIdAsync(id));
    }

    [HttpPost("task")]
    public async Task<IActionResult> CreateTaskAsync([FromBody] TaskDTO request)
    {
        await _taskService.AddTaskAsync(request);
        return Ok();
    }

    [HttpPut("task")]
    public async Task<IActionResult> UpdateTaskAsync([FromBody] TaskDTO request, int id)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }
        await _taskService.UpdateTaskAsync(request);
        return NoContent();
    }

    [HttpDelete("task/{id}")]
    public async Task<IActionResult> DeleteTaskAsync(int id)
    {
        await _taskService.DeleteTaskAsync(id);
        return NoContent();
    }
}