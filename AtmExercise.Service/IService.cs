using System;
using System.Collections.Generic;
using System.Text;

namespace AtmExercise.Service
{
    public interface IService<T>
    {
        void Update(T entity);

        T GetById(int id);

        T GetBy(string number);

        bool Exists(string number);

        T GetBy(string[] parameters);
    }
}
