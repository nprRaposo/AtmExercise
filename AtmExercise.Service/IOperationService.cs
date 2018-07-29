using AtmExercise.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtmExercise.Service
{
    public interface IOperationService : IService<Operation>
    {
        void InsertBalance(int creditCardId);

        void InsertWithDrawal(int creditCardId, int amount);


    }
}
