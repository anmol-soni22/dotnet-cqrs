using CQRS.Models;
using MediatR;

namespace CQRS.Data.Command
{
    public class CreateTaskCommand : IRequest<Tasks>
    {
        public CreateTaskCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
