using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WiseSwitchApi.Data;
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

        public async Task<SwitchModel> CreateFromObjectAsync(object value)
        {
            if (value is SwitchModel switchModel) return await CreateAsync(switchModel);

            if (value is CreateSwitchModelDto createDto)
            {
                return await CreateAsync(new SwitchModel
                {
                    ModelName = createDto.ModelName,
                    ModelYear = createDto.ModelYear,
                    DefaultFirmwareVersionId = createDto.DefaultFirmwareVersionId,
                    ProductSeriesId = createDto.ProductSeriesId,
                });
            }

            throw new NotImplementedException();
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
                    DefaultFirmwareVersion = switchModel.DefaultFirmwareVersion.Version,
                    ProductSeriesName = switchModel.ProductSeries.Name,
                    ProductLineName = switchModel.ProductSeries.ProductLine.Name,
                    BrandName = switchModel.ProductSeries.ProductLine.Brand.Name,
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

        public async Task<EditSwitchModelDto> GetEditDtoAsync(int id)
        {
            return await _switchModelDbSet
                .Where(switchModel => switchModel.Id == id)
                .Select(switchModel => new EditSwitchModelDto
                {
                    Id = switchModel.Id,
                    ModelName = switchModel.ModelName,
                    ModelYear = switchModel.ModelYear,
                    DefaultFirmwareVersionId = switchModel.DefaultFirmwareVersionId,
                    ProductSeriesId = switchModel.ProductSeriesId,
                    ProductLineId = switchModel.ProductSeries.ProductLineId,
                    BrandId = switchModel.ProductSeries.ProductLine.BrandId,
                })
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

        public SwitchModel Update(SwitchModel switchModel)
        {
            return _switchModelDbSet.Update(switchModel).Entity;
        }

        public SwitchModel UpdateFromObject(object value)
        {
            if (value is SwitchModel switchModel) return Update(switchModel);

            if (value is EditSwitchModelDto editDto)
            {
                return Update(new SwitchModel
                {
                    Id = editDto.Id,
                    ModelName = editDto.ModelName,
                    ModelYear = editDto.ModelYear,
                    DefaultFirmwareVersionId = editDto.DefaultFirmwareVersionId,
                    ProductSeriesId = editDto.ProductSeriesId,
                });
            }

            throw new NotImplementedException();
        }
    }
}
