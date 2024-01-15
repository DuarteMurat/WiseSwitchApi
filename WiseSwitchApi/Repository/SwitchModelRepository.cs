using Microsoft.EntityFrameworkCore;
using WiseSwitchApi.Data;
using WiseSwitchApi.Dtos.SwitchModel;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Repository
{
    public class SwitchModelRepository : GenericRepository<SwitchModel>, ISwitchModelRepository
    {
        public DbSet<SwitchModel> _switchModelDbSet;

        public SwitchModelRepository(DataContext dataContext) : base(dataContext)
        {
            _switchModelDbSet = dataContext.SwitchModels;
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

        public async Task<bool> ExistsAsync(string modelName)
        {
            return await _switchModelDbSet.AnyAsync(switchModel => switchModel.ModelName == modelName);
        }

        public async Task<IEnumerable<IndexRowSwitchModelDto>> GetAllAsync()
        {
            return await _switchModelDbSet
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
                .OrderBy(switchModel => switchModel.ModelName)
                .ToListAsync();
        }

        public async Task<int> GetBrandIdAsync(int switchModelId)
        {
            return await _switchModelDbSet
                .Where(switchModel => switchModel.Id == switchModelId)
                .Select(switchModel => switchModel.ProductSeries.ProductLine.Brand.Id)
                .SingleOrDefaultAsync();
        }

        public async Task<DisplaySwitchModelDto> GetDisplayModelAsync(int id)
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

        public async Task<EditSwitchModelDto> GetEditModelAsync(int id)
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
