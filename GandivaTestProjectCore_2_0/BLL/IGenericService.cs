using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandivaTestProject
{
    public interface IGenericService<T> where T: class
    {
        T FindById(int id);
        IEnumerable<T> Get(Func<T, bool> predicate);

        void SaveChanges();

        void Remove(T user);

    }
}
