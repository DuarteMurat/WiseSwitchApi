using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WiseSwitchApi.Dtos.SwitchModel;
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
            return await _helper.TryGet(DataOperations.GetAllSwitchModelsCombo, null);
        }

        // GET: api/SwitchModels/Display/{id}
        [HttpGet("{id}"), ActionName("Display")]
        [SwaggerOperation(Summary = "Gets the display model.")]
        public async Task<IActionResult> GetDisplayModel(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetSwitchModelDisplay, id);
        }

        // GET: api/SwitchModels/EditModel/{id}
        [HttpGet("{id}"), ActionName("EditModel")]
        [SwaggerOperation(Summary = "Gets the edit model.")]
        public async Task<IActionResult> GetEditModel(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetSwitchModelEditModel, id);
        }

        // GET: api/SwitchModels/Exists/{id}
        [HttpGet("{id}"), ActionName("Exists")]
        [SwaggerOperation(Summary = "Gets bool whether object exists in the database.")]
        public async Task<IActionResult> GetExists(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetSwitchModelExists, id);
        }

        // GET: api/SwitchModels/Model/{id}
        [HttpGet("{id}"), ActionName("Model")]
        [SwaggerOperation(Summary = "Gets the object as registered in the database.")]
        public async Task<IActionResult> GetModel(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetSwitchModel, id);
        }


        // -- POST --

        // POST: api/SwitchModels/Create
        [HttpPost, ActionName("Create")]
        [SwaggerOperation(Summary = "Creates Switch Model.")]
        public async Task<IActionResult> Post([FromBody] CreateSwitchModelDto model)
        {
            return await _helper.TryPost(DataOperations.CreateSwitchModel, model);
        }


        // -- PUT --

        // PUT: api/SwitchModels/Update
        [HttpPut, ActionName("Update")]
        [SwaggerOperation(Summary = "Updates Switch Model.")]
        public async Task<IActionResult> Put([FromBody] EditSwitchModelDto model)
        {
            return await _helper.TryPut(DataOperations.UpdateSwitchModel, model);
        }


        // -- DELETE --

        // DELETE: api/SwitchModels/Delete/{id}
        [HttpDelete("{id}"), ActionName("Delete")]
        [SwaggerOperation(Summary = "Deletes Switch Model.")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryDelete(DataOperations.DeleteSwitchModel, id);
        }
    }
}
