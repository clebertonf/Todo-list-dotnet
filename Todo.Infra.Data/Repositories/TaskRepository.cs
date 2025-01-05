using Microsoft.EntityFrameworkCore;
using Todo.Domain.Interfaces;
using Todo.Infra.Data.Context;
using Task = Todo.Domain.Entities.Task;

namespace Todo.Infra.Data.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public TaskRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<Task?>> GetAllTasksAsync()
    {
        return await _applicationDbContext.Tasks.ToListAsync();
    }

    public async Task<Task?> GetTaskByIdAsync(int? id)
    {
        return await _applicationDbContext.Tasks.FindAsync(id);
    }

    public async Task<Task> AddTaskAsync(Task task)
    {
        _applicationDbContext.Tasks.Add(task);
        await _applicationDbContext.SaveChangesAsync();
        return task;
    }

    public async Task<Task> UpdateTaskAsync(Task task)
    {
        // _applicationDbContext.Entry(task).State = EntityState.Modified;
        _applicationDbContext.Tasks.Update(task);
        await _applicationDbContext.SaveChangesAsync();
        return task;
    }

    public async Task<Task> DeleteTaskAsync(Task task)
    {
        _applicationDbContext.Tasks.Remove(task);
        await _applicationDbContext.SaveChangesAsync();
        return task;
    }
}