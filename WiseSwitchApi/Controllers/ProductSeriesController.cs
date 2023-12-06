using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        private readonly ControllerHelper _helper;

        public ProductSeriesController(ControllerHelper helper)
        {
            _helper = helper;
        }

        // -- GET --

        [HttpGet, ActionName("All")]
        [SwaggerOperation(Summary = "Gets all Product Series, ordered by Name.")]
        public async Task<IActionResult> GetAllProductSeriesOrderByName()
        {
            return await _helper.TryGet(DataOperations.GetAllProductSeriesOrderByName, null);
        }


        [HttpGet, ActionName("Combo")]
        [SwaggerOperation(Summary = "Gets all Product Series as a Combo, ordered by Name.")]
        public async Task<IActionResult> GetComboProductSeries()
        {
            return await _helper.TryGet(DataOperations.GetComboProductSeries, null);
        }


        [HttpGet("{id}"), ActionName("Display")]
        [SwaggerOperation(Summary = "Gets the display model.")]
        public async Task<IActionResult> GetDisplayDto(int id)
        {
            return await _helper.TryGet(DataOperations.GetDisplayProductSeries, id);
        }


        [HttpGet("{id}"), ActionName("Exists")]
        [SwaggerOperation(Summary = "Gets bool whether object exists in the database.")]
        public async Task<IActionResult> GetExists(int id)
        {
            return await _helper.TryGet(DataOperations.GetExistsProductSeries, id);
        }


        [HttpGet("{id}"), ActionName("Model")]
        [SwaggerOperation(Summary = "Gets model as registered in the database.")]
        public async Task<IActionResult> GetModel(int id)
        {
            return await _helper.TryGet(DataOperations.GetModelProductSeries, id);
        }

        // -- POST --
        [HttpPost, ActionName("Create")]
        [SwaggerOperation(Summary = "Creates ProductSeries.")]
        public async Task<IActionResult> Post([FromBody] ProductSeries model)
        {
            return await _helper.TryPost(DataOperations.CreateProductSeries, model);
        }

        // -- PUT --

        [HttpPut, ActionName("Edit")]
        [SwaggerOperation(Summary = "Updates ProductSeries.")]
        public async Task<IActionResult> Put([FromBody] ProductSeries model)
        {
            return await _helper.TryPut(DataOperations.UpdateProductSeries, model);
        }

        // -- DELETE --

        [HttpDelete("{id}"), ActionName("Delete")]
        [SwaggerOperation(Summary = "Deletes ProductSeries.")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _helper.TryDelete(DataOperations.DeleteProductSeries, id);
        }
    }
}
