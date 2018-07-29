using AtmExercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AtmExercise.Data
{
    public class OperationRepository: IRepository<Operation>
    {
        private readonly AtmContext _context;

        public OperationRepository(AtmContext context)
        {
            this._context = context;
        }

        public Operation GetBy(string creditCardId)
        {
            throw new NotImplementedException();
        }

        public Operation GetById(int id)
        {
            return this._context.Operations.FirstOrDefault(cc => cc.Id == id);
        }

        public List<Operation> GetAllBy(string criteria)
        {
            return this._context.Operations.Where(o => o.CreditCardId == int.Parse(criteria)).ToList();
        }

        public void Update(Operation operation)
        {
            throw new NotImplementedException();
        }
    }
}
