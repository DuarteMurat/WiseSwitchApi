using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WiseSwitchApi.Data;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Helpers;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ApiResponse _apiResponse;
        private readonly IBrandRepository _brandRepository;
        private readonly IDataUnit _dataUnit;

        public BrandsController(IBrandRepository brandRepository, IDataUnit dataUnit)
        {
            _brandRepository = brandRepository;
            _apiResponse = new ApiResponse();
            _dataUnit = dataUnit;
        }


        // -- GET --

        // GET: api/Brands/All
        [HttpGet, ActionName("All")]
        [SwaggerOperation(Summary = "Gets all Brands, ordered by Name.")]
        public async Task<IActionResult> GetAll()
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

        // GET: api/Brands/Combo
        [HttpPost, ActionName("Combo")]
        [SwaggerOperation(Summary = "Gets all Brands as a Combo, ordered by Name.")]
        public async Task<IActionResult> GetCombo()
        {
            // TODO: do it.
            return NotFound();
        }

        // GET: api/Brands/Display/{id}
        [HttpGet("{id}"), ActionName("Display")]
        [SwaggerOperation(Summary = "Gets the display model.")]
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

        // GET: api/Brands/Exists/{id}
        [HttpPost, ActionName("Exists")]
        [SwaggerOperation(Summary = "Gets bool whether object exists in the database.")]
        public async Task<IActionResult> GetExists(int id)
        {
            // TODO: do it.
            return NotFound();
        }

        // GET: api/Brands/Model/{id}
        [HttpPost, ActionName("Model")]
        [SwaggerOperation(Summary = "Gets object as registered in the database.")]
        public async Task<IActionResult> GetModel(int id)
        {
            // TODO: do it.
            return NotFound();
        }


        // -- POST --

        // POST: api/Brands/Create
        [HttpPost, ActionName("Create")]
        [SwaggerOperation(Summary = "Creates Brand.")]
        public async Task<IActionResult> Post([FromBody] Brand model)
        {
            // TODO: do it.
            return NotFound();
        }


        // -- PUT --

        // PUT: api/Brands/Update
        [HttpPut, ActionName("Update")]
        [SwaggerOperation(Summary = "Updates Brand.")]
        public async Task<IActionResult> Put([FromBody] Brand model)
        {
            // TODO: do it.
            return NotFound();
        }

        
        // -- DELETE --

        // DELETE: api/Brands/Delete/{id}
        [HttpDelete("{id}"), ActionName("Delete")]
        [SwaggerOperation(Summary = "Deletes Brand.")]
        public async Task<IActionResult> Delete(int id)
        {
            // TODO: do it.
            return NotFound();
        }
    }
}
