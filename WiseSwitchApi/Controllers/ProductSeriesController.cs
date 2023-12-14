﻿using Microsoft.AspNetCore.Mvc;
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
            return await _helper.TryGet(DataOperations.GetComboProductSeries, null);
        }

        // GET: api/ProcuctSeries/ComboProductSeriesOfBrand/{productLineId}
        [HttpGet("{productLineId}"), ActionName("ComboProductSeriesOfBrand")]
        [SwaggerOperation(Summary = "Gets Product Series of Product Line whose ID is the given one.")]
        public async Task<IActionResult> GetOfProductLine(int productLineId)
        {
            return await _helper.TryGet(DataOperations.GetComboProductSeriesOfProductLine, productLineId);
        }

        // GET: api/ProductSeries/Display/{id}
        [HttpGet("{id}"), ActionName("Display")]
        [SwaggerOperation(Summary = "Gets the display model.")]
        public async Task<IActionResult> GetDisplayModel(int id)
        {
            return await _helper.TryGet(DataOperations.GetDisplayProductSeries, id);
        }

        // GET: api/ProductSeries/EditModel/{id}
        [HttpGet("{id}"), ActionName("EditModel")]
        [SwaggerOperation(Summary = "Gets the edit model.")]
        public async Task<IActionResult> GetEditModel(int id)
        {
            return await _helper.TryGet(DataOperations.GetEditModelProductSeries, id);
        }

        // GET: api/ProductSeries/Exists/{id}
        [HttpGet("{id}"), ActionName("Exists")]
        [SwaggerOperation(Summary = "Gets bool whether object exists in the database.")]
        public async Task<IActionResult> GetExists(int id)
        {
            return await _helper.TryGet(DataOperations.GetExistsProductSeries, id);
        }

        // GET: api/ProductSeries/IdsOfDependencyChain/{id}
        [HttpGet("{id}"), ActionName("IdsOfDependencyChain")]
        [SwaggerOperation(Summary = "Gets the IDs of the related Product Line and Brand.")]
        public async Task<IActionResult> GetIdsOfDependencyChain(int id)
        {
            return await _helper.TryGet(DataOperations.GetDependencyChainIdsOfProductSeries, id);
        }

        // GET: api/ProductSeries/Model/{id}
        [HttpGet("{id}"), ActionName("Model")]
        [SwaggerOperation(Summary = "Gets object as registered in the database.")]
        public async Task<IActionResult> GetModel(int id)
        {
            return await _helper.TryGet(DataOperations.GetModelProductSeries, id);
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
            return await _helper.TryDelete(DataOperations.DeleteProductSeries, id);
        }
    }
}
