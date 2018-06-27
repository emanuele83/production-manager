using LiteDB;
using ProductionManager.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.Repository
{
    public class LiteDbRepository<T> : IRepository<T> where T : BasicModel
    {
        private readonly LiteRepository _db;

        public LiteDbRepository()
        {
            this._db = Database.DbInstance;
        }

        public virtual T FindById(int id)
        {
            return _db.SingleById<T>(id);
        }

        public virtual IEnumerable<T> FindAll()
        {
            return _db.Query<T>().ToEnumerable();
        }

        //public virtual IEnumerable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        //{
        //    return _dbContext.Set<T>()
        //           .Where(predicate)
        //           .AsEnumerable();
        //}

        public int Insert(T model)
        {
            return _db.Insert<T>(model);
        }

        public bool Update(T model)
        {
            return _db.Update<T>(model);
        }

        public bool Delete(int id)
        {
            return _db.Delete<T>(id);
        }
    }
}
