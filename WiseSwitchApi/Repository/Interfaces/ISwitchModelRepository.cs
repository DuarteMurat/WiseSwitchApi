using Microsoft.AspNetCore.Mvc.Rendering;
using WiseSwitchApi.Dtos;
using WiseSwitchApi.Dtos.SwitchModel;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface ISwitchModelRepository
    {
        Task<SwitchModel> CreateAsync(SwitchModel switchModel);
        Task<SwitchModel> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsAsync(string modelName);
        Task<IEnumerable<IndexRowSwitchModelDto>> GetAllOrderByModelNameAsync();
        Task<SwitchModel> GetAsNoTrackingByIdAsync(int id);
        Task<int> GetBrandIdAsync(int switchModelId);
        Task<IEnumerable<string>> GetSwitchModelsNamesOfFirmwareVersionAsync(int firmwareVersionId);
        Task<IEnumerable<string>> GetSwitchModelsNamesOfProductSeriesAsync(int productSeriesId);
        Task<IEnumerable<SelectListItem>> GetComboSwitchModelsAsync();
        Task<DisplaySwitchModelDto> GetDisplayDtoAsync(int id);
        SwitchModel Update(SwitchModel switchModel);
    }
}