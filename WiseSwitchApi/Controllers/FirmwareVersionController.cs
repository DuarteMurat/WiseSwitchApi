﻿using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Helpers;

namespace WiseSwitchApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FirmwareVersionController : ControllerBase
    {
        private readonly ControllerHelper _helper;

        public FirmwareVersionController(ControllerHelper helper)
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
            return await _helper.TryGet(DataOperations.GetComboFirmwareVersions, null);
        }

        // GET: api/FirmwareVersions/Display/{id}
        [HttpGet("{id}"), ActionName("Display")]
        [SwaggerOperation(Summary = "Gets the display model.")]
        public async Task<IActionResult> GetDisplayDto(int id)
        {
            return await _helper.TryGet(DataOperations.GetDisplayFirmwareVersion, id);
        }

        // GET: api/FirmwareVersions/Exists/{id}
        [HttpGet("{id}"), ActionName("Exists")]
        [SwaggerOperation(Summary = "Gets bool whether object exists in the database.")]
        public async Task<IActionResult> GetExists(int id)
        {
            return await _helper.TryGet(DataOperations.GetExistsFirmwareVersion, id);
        }

        // GET: api/FirmwareVersions/Model/{id}
        [HttpGet("{id}"), ActionName("Model")]
        [SwaggerOperation(Summary = "Gets object as registered in the database.")]
        public async Task<IActionResult> GetMode(int id)
        {
            return await _helper.TryGet(DataOperations.GetModelFirmwareVersion, id);
        }


        // -- POST --

        // POST api/FirmwareVersions/Create
        [HttpPost, ActionName("Create")]
        [SwaggerOperation(Summary = "Creates Firmware Version.")]
        public async Task<IActionResult> Post([FromBody] FirmwareVersion model)
        {
            return await _helper.TryPost(DataOperations.CreateFirmwareVersion, model);
        }


        // -- PUT --

        // PUT api/FirmwareVersions/Update
        [HttpPut, ActionName("Update")]
        [SwaggerOperation(Summary = "Updates Firmware Version.")]
        public async Task<IActionResult> Put([FromBody] FirmwareVersion model)
        {
            return await _helper.TryPut(DataOperations.UpdateFirmwareVersion, model);
        }


        // -- DELETE --

        // DELETE api/FirmwareVersions/Delete/{id}
        [HttpDelete("{id}"), ActionName("Delete")]
        [SwaggerOperation(Summary = "Deletes Firmware Version.")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _helper.TryDelete(DataOperations.DeleteFirmwareVersion, id);
        }
    }
}
