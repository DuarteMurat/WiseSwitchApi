using WiseSwitchApi.Dtos.FirmwareVersion;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface IFirmwareVersionRepository : IGenericRepository<FirmwareVersion>
    {
        Task<FirmwareVersion> CreateFromObjectAsync(object value);
        Task<IEnumerable<IndexRowFirmwareVersionDto>> GetAllAsync();
        Task<DisplayFirmwareVersionDto> GetDisplayModelAsync(int id);
        Task<EditFirmwareVersionDto> GetEditModelAsync(int id);
        Task<int> GetIdFromVersionAsync(string version);
        FirmwareVersion UpdateFromObject(object value);
    }
}