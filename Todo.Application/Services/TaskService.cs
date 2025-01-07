using AutoMapper;
using Todo.Application.DTOS;
using Todo.Application.Interfaces;
using Todo.Domain.Interfaces;
using TaskDomain = Todo.Domain.Entities.Task;

namespace Todo.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public TaskService(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TaskDTO>> GetAllTasksAsync()
    {
        var tasks = await _taskRepository.GetAllTasksAsync();
        return _mapper.Map<IEnumerable<TaskDTO>>(tasks);
    }

    public async Task<TaskDTO> GetTaskByIdAsync(int id)
    {
        var task = await _taskRepository.GetTaskByIdAsync(id);
        return _mapper.Map<TaskDTO>(task);
    }

    public async Task AddTaskAsync(TaskDTO taskDto)
    {
        var task = _mapper.Map<TaskDomain>(taskDto);
        await _taskRepository.AddTaskAsync(task);
    }

    public async Task UpdateTaskAsync(TaskDTO taskDto)
    {
        var task = _mapper.Map<TaskDomain>(taskDto);
        await _taskRepository.UpdateTaskAsync(task);
    }

    public async Task DeleteTaskAsync(int id)
    {
        var task = await _taskRepository.GetTaskByIdAsync(id);
        await _taskRepository.DeleteTaskAsync(task);
    }
}