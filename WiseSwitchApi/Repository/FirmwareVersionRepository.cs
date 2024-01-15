using Microsoft.EntityFrameworkCore;
using WiseSwitchApi.Data;
using WiseSwitchApi.Dtos.FirmwareVersion;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Repository
{
    public class FirmwareVersionRepository : GenericRepository<FirmwareVersion>, IFirmwareVersionRepository
    {
        private readonly DbSet<FirmwareVersion> _firmwareVersionDbSet;

        public FirmwareVersionRepository(DataContext dataContext) : base(dataContext)
        {
            _firmwareVersionDbSet = dataContext.FirmwareVersions;
        }


        public async Task<DisplayFirmwareVersionDto> CreateAsync(CreateFirmwareVersionDto model)
        {
            var created = await CreateAsync(new FirmwareVersion
            {
                Version = model.Version,
                LaunchDate = model.LaunchDate,
            });

            return await GetDisplayModelAsync(created.Id);
        }

        public async Task<bool> ExistsAsync(string version)
        {
            return await _firmwareVersionDbSet.AnyAsync(firmwareVersion => firmwareVersion.Version == version);
        }

        public async Task<IEnumerable<IndexRowFirmwareVersionDto>> GetAllAsync()
        {
            return await _firmwareVersionDbSet
                .Select(firmwareVersion => new IndexRowFirmwareVersionDto
                {
                    Id = firmwareVersion.Id,
                    Version = firmwareVersion.Version,
                    LaunchDate = firmwareVersion.LaunchDate,
                })
                .OrderBy(firmwareVersion => firmwareVersion.Version)
                .ToListAsync();
        }

        public async Task<DisplayFirmwareVersionDto> GetDisplayModelAsync(int id)
        {
            return await _firmwareVersionDbSet
                .Where(firmwareVersion => firmwareVersion.Id == id)
                .Select(firmwareVersion => new DisplayFirmwareVersionDto
                {
                    Id = firmwareVersion.Id,
                    Version = firmwareVersion.Version,
                    SwitchModelsNames = firmwareVersion.SwitchModels.Select(switchModel => switchModel.ModelName)
                })
                .SingleOrDefaultAsync();
        }

        public async Task<EditFirmwareVersionDto> GetEditModelAsync(int id)
        {
            return await _firmwareVersionDbSet
                .Where(firmwareVersion => firmwareVersion.Id == id)
                .Select(firmwareVersion => new EditFirmwareVersionDto
                {
                    Id = firmwareVersion.Id,
                    Version = firmwareVersion.Version,
                    LaunchDate = firmwareVersion.LaunchDate,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<DisplayFirmwareVersionDto> Update(EditFirmwareVersionDto model)
        {
            var updated = Update(new FirmwareVersion
            {
                Id = model.Id,
                Version = model.Version,
                LaunchDate = model.LaunchDate,
            });

            return await GetDisplayModelAsync(updated.Id);
        }


        public async Task<FirmwareVersion> CreateFromObjectAsync(object value)
        {
            if (value is FirmwareVersion firmwareVersion) return await CreateAsync(firmwareVersion);

            if (value is CreateFirmwareVersionDto createDto)
            {
                return await CreateAsync(new FirmwareVersion
                {
                    Version = createDto.Version,
                    LaunchDate = createDto.LaunchDate,
                });
            }

            throw new NotImplementedException();
        }

        public async Task<int> GetIdFromVersionAsync(string version)
        {
            return await _firmwareVersionDbSet
                .Where(firmwareVersion => firmwareVersion.Version == version)
                .Select(firmwareVersion => firmwareVersion.Id)
                .SingleOrDefaultAsync();
        }

        public FirmwareVersion UpdateFromObject(object value)
        {
            if (value is FirmwareVersion firmwareVersion) return Update(firmwareVersion);

            if (value is EditFirmwareVersionDto editDto)
            {
                return Update(new FirmwareVersion
                {
                    Id = editDto.Id,
                    Version = editDto.Version,
                    LaunchDate = editDto.LaunchDate,
                });
            }

            throw new NotImplementedException();
        }
    }
}
