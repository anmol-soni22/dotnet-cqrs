using MediatR;

namespace CQRS.Data.Command
{
    public class DeleteTaskCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
