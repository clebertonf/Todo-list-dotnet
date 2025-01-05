namespace Todo.Domain.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<Task>> GetAllTasksAsync();
    Task<Task> GetTaskByIdAsync(int? id);
    Task<Task> AddTaskAsync(Task task);
    Task<Task> UpdateTaskAsync(Task task);
    Task<Task> DeleteTaskAsync(Task task);
}