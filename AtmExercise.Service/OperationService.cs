using AtmExercise.Data;
using AtmExercise.Model;
using AtmExercise.Model.Exception;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AtmExercise.Service
{
    public class OperationService : IService<Operation>
    {
        private readonly IRepository<CreditCard> _ccRepository;
        private readonly IRepository<Operation> _opRepository;

        public OperationService(IRepository<CreditCard> ccRepository, IRepository<Operation> opRepository)
        {
            this._ccRepository = ccRepository;
            this._opRepository = opRepository;
        }

        public Operation GetBy(string criteria)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string criteria)
        {
            throw new NotImplementedException();
        }

        public Operation GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Operation GetBy (string [] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(Operation entity)
        {
            throw new NotImplementedException();
        }

        public List<Operation> GetAllBy(string creditCardId)
        {
            return this._opRepository.GetAllBy(creditCardId);
        }
    }
}
