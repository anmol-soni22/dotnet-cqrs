using CQRS.Data.Command;
using CQRS.Services;
using MediatR;

namespace CQRS.Data.Handlers
{
    public class UpdateTaskHandler: IRequestHandler<UpdateTaskCommand, int>
    {
        private readonly ITasksRepository _tasksRepository;

        public UpdateTaskHandler(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }
        public async Task<int> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _tasksRepository.GetTaskByIdAsync(request.Id);
            if (task == null)
            {
                return default;
            }
            task.Name = request.Name;
            task.Description = request.Description;

            return await _tasksRepository.UpdateTaskAsync(task);
        }
    }
}
