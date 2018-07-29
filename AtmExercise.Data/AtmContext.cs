using Microsoft.EntityFrameworkCore;
using AtmExercise.Model;

namespace AtmExercise.Data
{
    public class AtmContext : DbContext
    {
        public AtmContext(DbContextOptions<AtmContext> options)
           : base(options)
        {
            this.CreateFirstDataAsync();
        }

        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Operation> Operations { get; set; }

        private void CreateFirstDataAsync()
        {
            var creditCardOne = new CreditCard
            {
                Id = 1,
                Attempts = 0,
                Balance = 1500,
                Blocked = false,
                Number = "1111111111111111",
                Pin = "1234"
            };

            var creditCardTwo = new CreditCard
            {
                Id = 2,
                Attempts = 0,
                Balance = 1500,
                Blocked = false,
                Number = "2222222222222222",
                Pin = "1234"
            };

            this.CreditCards.Add(creditCardOne);
            this.CreditCards.Add(creditCardTwo);

            this.SaveChanges();
        }

    }
}
