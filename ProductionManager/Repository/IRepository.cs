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
        int Count(ISpecification<T> specification);
        IEnumerable<T> Find(ISpecification<T> specification);
        IEnumerable<T> Find(ISpecification<T> specification, int page, int pageSize);
        int Insert(T model);
        bool Update(T model);
        bool Delete(int id);
    }
}
