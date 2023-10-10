using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butter.Repositories.Interfaces
{
    public interface IRepo<T,U>
        where T : class
    {
        IEnumerable<T> Get();
        T GetById (U id);

        void Add (T item);
        void Update (T item);
        void Delete (U item);
    }
}
