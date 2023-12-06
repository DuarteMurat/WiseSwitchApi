using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WiseSwitchApi.Data;
using WiseSwitchApi.Dtos;
using WiseSwitchApi.Dtos.ProductSeries;
using WiseSwitchApi.Dtos.SwitchModel;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Repository
{
    public class SwitchModelRepository : ISwitchModelRepository
    {
        public DbSet<SwitchModel> _switchModelDbSet;

        public SwitchModelRepository(DataContext context)
        {
            _switchModelDbSet = context.SwitchModels;
        }


        public async Task<SwitchModel> CreateAsync(SwitchModel switchModel)
        {
            return (await _switchModelDbSet.AddAsync(switchModel)).Entity;
        }

        public async Task<SwitchModel> DeleteAsync(int id)
        {
            return _switchModelDbSet.Remove(await _switchModelDbSet.FindAsync(id)).Entity;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _switchModelDbSet.AnyAsync(brand => brand.Id == id);
        }

        public async Task<bool> ExistsAsync(string modelName)
        {
            return await _switchModelDbSet.AnyAsync(brand => brand.ModelName == modelName);
        }

        public async Task<IEnumerable<IndexRowSwitchModelDto>> GetAllOrderByModelNameAsync()
        {
            return await _switchModelDbSet
                .OrderBy(switchModel => switchModel.ModelName)
                .Select(switchModel => new IndexRowSwitchModelDto
                {
                    Id = switchModel.Id,
                    ModelName = switchModel.ModelName,
                    ModelYear = switchModel.ModelYear,
                    FirmwareVersion = switchModel.DefaultFirmwareVersion.Version,
                    ProductSeries = switchModel.ProductSeries.Name,
                    ProductLine = switchModel.ProductSeries.ProductLine.Name,
                    Brand = switchModel.ProductSeries.ProductLine.Brand.Name,
                })
                .ToListAsync();
        }

        public async Task<SwitchModel> GetAsNoTrackingByIdAsync(int id)
        {
            return await _switchModelDbSet.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetBrandIdAsync(int switchModelId)
        {
            return await _switchModelDbSet
                .Where(switchModel => switchModel.Id == switchModelId)
                .Select(switchModel => switchModel.ProductSeries.ProductLine.Brand.Id)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<string>> GetSwitchModelsNamesOfFirmwareVersionAsync(int firmwareVersionId)
        {
            return await _switchModelDbSet
                .Where(switchModel => switchModel.DefaultFirmwareVersionId == firmwareVersionId)
                .Select(switchModel => switchModel.ModelName)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetSwitchModelsNamesOfProductSeriesAsync(int productSeriesId)
        {
            return await _switchModelDbSet
                .Where(switchModel => switchModel.ProductSeriesId == productSeriesId)
                .Select(switchModel => switchModel.ModelName)
                .ToListAsync();
        }
        public async Task<IEnumerable<SelectListItem>> GetComboSwitchModelsAsync()
        {
            return await _switchModelDbSet
                .Select(SwitchModel => new SelectListItem
                {
                    Text = SwitchModel.ModelName,
                    Value = SwitchModel.Id.ToString()
                })
                .ToListAsync();
        }

        public async Task<DisplaySwitchModelDto> GetDisplayDtoAsync(int id)
        {
            return await _switchModelDbSet
                .Where(switchModel => switchModel.Id == id)
                .Select(switchModel => new DisplaySwitchModelDto
                {
                    Id = switchModel.Id,
                    Name = switchModel.ModelName,
                    ProductSeriesName = switchModel.ProductSeries.Name,
                    FirmwareVersionName = switchModel.DefaultFirmwareVersion.Version,
                })
                .SingleOrDefaultAsync();
        }

        public SwitchModel Update(SwitchModel switchModel)
        {
            return _switchModelDbSet.Update(switchModel).Entity;
        }
    }
}
