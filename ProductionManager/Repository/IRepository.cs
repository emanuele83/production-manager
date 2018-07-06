using ProductionManager.Model;
using ProductionManager.Specification;
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
        int Count(BasicSpecification<T> specification);
        IEnumerable<T> Find(BasicSpecification<T> specification);
        IEnumerable<T> Find(BasicSpecification<T> specification, int page, int pageSize);
        int Insert(T model);
        bool Update(T model);
        bool Delete(int id);
    }
}
