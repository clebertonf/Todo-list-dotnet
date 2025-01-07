using Todo.Application.DTOS;

namespace Todo.Application.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskDTO>> GetAllTasksAsync();
    Task<TaskDTO> GetTaskByIdAsync(int id);
    Task AddTaskAsync(TaskDTO task);
    Task UpdateTaskAsync(TaskDTO task);
    Task DeleteTaskAsync(int id);
}