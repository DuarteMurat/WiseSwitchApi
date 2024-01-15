using WiseSwitchApi.Dtos.FirmwareVersion;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface IFirmwareVersionRepository : IGenericRepository<FirmwareVersion>
    {
        Task<FirmwareVersion> CreateFromObjectAsync(object value);
        Task<bool> ExistsAsync(string version);
        Task<IEnumerable<IndexRowFirmwareVersionDto>> GetAllAsync();
        Task<DisplayFirmwareVersionDto> GetDisplayModelAsync(int id);
        Task<EditFirmwareVersionDto> GetEditModelAsync(int id);
        Task<int> GetIdFromVersionAsync(string version);
        FirmwareVersion UpdateFromObject(object value);
    }
}