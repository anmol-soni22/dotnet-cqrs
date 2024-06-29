using CQRS.Models;
using MediatR;

namespace CQRS.Data
{
    public class GetTaskByIdQuery : IRequest<Tasks>
    {
        public int Id { get; set; }
    }
}
