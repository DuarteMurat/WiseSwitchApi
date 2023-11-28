using Microsoft.AspNetCore.Mvc;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WiseSwitchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturersController(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }
        // GET: api/<ManufacturersController>
        [HttpGet(Name = "GetManufacturers")]
        public async Task<IEnumerable<Manufacturer>> Get()
        {
            return await _manufacturerRepository.GetAllOrderByName();
        }

        // POST api/<ManufacturersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ManufacturersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ManufacturersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
