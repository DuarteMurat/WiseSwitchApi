using Microsoft.AspNetCore.Mvc.Rendering;
using WiseSwitchApi.Dtos.FirmwareVersion;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface IFirmwareVersionRepository
    {
        Task<FirmwareVersion> CreateAsync(FirmwareVersion firmwareVersion);
        Task<FirmwareVersion> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsAsync(string version);
        Task<IEnumerable<FirmwareVersion>> GetAllOrderByVersionAsync();
        Task<FirmwareVersion> GetAsNoTrackingByIdAsync(int id);
        Task<IEnumerable<SelectListItem>> GetComboFirmwareVersionsAsync();
        Task<DisplayFirmwareVersionDto> GetDisplayDtoAsync(int id);
        Task<int> GetIdFromVersionAsync(string version);
        FirmwareVersion Update(FirmwareVersion firmwareVersion);
    }
}