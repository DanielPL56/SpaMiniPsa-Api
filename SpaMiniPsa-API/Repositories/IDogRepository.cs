using SpaMiniPsa_API.Entities;
using SpaMiniPsa_API.Models;

namespace SpaMiniPsa_API.Repositories
{
    public interface IDogRepository : IRepository<Dog>
    {
        public void Update(int id, Dog dog);
        public void DeleteDogWithImage(int id);
    }
}
