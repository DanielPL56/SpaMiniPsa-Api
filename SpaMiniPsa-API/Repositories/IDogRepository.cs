using SpaMiniPsa_API.Entities;

namespace SpaMiniPsa_API.Repositories
{
    public interface IDogRepository : IRepository<Dog>
    {
        public void Update(int id, Dog dog);
    }
}
