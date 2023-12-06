using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WiseSwitchApi.Dtos;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Helpers;
using WiseSwitchApi.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpGet, ActionName("All")]
        [SwaggerOperation(Summary = "Gets all Switch Models, ordered by Name.")]
        public async Task<IActionResult> GetAllSwitchModelsOrderByName()
        {
            return await _helper.TryGet(DataOperations.GetAllSwitchModelsOrderByName, null);
        }


        [HttpGet, ActionName("Combo")]
        [SwaggerOperation(Summary = "Gets all Switch Models as a Combo, ordered by Name.")]
        public async Task<IActionResult> GetComboSwitchModels()
        {
            return await _helper.TryGet(DataOperations.GetComboSwitchModels, null);
        }


        [HttpGet("{id}"), ActionName("Display")]
        [SwaggerOperation(Summary = "Gets the display model.")]
        public async Task<IActionResult> GetDisplayDto(int id)
        {
            return await _helper.TryGet(DataOperations.GetDisplaySwitchModel, id);
        }


        [HttpGet("{id}"), ActionName("Exists")]
        [SwaggerOperation(Summary = "Gets bool whether object exists in the database.")]
        public async Task<IActionResult> GetExists(int id)
        {
            return await _helper.TryGet(DataOperations.GetExistsSwitchModel, id);
        }

        // -- POST --
        [HttpPost, ActionName("Create")]
        [SwaggerOperation(Summary = "Creates SwitchModels.")]
        public async Task<IActionResult> Post([FromBody] SwitchModel model)
        {
            return await _helper.TryPost(DataOperations.CreateSwitchModel, model);
        }

        // -- PUT --

        [HttpPut, ActionName("Edit")]
        [SwaggerOperation(Summary = "Updates SwitchModel.")]
        public async Task<IActionResult> Put([FromBody] SwitchModel model)
        {
            return await _helper.TryPut(DataOperations.UpdateSwitchModel, model);
        }

        // -- DELETE --

        [HttpDelete("{id}"), ActionName("Delete")]
        [SwaggerOperation(Summary = "Deletes SwitchModel.")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _helper.TryDelete(DataOperations.DeleteSwitchModel, id);
        }
    }
}
