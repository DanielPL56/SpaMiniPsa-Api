using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaMiniPsa_API.Entities;

namespace SpaMiniPsa_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Breed> GetBreeds()
        {
            List<Breed> breedList = new List<Breed>();

            string[] breeds = { "-", "York", "Owczarek", "Shih-Tzu", "Sznaucer" };

            for (int i = 0; i < breeds.Length; i++)
            {
                breedList.Add(new Breed() { Id = i + 1, Name = breeds[i] });
            };

            return breedList;
        }
    }
}
