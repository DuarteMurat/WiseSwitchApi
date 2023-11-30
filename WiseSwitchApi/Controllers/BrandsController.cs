using Microsoft.AspNetCore.Mvc;
using WiseSwitchApi.Data;
using WiseSwitchApi.Helpers;
using WiseSwitchApi.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WiseSwitchApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;
        private readonly ApiResponse _apiResponse;
        private readonly IDataUnit _dataUnit;
        public BrandsController(IBrandRepository brandRepository, IDataUnit dataUnit)
        {
            _brandRepository = brandRepository;
            _apiResponse = new ApiResponse();
            _dataUnit = dataUnit;
        }

        // GET: api/<BrandsController>
        [HttpGet(Name = "All")]
        public async Task<IActionResult> GetAllBrands()
        {
            try
            {
                var result = await _brandRepository.GetAllOrderByNameAsync();

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

        // GET: api/<BrandsController>/2
        [HttpGet("{id}", Name = "Display")]
        public async Task<IActionResult> GetDisplayViewModelAsync(int id)
        {
            try
            {
                var result = await _dataUnit.Brands.GetDisplayDtoAsync(id);

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



        // PUT api/<BrandController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // POST api/<BrandsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // DELETE api/<BrandsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
