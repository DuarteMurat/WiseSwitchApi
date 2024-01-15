using WiseSwitchApi.Dtos.SwitchModel;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface ISwitchModelRepository : IGenericRepository<SwitchModel>
    {
        Task<SwitchModel> CreateFromObjectAsync(object value);
        Task<bool> ExistsAsync(string name);
        Task<IEnumerable<IndexRowSwitchModelDto>> GetAllAsync();
        Task<int> GetBrandIdAsync(int switchModelId);
        Task<DisplaySwitchModelDto> GetDisplayModelAsync(int id);
        Task<EditSwitchModelDto> GetEditModelAsync(int id);
        Task<IEnumerable<string>> GetSwitchModelsNamesOfFirmwareVersionAsync(int firmwareVersionId);
        Task<IEnumerable<string>> GetSwitchModelsNamesOfProductSeriesAsync(int productSeriesId);
        SwitchModel UpdateFromObject(object value);
    }
}