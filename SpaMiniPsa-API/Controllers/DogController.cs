using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaMiniPsa_API.Entities;
using SpaMiniPsa_API.Repositories;
using System.Collections;

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

        [HttpPost]
        public void AddDog(Dog dog)
        {
            _dogRepository.Add(dog);
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
    }
}
