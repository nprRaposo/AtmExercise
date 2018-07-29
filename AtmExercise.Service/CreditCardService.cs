using AtmExercise.Data;
using AtmExercise.Model;
using AtmExercise.Model.Exception;
using System.Collections.Generic;
using System.Linq;

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

        public bool Exists(string number)
        {
            return this.GetBy(number) != null;
        }

        public CreditCard GetById(int id)
        {
            return this._ccRepository.GetById(id);
        }

        /// <summary>
        /// Use to try to get the credit card by number and pin
        /// </summary>
        /// <param name="parameters">
        ///     First Parameter: Credit Card Number
        ///     Second Parameter: Pin
        /// </param>
        /// <returns></returns>
        public CreditCard GetBy (string [] parameters)
        {
            var creditCardNumber = parameters[0];
            var pin = parameters[1];

            var creditCard = this.GetBy(creditCardNumber);

            if (creditCard.Pin == pin)
            {
                creditCard.Attempts = 0;
                this.UpSertEntity(creditCard);
                return creditCard;
            }
                
            creditCard.Attempts = creditCard.Attempts + 1;

            if (creditCard.Attempts == 4)
            {
                creditCard.Blocked = true;
                this.UpSertEntity(creditCard);
                throw new AtmCardBlockedException("The credit card has been blocked because of the 4 attempts made to enter");
            }

            this.UpSertEntity(creditCard);
            throw new AtmException("The pin entered is Wrong");
        }

        public void UpSertEntity(CreditCard entity)
        {
            this._ccRepository.UpSertEntity(entity);
        }

        public List<CreditCard> GetAllBy(string criteria)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Private Helpers
        #endregion
    }
}
