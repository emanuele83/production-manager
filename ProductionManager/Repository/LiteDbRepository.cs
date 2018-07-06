using LiteDB;
using ProductionManager.Model;
using ProductionManager.Specification;
using System.Collections.Generic;

namespace ProductionManager.Repository
{
    public class LiteDbRepository<T> : IRepository<T> where T : BasicModel
    {
        public virtual T FindById(int id)
        {
            return Database.LiteDbInstance.SingleById<T>(id);
        }

        private static LiteQueryable<T> CreateQuery(BasicSpecification<T> specification)
        {
            LiteQueryable<T> query = Database.LiteDbInstance.Query<T>();
            // add where conditions
            query.Where(specification.ToExpression());
            // add includes, if any
            foreach (var include in specification.Includes)
            {
                query.Include(include);
            }

            return query;
        }

        public int Count(BasicSpecification<T> specification)
        {
            LiteQueryable<T> query = CreateQuery(specification);

            return query.Count();
        }

        public IEnumerable<T> Find(BasicSpecification<T> specification)
        {
            return Find(specification, 0, 0);
        }

        public IEnumerable<T> Find(BasicSpecification<T> specification, int page, int pageSize)
        {
            LiteQueryable<T> query = CreateQuery(specification);
            if (pageSize > 0)
            {
                query.Skip(page * pageSize);
                query.Limit(pageSize);
            }

            return query.ToEnumerable();
        }
        
        public int Insert(T model)
        {
            return Database.LiteDbInstance.Insert<T>(model);
        }

        public bool Update(T model)
        {
            return Database.LiteDbInstance.Update<T>(model);
        }

        public bool Delete(int id)
        {
            return Database.LiteDbInstance.Delete<T>(id);
        }
    }
}
