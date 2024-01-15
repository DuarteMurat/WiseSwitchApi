using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WiseSwitchApi.Dtos.Brand;
using WiseSwitchApi.Helpers;

namespace WiseSwitchApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ControllerHelper _helper;

        public BrandsController(ControllerHelper helper)
        {
            _helper = helper;
        }


        // -- GET --

        // GET: api/Brands/All
        [HttpGet, ActionName("All")]
        [SwaggerOperation(Summary = "Gets all Brands, ordered by Name.")]
        public async Task<IActionResult> GetAll()
        {
            return await _helper.TryGet(DataOperations.GetAllBrandsOrderByName, null);
        }

        // GET: api/Brands/Combo
        [HttpGet, ActionName("Combo")]
        [SwaggerOperation(Summary = "Gets all Brands as a Combo, ordered by Name.")]
        public async Task<IActionResult> GetCombo()
        {
            return await _helper.TryGet(DataOperations.GetAllBrandsCombo, null);
        }

        // GET: api/Brands/Display/{id}
        [HttpGet("{id}"), ActionName("Display")]
        [SwaggerOperation(Summary = "Gets the display model.")]
        public async Task<IActionResult> GetDisplayModel(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetBrandDisplay, id);
        }

        // GET: api/Brands/EditModel/{id}
        [HttpGet("{id}"), ActionName("EditModel")]
        [SwaggerOperation(Summary = "Gets the edit model.")]
        public async Task<IActionResult> GetEditModel(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetBrandEditModel, id);
        }

        // GET: api/Brands/Exists/{id}
        [HttpGet("{id}"), ActionName("Exists")]
        [SwaggerOperation(Summary = "Gets bool whether object exists in the database.")]
        public async Task<IActionResult> GetExists(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetBrandExists, id);
        }

        // GET: api/Brands/Model/{id}
        [HttpGet("{id}"), ActionName("Model")]
        [SwaggerOperation(Summary = "Gets object as registered in the database.")]
        public async Task<IActionResult> GetModel(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetBrand, id);
        }


        // -- POST --

        // POST: api/Brands/Create
        [HttpPost, ActionName("Create")]
        [SwaggerOperation(Summary = "Creates Brand.")]
        public async Task<IActionResult> Post([FromBody] CreateBrandDto model)
        {
            return await _helper.TryPost(DataOperations.CreateBrand, model);
        }


        // -- PUT --

        // PUT: api/Brands/Update
        [HttpPut, ActionName("Update")]
        [SwaggerOperation(Summary = "Updates Brand.")]
        public async Task<IActionResult> Put([FromBody] EditBrandDto model)
        {
            return await _helper.TryPut(DataOperations.UpdateBrand, model);
        }


        // -- DELETE --

        // DELETE: api/Brands/Delete/{id}
        [HttpDelete("{id}"), ActionName("Delete")]
        [SwaggerOperation(Summary = "Deletes Brand.")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryDelete(DataOperations.DeleteBrand, id);
        }
    }
}
