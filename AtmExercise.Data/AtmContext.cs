using Microsoft.EntityFrameworkCore;
using AtmExercise.Model;
using System;

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

            var operationOne = new Operation
            {
                Id = 1,
                Code = OperationTypeEnum.Balance,
                CreditCard = creditCardOne,
                CreditCardId = 1,
                Detail = "Balance",
                Time = DateTime.Now
            };

            var operationTwo = new Operation
            {
                Id = 2,
                Code = OperationTypeEnum.Balance,
                CreditCard = creditCardOne,
                CreditCardId = 1,
                Detail = "Balance",
                Time = DateTime.Now
            };

            var operationThree = new Operation
            {
                Id = 3,
                Code = OperationTypeEnum.WithDrawal,
                CreditCard = creditCardOne,
                CreditCardId = 1,
                Detail = "Withdrawal of 100",
                Time = DateTime.Now
            };

            this.CreditCards.Add(creditCardOne);
            this.CreditCards.Add(creditCardTwo);
            this.Operations.Add(operationOne);
            this.Operations.Add(operationTwo);
            this.Operations.Add(operationThree);

            this.SaveChanges();
        }

    }
}
