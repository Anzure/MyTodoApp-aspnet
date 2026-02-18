using AutoMapper;

namespace MyTodoApp.API.Profiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<Entities.TodoTask, Models.TaskDto>();
    }
}