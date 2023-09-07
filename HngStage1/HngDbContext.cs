using HngStage1.Model;
using Microsoft.EntityFrameworkCore;

namespace HngStage1
{
    public class HngDbContext : DbContext
    {
        public HngDbContext(DbContextOptions<HngDbContext> options)
: base(options)
        { }
        public DbSet<Request> Requests { get; set; }
    }
}
