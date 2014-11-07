using RoomM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Model.RepositoryFramework
{
    public abstract class  RepositoryBase<C, T> : 
        IRepository<T> where T : EntityBase where C : DbContext, new() 
    {
        // internal EFDataContext context;
        // internal DbSet<T> dbSet;


        private C _entities = new C();
        public C Context {
            get { return _entities; }
            set { _entities = value; }
        }

        


        /* public RepositoryBase(EFDataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetWithRawSql(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters).ToList();
        }

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual T GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
            // context.SaveChanges();
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);

            context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            // dbSet.Attach(entityToUpdate);
            // context.Entry(entityToUpdate).State = EntityState.Modified;

            if (entity == null)
            {
                throw new ArgumentException("Cannot add a null entity.");
            }

            var entry = context.Entry<T>(entity);

            if (entry.State == EntityState.Detached)
            {
                var set = context.Set<T>();
                T attachedEntity = set.Local.SingleOrDefault(e => e.ID == entity.ID);  // You need to have access to key

                if (attachedEntity != null)
                {
                    var attachedEntry = context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }
        }

        public IList<T> GetAll()
        {
            var list = this.Get();
            return list.ToList();
        }
        */


        public virtual IEnumerable<T> GetWithRawSql(string query, params object[] parameters)
        {
            return _entities.Set<T>().SqlQuery(query, parameters).ToList();
        }

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _entities.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public IList<T> GetAll()
        {
            return Get().ToList();
        }

        public virtual IQueryable<T> GetAllWithQuery()
        {
            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public void Delete(object id)
        {
            T entityToDelete = _entities.Set<T>().Find(id);
            Delete(entityToDelete);
        }

        public void Edit(T entity)
        {
            // _entities.Entry(entity).State = EntityState.Modified;
            if (entity == null)
            {
                throw new ArgumentException("Cannot add a null entity.");
            }

            var entry = _entities.Entry<T>(entity);

            if (entry.State == EntityState.Detached)
            {

                

                var set = _entities.Set<T>();
                T attachedEntity = set.Local.SingleOrDefault(e => e.ID == entity.ID);  // You need to have access to key

                if (attachedEntity != null)
                {
                    // Console.WriteLine("heheeeeeeeeeeeeee");
                    var attachedEntry = _entities.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }

        public void Save()
        {
            _entities.SaveChanges();
        }
    }
}
