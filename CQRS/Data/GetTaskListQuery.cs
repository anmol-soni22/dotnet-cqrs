using CQRS.Models;
using MediatR;

namespace CQRS.Data
{
    public class GetTaskListQuery : IRequest<List<Tasks>>
    {
    }
}
