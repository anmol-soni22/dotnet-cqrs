using CQRS.Data.Command;
using CQRS.Models;
using CQRS.Services;
using MediatR;

namespace CQRS.Data.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, Tasks>
    {
        private readonly ITasksRepository _tasksRepository;

        public CreateTaskHandler(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }
        public async Task<Tasks> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            Tasks task = new Tasks
            {
                Name = request.Name,
                Description = request.Description,
            };
            return await _tasksRepository.AddTaskAsync(task);
        }
    }
}
