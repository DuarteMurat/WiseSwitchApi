using Microsoft.AspNetCore.Mvc;
using WiseSwitchApi.Data;
using WiseSwitchApi.Helpers;
using WiseSwitchApi.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WiseSwitchApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductLinesController : ControllerBase
    {
        private readonly IProductLineRepository _productLineRepository;
        private readonly ApiResponse _apiResponse;
        private readonly IDataUnit _dataUnit;

        public ProductLinesController(IProductLineRepository productLineRepository,
            IDataUnit dataUnit)
        {
            _productLineRepository = productLineRepository;
            _apiResponse = new ApiResponse();
            _dataUnit = dataUnit;
        }

        // GET: api/<ProductLinesController>
        [HttpGet, ActionName("DisplayAllProductLine")]
        public async Task<IActionResult> GetAllProductLines()
        {
            try
            {
                var result = await _productLineRepository.GetAllOrderByName();

                if (result == null || !result.Any())
                {
                    _apiResponse.Message = "The Data returned null";
                    _apiResponse.IsError = true;
                }
                _apiResponse.Result = result;
            }
            catch (Exception ex)
            {
                _apiResponse.Message = ex.Message;
                _apiResponse.IsError = false;
            }

            return Ok(_apiResponse);
        }

        // GET: api/<ProductsController>/2
        [HttpGet, ActionName("DisplayProductLineById")]
        public async Task<IActionResult> GetDisplayViewModelAsync(int id)
        {
            try
            {
                var result = await _dataUnit.ProductLines.GetDisplayDtoAsync(id);

                if (result == null)
                {
                    _apiResponse.Message = "The Data returned null";
                    _apiResponse.IsError = true;
                }
                _apiResponse.Result = result;
            }
            catch (Exception ex)
            {
                _apiResponse.Message = ex.Message;
                _apiResponse.IsError = false;
            }

            return Ok(_apiResponse);
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
