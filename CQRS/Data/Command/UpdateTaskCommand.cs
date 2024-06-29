using CQRS.Models;
using MediatR;

namespace CQRS.Data.Command
{
    public class UpdateTaskCommand : IRequest<int>
    {
        public UpdateTaskCommand(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
