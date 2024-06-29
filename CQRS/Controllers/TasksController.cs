using CQRS.Data;
using CQRS.Data.Command;
using CQRS.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public async Task<List<Tasks>> TaskList()
        {
            var taskList = await _mediator.Send(new GetTaskListQuery());
            return taskList;
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public async Task<Tasks> TaskById(int id)
        {
            var task = await _mediator.Send(new GetTaskByIdQuery() { Id = id});
            return task;
        }

        // POST api/<TasksController>
        [HttpPost]
        public async Task<Tasks> AddTask(Tasks task)
        {
            var taskReturn = await _mediator.Send(new CreateTaskCommand(
                task.Name, task.Description
            ));

            return taskReturn;
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public async Task<int> UpdateTask(Tasks task)
        {
            var taskReturn = await _mediator.Send(new UpdateTaskCommand(
                task.Id, task.Name, task.Description
            ));

            return taskReturn;
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public async Task<int> DeleteTask(int id)
        {
            return await _mediator.Send(new DeleteTaskCommand() { Id = id });
        }
    }
}
