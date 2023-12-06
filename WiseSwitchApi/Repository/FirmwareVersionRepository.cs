using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WiseSwitchApi.Data;
using WiseSwitchApi.Dtos.FirmwareVersion;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Repository
{
    public class FirmwareVersionRepository : IFirmwareVersionRepository
    {
        private readonly DbSet<FirmwareVersion> _firmwareVersionDbSet;

        public FirmwareVersionRepository(DataContext context)
        {
            _firmwareVersionDbSet = context.FirmwareVersions;
        }


        public async Task<FirmwareVersion> CreateAsync(FirmwareVersion firmwareVersion)
        {
            return (await _firmwareVersionDbSet.AddAsync(firmwareVersion)).Entity;
        }

        public async Task<FirmwareVersion> DeleteAsync(int id)
        {
            return _firmwareVersionDbSet.Remove(await _firmwareVersionDbSet.FindAsync(id)).Entity;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _firmwareVersionDbSet.AnyAsync(firmwareVersion => firmwareVersion.Id == id);
        }

        public async Task<bool> ExistsAsync(string version)
        {
            return await _firmwareVersionDbSet.AnyAsync(firmwareVersion => firmwareVersion.Version == version);
        }

        public async Task<IEnumerable<FirmwareVersion>> GetAllOrderByVersionAsync()
        {
            return await _firmwareVersionDbSet
                .AsNoTracking()
                .OrderBy(firmwareVersion => firmwareVersion.Version)
                .ToListAsync();
        }

        public async Task<FirmwareVersion> GetAsNoTrackingByIdAsync(int id)
        {
            return await _firmwareVersionDbSet.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<SelectListItem>> GetComboFirmwareVersionsAsync()
        {
            return await _firmwareVersionDbSet
                .Select(firmwareVersion => new SelectListItem
                {
                    Text = firmwareVersion.Version,
                    Value = firmwareVersion.Id.ToString(),
                })
                .ToListAsync();
        }

        public async Task<DisplayFirmwareVersionDto> GetDisplayDtoAsync(int id)
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

        public async Task<int> GetIdFromVersionAsync(string version)
        {
            return await _firmwareVersionDbSet
                .Where(firmwareVersion => firmwareVersion.Version == version)
                .Select(firmwareVersion => firmwareVersion.Id)
                .SingleOrDefaultAsync();
        }

        public FirmwareVersion Update(FirmwareVersion firmwareVersion)
        {
            return _firmwareVersionDbSet.Update(firmwareVersion).Entity;
        }
    }
}
