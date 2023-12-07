using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Helpers;

namespace WiseSwitchApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SwitchModelsController : ControllerBase
    {
        private readonly ControllerHelper _helper;

        public SwitchModelsController(ControllerHelper helper)
        {
            _helper = helper;
        }


        // -- GET --

        // GET: api/SwitchModels/All
        [HttpGet, ActionName("All")]
        [SwaggerOperation(Summary = "Gets all Switch Models, ordered by Name.")]
        public async Task<IActionResult> GetAllSwitchModelsOrderByName()
        {
            return await _helper.TryGet(DataOperations.GetAllSwitchModelsOrderByModelName, null);
        }

        // GET: api/SwitchModels/Combo
        [HttpGet, ActionName("Combo")]
        [SwaggerOperation(Summary = "Gets all Switch Models as a Combo, ordered by Name.")]
        public async Task<IActionResult> GetComboSwitchModels()
        {
            return await _helper.TryGet(DataOperations.GetComboSwitchModels, null);
        }

        // GET: api/SwitchModels/Display/{id}
        [HttpGet("{id}"), ActionName("Display")]
        [SwaggerOperation(Summary = "Gets the display model.")]
        public async Task<IActionResult> GetDisplayDto(int id)
        {
            return await _helper.TryGet(DataOperations.GetDisplaySwitchModel, id);
        }

        // GET: api/SwitchModels/Exists/{id}
        [HttpGet("{id}"), ActionName("Exists")]
        [SwaggerOperation(Summary = "Gets bool whether object exists in the database.")]
        public async Task<IActionResult> GetExists(int id)
        {
            return await _helper.TryGet(DataOperations.GetExistsSwitchModel, id);
        }

        // GET: api/SwitchModels/Model/{id}
        [HttpGet("{id}"), ActionName("Model")]
        [SwaggerOperation(Summary = "Gets bool whether object exists in the database.")]
        public async Task<IActionResult> GetModel(int id)
        {
            return await _helper.TryGet(DataOperations.GetModelSwitchModel, id);
        }


        // -- POST --

        // POST: api/SwitchModels/Create
        [HttpPost, ActionName("Create")]
        [SwaggerOperation(Summary = "Creates Switch Model.")]
        public async Task<IActionResult> Post([FromBody] SwitchModel model)
        {
            return await _helper.TryPost(DataOperations.CreateSwitchModel, model);
        }


        // -- PUT --

        // PUT: api/SwitchModels/Update
        [HttpPut, ActionName("Update")]
        [SwaggerOperation(Summary = "Updates Switch Model.")]
        public async Task<IActionResult> Put([FromBody] SwitchModel model)
        {
            return await _helper.TryPut(DataOperations.UpdateSwitchModel, model);
        }


        // -- DELETE --

        // DELETE: api/SwitchModels/Delete/{id}
        [HttpDelete("{id}"), ActionName("Delete")]
        [SwaggerOperation(Summary = "Deletes Switch Model.")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _helper.TryDelete(DataOperations.DeleteSwitchModel, id);
        }
    }
}
