using Microsoft.AspNetCore.Mvc;
using WiseSwitchApi.Dtos;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WiseSwitchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwitchModelsController : ControllerBase
    {
        private readonly ISwitchModelRepository _switchModelRepository;

        public SwitchModelsController(ISwitchModelRepository switchModelRepository)
        {
            _switchModelRepository = switchModelRepository; 
        }
        // GET: api/<SwitchModelsController>
        [HttpGet]
        public async Task<IEnumerable<IndexRowSwitchModelDto>> Get()
        {
            return await _switchModelRepository.GetAllOrderByModelNameAsync();
        }

        // POST api/<SwitchModelsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SwitchModelsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SwitchModelsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
