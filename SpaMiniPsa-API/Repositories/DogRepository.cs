using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using SpaMiniPsa_API.Entities;
using SpaMiniPsa_API.Models;

namespace SpaMiniPsa_API.Repositories;

public class DogRepository : EntityFrameworkBase<Dog>, IDogRepository
{
    public DogRepository(DataContext dataContext) : base(dataContext) {}

    public void DeleteDogWithImage(int id)
    {
        Dog dog = Table.Find(id);

        if (dog != null)
        {
            if (dog.Images != null)
            {
                foreach (var img in dog.Images)
                {
                    Context.Images.Remove(img);
                }
            }

            Table.Remove(dog);
            
            Context.SaveChanges();
        }
    }

    public override void Delete(int id)
    {
        Dog dog = Table.Find(id);

        if (dog != null)
        {
            if (dog.Images != null)
            {
                foreach (var img in dog.Images)
                {
                    Context.Images.Remove(img);
                }
            }

            Table.Remove(dog);

            Context.SaveChanges();
        }
    }

    public void Update(int id, Dog modifiedDog)
    {
        //var dog = Get(id);
        //var dog = Table.Find(id);
        var dog = Table.Single(dog => dog.Id== id);

        if (dog != null && modifiedDog != null)
        {
            dog.Id = modifiedDog.Id;
            dog.Name = modifiedDog.Name;
            dog.Breed = modifiedDog.Breed;
            dog.DateOfBirth = modifiedDog.DateOfBirth;
            dog.IsDewormedFirstTime = modifiedDog.IsDewormedFirstTime;
            dog.DateOfFirstDeworming = modifiedDog.DateOfFirstDeworming;
            dog.ProfileImage = modifiedDog.ProfileImage;
            dog.Images= modifiedDog.Images;
        }
        

        Table.Update(dog);
        Context.SaveChanges();
    }
}
