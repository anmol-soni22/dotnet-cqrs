using CQRS.Models;
using CQRS.Services;
using MediatR;

namespace CQRS.Data.Handlers
{
    public class GetTaskListHandler : IRequestHandler<GetTaskListQuery, List<Tasks>>
    {
        private readonly ITasksRepository _tasksRepository;

        public GetTaskListHandler(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task<List<Tasks>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            return await _tasksRepository.GetTasksListAsync();
        }
    }
}
