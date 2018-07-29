﻿using AtmExercise.Data;
using AtmExercise.Model;
using AtmExercise.Model.Exception;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AtmExercise.Service
{
    public class OperationService : IOperationService
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

        public void UpSertEntity(Operation entity)
        {
            this._opRepository.UpSertEntity(entity);
        }

        public List<Operation> GetAllBy(string creditCardId)
        {
            return this._opRepository.GetAllBy(creditCardId);
        }

        public void InsertBalance(int creditCardId)
        {
            var balanceOperation = new Operation
            {
                Code = OperationTypeEnum.Balance,
                CreditCardId = creditCardId,
                Detail = "Balance",
                Time = DateTime.Now
            };

            this._opRepository.UpSertEntity(balanceOperation);
        }

        public void InsertWithDrawal(int creditCardId, int amount)
        {
            var creditCard = this._ccRepository.GetById(creditCardId);
            
            if (creditCard.Balance < amount)
            {
                throw new AtmNotCreditException("There is no enough amount in your account for the withdrawal");
            }

            var operation = new Operation
            {
                Code = OperationTypeEnum.WithDrawal,
                Detail = "Amount of WithDrawal " + amount.ToString(),
                CreditCardId = creditCardId,
                Time = DateTime.Now
            };

            creditCard.Balance -= amount;

            this._ccRepository.UpSertEntity(creditCard);
            this._opRepository.UpSertEntity(operation);
        }
    }
}
