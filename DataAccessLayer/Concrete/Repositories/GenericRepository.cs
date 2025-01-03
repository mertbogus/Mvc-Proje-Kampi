using DataAccessLayer.Abstract;
using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();

        DbSet<T> _object;

        public GenericRepository()
        {
            _object=c.Set<T>();
        }

        public void Delete(T entity)
        {
            var DeletedEntity=c.Entry(entity);
            DeletedEntity.State=EntityState.Deleted;
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T entity)
        {
            var addedEntity=c.Entry(entity);
            addedEntity.State= EntityState.Added;
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList(); ;
        }

        public void Update(T entity)
        {
            var UptadedEntity=c.Entry(entity);
            UptadedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
