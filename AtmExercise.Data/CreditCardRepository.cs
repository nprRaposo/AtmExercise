using AtmExercise.Model;
using System;
using System.Collections.Generic;
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

        public List<CreditCard> GetAllBy(string criteria)
        {
            throw new NotImplementedException();
        }

        public CreditCard GetBy(string number)
        {
            return this._context.CreditCards.FirstOrDefault(cc => cc.Number == number);
        }

        public CreditCard GetById(int id)
        {
            return this._context.CreditCards.FirstOrDefault(cc => cc.Id == id);
        }

        public void Update(CreditCard entity)
        {
            var creditCard = this.GetById(entity.Id);
            creditCard.Attempts = entity.Attempts;
            creditCard.Balance = entity.Balance;
            creditCard.Blocked = entity.Blocked;

            this._context.SaveChanges();
        }
    }
}
