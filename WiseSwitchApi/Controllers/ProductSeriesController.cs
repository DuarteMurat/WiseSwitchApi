using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WiseSwitchApi.Dtos.ProductSeries;
using WiseSwitchApi.Helpers;

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

        // GET: api/ProductSeries/All
        [HttpGet, ActionName("All")]
        [SwaggerOperation(Summary = "Gets all Product Series, ordered by Name.")]
        public async Task<IActionResult> GetAllProductSeriesOrderByName()
        {
            return await _helper.TryGet(DataOperations.GetAllProductSeriesOrderByName, null);
        }

        // GET: api/ProductSeries/Combo
        [HttpGet, ActionName("Combo")]
        [SwaggerOperation(Summary = "Gets all Product Series as a Combo, ordered by Name.")]
        public async Task<IActionResult> GetComboProductSeries()
        {
            return await _helper.TryGet(DataOperations.GetAllProductSeriesCombo, null);
        }

        // GET: api/ProcuctSeries/ComboProductSeriesOfProductLine/{id}
        [HttpGet("{id}"), ActionName("ComboProductSeriesOfProductLine")]
        [SwaggerOperation(Summary = "Gets Product Series of Product Line whose ID is the given one.")]
        public async Task<IActionResult> GetOfProductLine(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetComboProductSeriesOfProductLine, id);
        }

        // GET: api/ProductSeries/Display/{id}
        [HttpGet("{id}"), ActionName("Display")]
        [SwaggerOperation(Summary = "Gets the display model.")]
        public async Task<IActionResult> GetDisplayModel(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetProductSeriesDisplay, id);
        }

        // GET: api/ProductSeries/EditModel/{id}
        [HttpGet("{id}"), ActionName("EditModel")]
        [SwaggerOperation(Summary = "Gets the edit model.")]
        public async Task<IActionResult> GetEditModel(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetProductSeriesEditModel, id);
        }

        // GET: api/ProductSeries/Exists/{id}
        [HttpGet("{id}"), ActionName("Exists")]
        [SwaggerOperation(Summary = "Gets bool whether object exists in the database.")]
        public async Task<IActionResult> GetExists(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetProductSeriesExists, id);
        }

        // GET: api/ProductSeries/IdsOfDependencyChain/{id}
        [HttpGet("{id}"), ActionName("IdsOfDependencyChain")]
        [SwaggerOperation(Summary = "Gets the IDs of the related Product Line and Brand.")]
        public async Task<IActionResult> GetIdsOfDependencyChain(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetDependencyChainIdsOfProductSeries, id);
        }

        // GET: api/ProductSeries/Model/{id}
        [HttpGet("{id}"), ActionName("Model")]
        [SwaggerOperation(Summary = "Gets object as registered in the database.")]
        public async Task<IActionResult> GetModel(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetProductSeries, id);
        }


        // -- POST --

        // POST: api/ProductSeries/Create
        [HttpPost, ActionName("Create")]
        [SwaggerOperation(Summary = "Creates Product Series.")]
        public async Task<IActionResult> Post([FromBody] CreateProductSeriesDto model)
        {
            return await _helper.TryPost(DataOperations.CreateProductSeries, model);
        }


        // -- PUT --

        // PUT: api/ProductSeries/Update
        [HttpPut, ActionName("Update")]
        [SwaggerOperation(Summary = "Updates Product Series.")]
        public async Task<IActionResult> Put([FromBody] EditProductSeriesDto model)
        {
            return await _helper.TryPut(DataOperations.UpdateProductSeries, model);
        }


        // -- DELETE --

        // DELETE: api/ProductSeries/Delete/{id}
        [HttpDelete("{id}"), ActionName("Delete")]
        [SwaggerOperation(Summary = "Deletes Product Series.")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryDelete(DataOperations.DeleteProductSeries, id);
        }
    }
}
