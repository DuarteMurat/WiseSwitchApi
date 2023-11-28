using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WiseSwitchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        // GET: api/<ManufacturersController>
        [HttpGet (Name = "GetManufacturers")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
