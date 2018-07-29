using AtmExercise.Data;
using AtmExercise.Model;
using AtmExercise.Model.Exception;
using System;

namespace AtmExercise.Service
{
    public class CreditCardService : IService<CreditCard>
    {
        #region CreditCard Data
        private readonly IRepository<CreditCard> _ccRepository;

        public CreditCardService(IRepository<CreditCard> ccRepository)
        {
            this._ccRepository = ccRepository;
        }

        public CreditCard GetBy(string number)
        {
            var creditCard = this._ccRepository.GetBy(number);

            if (creditCard == null)
            {
                throw new AtmException("Credit Card does not exist in the application");
            }
            if (creditCard.Blocked)
            {
                throw new AtmException("Credit Card is currently Blocked");
            }

            return creditCard;
        }

        public CreditCard GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(CreditCard entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private Helpers
        #endregion
    }
}
