using System.Collections.Generic;

namespace Dio.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> GetAll();
        T GetByID(int id);

        void Insert(T entidade);

        void Delete(int id);

        void Update(T entidade);

        int NextId();


    }
}