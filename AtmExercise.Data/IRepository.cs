using System;
using System.Collections.Generic;
using System.Text;

namespace AtmExercise.Data
{
    public interface IRepository <T>
    {
        void UpSertEntity(T entity);

        T GetById(int id);

        T GetBy(string number);

        List<T> GetAllBy(string criteria);
    }
}
