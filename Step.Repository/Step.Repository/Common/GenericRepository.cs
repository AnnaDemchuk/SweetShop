using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using Step.Repository.Models;

namespace Step.Repository.Common
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Entity<int> , new()
    {
        DbContext context;
        IDbSet<T> dbSet;
        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public void AddOrUpdate(T obj)
        {
            try
            {
                dbSet.AddOrUpdate(obj);
                context.SaveChanges();

            }
            catch (Exception exc)
            {
                string s = exc.Message;
            }
        }

        public void Delete(T obj)
        {

            T t = Get(obj.Id);
            dbSet.Remove(t);
            context.SaveChanges();
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }
    }
}
