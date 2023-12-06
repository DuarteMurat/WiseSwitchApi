using Microsoft.AspNetCore.Mvc;
using WiseSwitchApi.Data;
using WiseSwitchApi.Dtos;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Helpers;
using WiseSwitchApi.Repository;
using WiseSwitchApi.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WiseSwitchApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductSeriesController : ControllerBase
    {
        private readonly IProductSeriesRepository _productSeriesRepository;
        private readonly ApiResponse _apiResponse;
        private readonly IDataUnit _dataUnit;

        public ProductSeriesController(IProductSeriesRepository productSeriesRepository,
            IDataUnit dataUnit)
        {
            _productSeriesRepository = productSeriesRepository;
            _apiResponse = new ApiResponse();
            _dataUnit = dataUnit;
        }

        // GET: api/<ProductSeriesController>
        [HttpGet, ActionName("DisplayAllProductSeries")]
        public async Task<IActionResult> GetAllProductSeries()
        {
            try
            {
                var result = await _productSeriesRepository.GetAllOrderByName();

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

        // GET: api/<ProductsController>
        [HttpGet, ActionName("DisplayProductSeriesById")]
        public async Task<IActionResult> GetDisplayViewModelAsync(int id)
        {
            try
            {
                var result = await _dataUnit.ProductSeries.GetDisplayDtoAsync(id);

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
