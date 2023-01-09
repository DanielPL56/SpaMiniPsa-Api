using Microsoft.EntityFrameworkCore;

namespace SpaMiniPsa_API.Repositories
{
    public abstract class EntityFrameworkBase<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        protected DbSet<TEntity> Table;

        protected DataContext Context;

        const string errorMessage = "There is no such record in Database";

        protected EntityFrameworkBase(DataContext dbContext)
        {
            Context = dbContext;
            Table = Context.Set<TEntity>();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public virtual void Add(TEntity obj)
        {
            Table.Add(obj);
            Context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Table.ToList();
        }

        public TEntity Get(int id)
        {
            var obj = Table.Find(id);

            if (obj != null)
            {
                return obj;
            }
            else
            {
                throw new Exception(errorMessage);
            }
        }

        public virtual void Delete(int id)
        {
            var objToDelete = Get(id);

            if (objToDelete != null)
            {
                Table.Remove(Get(id));
                Context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException(errorMessage);
            }
        }
    }
}
