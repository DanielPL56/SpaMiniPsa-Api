using SpaMiniPsa_API.Entities;

namespace SpaMiniPsa_API.Repositories;

public class DogRepository : EntityFrameworkBase<Dog>, IDogRepository
{
    //private DataContext _context;
    public DogRepository(DataContext dataContext) : base(dataContext) {}

    public void Update(int id, Dog modifiedDog)
    {
        var dog = Get(id);

        if (dog != null && modifiedDog != null)
        {
            dog.Name = modifiedDog.Name;
            dog.Breed = modifiedDog.Breed;
            dog.DateOfBirth = modifiedDog.DateOfBirth;
        }

        Table.Update(dog);
        Context.SaveChanges();
    }
}
