using CQRS.Models;
using CQRS.Services;
using MediatR;

namespace CQRS.Data.Handlers
{
    public class GetTaskHandler : IRequestHandler<GetTaskByIdQuery, Tasks>
    {
        private readonly ITasksRepository _tasksRepository;

        public GetTaskHandler(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }
        public async Task<Tasks> Handle(GetTaskByIdQuery request,CancellationToken cancellationToken)
        {
            return await _tasksRepository.GetTaskByIdAsync(request.Id);
        }
    }
}
