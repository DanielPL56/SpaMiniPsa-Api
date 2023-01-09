using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpaMiniPsa_API.Entities;
using SpaMiniPsa_API.Models;
using SpaMiniPsa_API.Repositories;

namespace SpaMiniPsa_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private IDogRepository _dogRepository;

        public DogController(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetDog(int id)
        {
            try
            {
                return Ok(_dogRepository.Get(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public IEnumerable<Dog> GetAllDogs()
        {
            return _dogRepository.GetAll();
        }

        [HttpPost("AddDogWithImage")]
        public void AddDogWithImage([FromForm] FileUpload fileObj)
        {
            Dog dog = JsonConvert.DeserializeObject<Dog>(fileObj.Dog);
            List<Image> dogImages = new List<Image>();
            
            var files = fileObj.Files;

            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        var bytes = memoryStream.ToArray();

                        Image img = new Image();
                        img.File = bytes;
                        dogImages.Add(img);
                    }
                }
                dog.Images = dogImages;
            }

            _dogRepository.Add(dog);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDog(int id)
        {
            _dogRepository.Delete(id);

            return Ok();
        }

        [HttpDelete("DeleteDogWithImage/{id}")]
        public IActionResult DeleteDogWithImage(int id) 
        {
            try
            {
                _dogRepository.DeleteDogWithImage(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public void UpdateDog(int id, Dog modifiedDog)
        {
            _dogRepository.Update(id, modifiedDog);
        }
    }
}
