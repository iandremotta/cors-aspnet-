using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers;

[ApiController]
[Route("v1/todos")]
public class TodoController : ControllerBase
{
    [Route("")]
    [HttpPost]
    public GenericCommandResult Create([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
    {
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
    {
        return repository.GetAll("andremotta");
    }

    [Route("done")]
    [HttpGet]
    public IEnumerable<TodoItem> Done([FromServices] ITodoRepository repository)
    {
        // var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetAllDone("andremotta");
    }

    [Route("done/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForToday([FromServices] ITodoRepository repository)
    {
        // var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetByPeriod("andremotta", DateTime.Now.Date, true);
    }

    [Route("done/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices] ITodoRepository repository)
    {
        // var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetByPeriod("andremotta", DateTime.Now.Date.AddDays(1), true);
    }


    [Route("undone")]
    [HttpGet]
    public IEnumerable<TodoItem> UNdone([FromServices] ITodoRepository repository)
    {
        // var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetAllUndone("andremotta");
    }

    [Route("undone/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForToday([FromServices] ITodoRepository repository)
    {
        // var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetByPeriod("andremotta", DateTime.Now.Date, false);
    }

    [Route("undone/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForTomorrow([FromServices] ITodoRepository repository)
    {
        return repository.GetByPeriod("andremotta", DateTime.Now.Date.AddDays(1), false);
    }
}