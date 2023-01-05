using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SpaMiniPsa_API.Entities;
using SpaMiniPsa_API.Models;
using SpaMiniPsa_API.Repositories;
using System.Collections;

namespace SpaMiniPsa_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private IDogRepository _dogRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public DogController(IDogRepository dogRepository, IWebHostEnvironment hostEnvironment)
        {
            _dogRepository = dogRepository;
            _hostEnvironment = hostEnvironment;
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

        [HttpPost]
        public void AddDog(Dog dog)
        {
            _dogRepository.Add(dog);
        }

        [HttpPost("AddDogWithImage")]
        public void SaveFile([FromForm] FileUpload fileObj)
        {
            var oDog = JsonConvert.DeserializeObject<Dog>(fileObj.Dog);

            if (fileObj.File.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    fileObj.File.CopyTo(memoryStream);
                    var fileBytes = memoryStream.ToArray();
                    oDog.Image = fileBytes;

                    _dogRepository.Add(oDog);
                }
            }
        }

        [HttpGet("GetDogWithImage/{id}")]
        public Dog GetSavedDog(int id)
        {
            var dog = _dogRepository.Get(id);
            //dog.Photo = GetImage(Convert.ToBase64String(dog.Photo));
            return dog;
            //return dog;
        }

        [NonAction]
        public byte[] GetImage(string sBase64String)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(sBase64String))
            {
                bytes = Convert.FromBase64String(sBase64String);
            }
            return bytes;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDog(int id)
        {
            try
            {
                _dogRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public void UpdateDog(int id, Dog modifiedDog)
        {
            _dogRepository.Update(id, modifiedDog);
        }

        //[HttpPost("AddDogWithImage")]
        //public async Task<ActionResult> AddDogWithImage([FromForm] Dog dog)
        //{
        //    if (dog.ImageFile != null) dog.ImageName = await SaveImage(dog.ImageFile);
        //    _dogRepository.Add(dog);

        //    return StatusCode(201);
        //}

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return imageName;
        }
    }
}
