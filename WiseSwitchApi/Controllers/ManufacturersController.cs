﻿using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WiseSwitchApi.Dtos.Manufacturer;
using WiseSwitchApi.Helpers;

namespace WiseSwitchApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly ControllerHelper _helper;

        public ManufacturersController(ControllerHelper helper)
        {
            _helper = helper;
        }


        // -- GET --

        // GET: api/Manufacturers/All
        [HttpGet, ActionName("All")]
        [SwaggerOperation(Summary = "Gets all Manufacturers, ordered by Name.")]
        public async Task<IActionResult> GetAllManufacturersOrderByName()
        {
            return await _helper.TryGet(DataOperations.GetAllManufacturersOrderByName, null);
        }

        // GET: api/Manufacturers/Combo
        [HttpGet, ActionName("Combo")]
        [SwaggerOperation(Summary = "Gets all Manufacturers as a Combo, ordered by Name.")]
        public async Task<IActionResult> GetComboManufacturers()
        {
            return await _helper.TryGet(DataOperations.GetAllManufacturersCombo, null);
        }

        // GET: api/Manufacturers/Display/{id}
        [HttpGet("{id}"), ActionName("Display")]
        [SwaggerOperation(Summary = "Gets the display model.")]
        public async Task<IActionResult> GetDisplayModel(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetManufacturerDisplay, id);
        }

        // GET: api/Manufacturers/EditModel/{id}
        [HttpGet("{id}"), ActionName("EditModel")]
        [SwaggerOperation(Summary = "Gets the edit model.")]
        public async Task<IActionResult> GetEditModel(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetManufacturerEditModel, id);
        }

        // GET: api/Manufacturers/Exists/{id}
        [HttpGet("{id}"), ActionName("Exists")]
        [SwaggerOperation(Summary = "Gets bool whether object exists in the database.")]
        public async Task<IActionResult> GetExists(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetManufacturerExists, id);
        }

        // GET: api/Manufacturers/Model/{id}
        [HttpGet("{id}"), ActionName("Model")]
        [SwaggerOperation(Summary = "Gets object as registered in the database.")]
        public async Task<IActionResult> GetModel(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryGet(DataOperations.GetManufacturer, id);
        }


        // -- POST --

        // POST: api/Manufacturers/Create
        [HttpPost, ActionName("Create")]
        [SwaggerOperation(Summary = "Creates Manufacturer.")]
        public async Task<IActionResult> Post([FromBody] CreateManufacturerDto model)
        {
            return await _helper.TryPost(DataOperations.CreateManufacturer, model);
        }


        // -- PUT --

        // PUT: api/Manufacturers/Update
        [HttpPut, ActionName("Update")]
        [SwaggerOperation(Summary = "Updates Manufacturer.")]
        public async Task<IActionResult> Put([FromBody] EditManufacturerDto model)
        {
            return await _helper.TryPut(DataOperations.UpdateManufacturer, model);
        }


        // -- DELETE --

        // DELETE: api/Manufacturers/Delete/{id}
        [HttpDelete("{id}"), ActionName("Delete")]
        [SwaggerOperation(Summary = "Deletes Manufacturer.")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return ControllerHelper.IdIsNotValid(id);

            return await _helper.TryDelete(DataOperations.DeleteManufacturer, id);
        }
    }
}
