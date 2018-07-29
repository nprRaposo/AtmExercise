using System;
using System.Collections.Generic;
using System.Text;

namespace AtmExercise.Data
{
    public interface IRepository <T>
    {
        void Update(T entity);

        T GetById(int id);

        T GetBy(string number);
    }
}
