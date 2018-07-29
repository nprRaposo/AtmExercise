using System;
using System.Collections.Generic;
using System.Text;

namespace AtmExercise.Service
{
    public interface IService<T>
    {
        int Save(T entity);

        T GetById(int id);

        T GetBy(string number);
    }
}
