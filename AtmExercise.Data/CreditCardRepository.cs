using AtmExercise.Model;
using System;
using System.Linq;

namespace AtmExercise.Data
{
    public class CreditCardRepository: IRepository<CreditCard>
    {
        private readonly AtmContext _context;

        public CreditCardRepository(AtmContext context)
        {
            this._context = context;
        }

        public CreditCard GetBy(string number)
        {
            return this._context.CreditCards.FirstOrDefault(cc => cc.Number == number);
        }

        public CreditCard GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CreditCard entity)
        {
            throw new NotImplementedException();
        }
    }
}
