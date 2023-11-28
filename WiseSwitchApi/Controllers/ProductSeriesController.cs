using Microsoft.AspNetCore.Mvc;
using WiseSwitchApi.Dtos;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WiseSwitchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSeriesController : ControllerBase
    {
        private readonly IProductSeriesRepository _productSeriesRepository;

        public ProductSeriesController(IProductSeriesRepository productSeriesRepository)
        {
            _productSeriesRepository = productSeriesRepository;
        }
        // GET: api/<ProductSeriesController>
        [HttpGet(Name = "GetProductSeries")]
        public async Task<IEnumerable<IndexRowProductSeriesDto>> Get()
        {
            return await _productSeriesRepository.GetAllOrderByName();
        }

        // POST api/<ProductSeriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductSeriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductSeriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
