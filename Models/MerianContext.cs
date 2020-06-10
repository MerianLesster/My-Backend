using Microsoft.EntityFrameworkCore;
namespace CommandAPI.Models
{
    public class MerianContext : DbContext
    {
        public MerianContext(DbContextOptions<MerianContext> options) : base(options)
        {

        }

        public DbSet<Merian> ProductItems { get; set; }
    }
}