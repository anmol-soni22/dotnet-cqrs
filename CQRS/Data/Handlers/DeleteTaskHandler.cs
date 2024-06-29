using CQRS.Data.Command;
using CQRS.Services;
using MediatR;

namespace CQRS.Data.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, int>
    {
        private readonly ITasksRepository _tasksRepository;

        public DeleteTaskHandler(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }
        public async Task<int> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _tasksRepository.GetTaskByIdAsync(request.Id);
            if (task == null)
            {
                return default;
            }
            return await _tasksRepository.DeleteTaskAsync(request.Id);
        }
    }
}
