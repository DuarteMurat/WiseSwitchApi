using Microsoft.AspNetCore.Mvc;
using WiseSwitchApi.Dtos;
using WiseSwitchApi.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WiseSwitchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductLinesController : ControllerBase
    {
        private readonly IProductLineRepository _productLineRepository;

        public ProductLinesController(IProductLineRepository productLineRepository)
        {
            _productLineRepository = productLineRepository;
        }
        // GET: api/<ProductLinesController>
        [HttpGet(Name = "GetProductLines")]
        public async Task<IEnumerable<IndexRowProductLineDto>> Get()
        {
            return await _productLineRepository.GetAllOrderByName();
        }

        // POST api/<ProductLinesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductLinesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductLinesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
