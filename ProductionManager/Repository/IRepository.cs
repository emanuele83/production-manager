using ProductionManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.Repository
{
    public interface IRepository<T> where T : BasicModel
    {
        T FindById(int id);
        IEnumerable<T> FindAll();
        //IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        int Insert(T model);
        bool Update(T model);
        bool Delete(int id);
    }
}
