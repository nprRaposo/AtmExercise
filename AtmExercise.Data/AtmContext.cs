using Microsoft.EntityFrameworkCore;
using AtmExercise.Model;

namespace AtmExercise.Data
{
    public class AtmContext : DbContext
    {
        public AtmContext(DbContextOptions<AtmContext> options)
           : base(options)
        {
        }

        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Operation> Operations { get; set; }

    }
}
