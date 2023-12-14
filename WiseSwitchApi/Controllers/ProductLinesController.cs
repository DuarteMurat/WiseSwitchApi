using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WiseSwitchApi.Dtos.ProductLine;
using WiseSwitchApi.Helpers;

namespace WiseSwitchApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductLinesController : ControllerBase
    {
        private readonly ControllerHelper _helper;

        public ProductLinesController(ControllerHelper helper)
        {
            _helper = helper;
        }


        // -- GET --

        // GET: api/ProductLines/All
        [HttpGet, ActionName("All")]
        [SwaggerOperation(Summary = "Gets all Product Lines, ordered by Name.")]
        public async Task<IActionResult> GetAllProductLinesOrderByName()
        {
            return await _helper.TryGet(DataOperations.GetAllProductLinesOrderByName, null);
        }

        // GET: api/ProcuctLines/GetBrandIdOfProductLine/{id}
        [HttpGet("{id}"), ActionName("GetBrandIdOfProductLine")]
        [SwaggerOperation(Summary = "Gets the Brand ID of this Product Line.")]
        public async Task<IActionResult> GetBrandId(int id)
        {
            return await _helper.TryGet(DataOperations.GetBrandIdOfProductLine, id);
        }

        // GET: api/ProcuctLines/Combo
        [HttpGet, ActionName("Combo")]
        [SwaggerOperation(Summary = "Gets all Product Lines as a Combo, ordered by Name.")]
        public async Task<IActionResult> GetComboProductLines()
        {
            return await _helper.TryGet(DataOperations.GetComboProductLines, null);
        }

        // GET: api/ProcuctLines/ComboProductLinesOfBrand/{id}
        [HttpGet("{id}"), ActionName("ComboProductLinesOfBrand")]
        [SwaggerOperation(Summary = "Gets Product Lines of Brand whose ID is the given one.")]
        public async Task<IActionResult> GetOfBrand(int id)
        {
            return await _helper.TryGet(DataOperations.GetComboProductLinesOfBrand, id);
        }

        // GET: api/ProcuctLines/Display{id}
        [HttpGet("{id}"), ActionName("Display")]
        [SwaggerOperation(Summary = "Gets the display model.")]
        public async Task<IActionResult> GetDisplayModel(int id)
        {
            return await _helper.TryGet(DataOperations.GetDisplayProductLine, id);
        }

        // GET: api/ProductLines/EditModel/{id}
        [HttpGet("{id}"), ActionName("EditModel")]
        [SwaggerOperation(Summary = "Gets the edit model.")]
        public async Task<IActionResult> GetEditModel(int id)
        {
            return await _helper.TryGet(DataOperations.GetEditModelProductLine, id);
        }

        // GET: api/ProcuctLines/Exists/{id}
        [HttpGet("{id}"), ActionName("Exists")]
        [SwaggerOperation(Summary = "Gets bool whether object exists in the database.")]
        public async Task<IActionResult> GetExists(int id)
        {
            return await _helper.TryGet(DataOperations.GetExistsProductLine, id);
        }

        // GET: api/ProcuctLines/Model/{id}
        [HttpGet("{id}"), ActionName("Model")]
        [SwaggerOperation(Summary = "Gets object as registered in the database.")]
        public async Task<IActionResult> GetModel(int id)
        {
            return await _helper.TryGet(DataOperations.GetModelProductLine, id);
        }


        // -- POST --

        // POST: api/ProcuctLines/Create
        [HttpPost, ActionName("Create")]
        [SwaggerOperation(Summary = "Creates ProductLines.")]
        public async Task<IActionResult> Post([FromBody] CreateProductLineDto model)
        {
            return await _helper.TryPost(DataOperations.CreateProductLine, model);
        }


        // -- PUT --

        // PUT: api/ProcuctLines/Update
        [HttpPut, ActionName("Update")]
        [SwaggerOperation(Summary = "Updates ProductLine.")]
        public async Task<IActionResult> Put([FromBody] EditProductLineDto model)
        {
            return await _helper.TryPut(DataOperations.UpdateProductLine, model);
        }


        // -- DELETE --

        // DELETE: api/ProcuctLines/Delete/{id}
        [HttpDelete("{id}"), ActionName("Delete")]
        [SwaggerOperation(Summary = "Deletes ProductLine.")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _helper.TryDelete(DataOperations.DeleteProductLine, id);
        }
    }
}
