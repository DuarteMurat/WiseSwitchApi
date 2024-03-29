﻿using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WiseSwitchApi.Dtos.FirmwareVersion;
using WiseSwitchApi.Helpers;

namespace WiseSwitchApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FirmwareVersionsController : ControllerBase
    {
        private readonly ControllerHelper _helper;

        public FirmwareVersionsController(ControllerHelper helper)
        {
            _helper = helper;
        }


        // -- GET --

        // GET: api/FirmwareVersions/All
        [HttpGet, ActionName("All")]
        [SwaggerOperation(Summary = "Gets all Firmware Versions, ordered by Version.")]
        public async Task<IActionResult> GetAll()
        {
            return await _helper.TryGet(DataOperations.GetAllFirmwareVersionsOrderByVersion, null);
        }

        // GET: api/FirmwareVersions/Combo
        [HttpGet, ActionName("Combo")]
        [SwaggerOperation(Summary = "Gets all Firmware Versions as a Combo, ordered by Version.")]
        public async Task<IActionResult> GetComboFirmwareVersions()
        {
            return await _helper.TryGet(DataOperations.GetAllFirmwareVersionsCombo, null);
        }

        // GET: api/FirmwareVersions/Display/{id}
        [HttpGet("{id}"), ActionName("Display")]
        [SwaggerOperation(Summary = "Gets the display model.")]
        public async Task<IActionResult> GetDisplayModel(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetFirmwareVersionDisplay, id);
        }

        // GET: api/FirmwareVersions/EditModel/{id}
        [HttpGet("{id}"), ActionName("EditModel")]
        [SwaggerOperation(Summary = "Gets the display model.")]
        public async Task<IActionResult> GetEditModel(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetFirmwareVersionEditModel, id);
        }

        // GET: api/FirmwareVersions/Exists/{id}
        [HttpGet("{id}"), ActionName("Exists")]
        [SwaggerOperation(Summary = "Gets bool whether object exists in the database.")]
        public async Task<IActionResult> GetExists(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetFirmwareVersionExists, id);
        }

        // GET: api/FirmwareVersions/Model/{id}
        [HttpGet("{id}"), ActionName("Model")]
        [SwaggerOperation(Summary = "Gets object as registered in the database.")]
        public async Task<IActionResult> GetModel(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetFirmwareVersion, id);
        }


        // -- POST --

        // POST api/FirmwareVersions/Create
        [HttpPost, ActionName("Create")]
        [SwaggerOperation(Summary = "Creates Firmware Version.")]
        public async Task<IActionResult> Post([FromBody] CreateFirmwareVersionDto model)
        {
            return await _helper.TryPost(DataOperations.CreateFirmwareVersion, model);
        }


        // -- PUT --

        // PUT api/FirmwareVersions/Update
        [HttpPut, ActionName("Update")]
        [SwaggerOperation(Summary = "Updates Firmware Version.")]
        public async Task<IActionResult> Put([FromBody] EditFirmwareVersionDto model)
        {
            return await _helper.TryPut(DataOperations.UpdateFirmwareVersion, model);
        }


        // -- DELETE --

        // DELETE api/FirmwareVersions/Delete/{id}
        [HttpDelete("{id}"), ActionName("Delete")]
        [SwaggerOperation(Summary = "Deletes Firmware Version.")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryDelete(DataOperations.DeleteFirmwareVersion, id);
        }
    }
}
