using SpaMiniPsa_API.Entities;

namespace SpaMiniPsa_API.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public TEntity Get(int id);
        public IEnumerable<TEntity> GetAll();
        public void Add(TEntity obj);
        public void Delete(int id);
    }
}
