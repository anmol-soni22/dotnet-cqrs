using CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)  {
            
        }

        public DbSet<Tasks> Tasks { get; set; }

    }
}
