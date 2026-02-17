using AutoMapper;

namespace MyTodoApp.API.Profiles;

public class TodoProfile : Profile
{
    public TodoProfile()
    {
        CreateMap<Entities.Todo, Models.TodoWithoutTasksDto>();
    }
}