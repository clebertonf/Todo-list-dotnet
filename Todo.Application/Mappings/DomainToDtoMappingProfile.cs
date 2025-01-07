using AutoMapper;
using Todo.Application.DTOS;
using Todo.Domain.Entities;
using Task = Todo.Domain.Entities.Task;

namespace Todo.Application.Mappings;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Task, TaskDTO>().ReverseMap();
    }
}