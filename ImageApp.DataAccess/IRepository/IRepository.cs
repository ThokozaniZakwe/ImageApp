using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageApp.DataAccess.IRepository
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        void Delete(int id);

        void Delete(T entity);

        void Add(T entity);
    }
}
