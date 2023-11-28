﻿using WiseSwitchApi.Dtos;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface ISwitchModelRepository
    {
        Task CreateAsync(SwitchModel switchModel);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsAsync(string modelName);
        Task<IEnumerable<IndexRowSwitchModelDto>> GetAllOrderByModelNameAsync();
        Task<SwitchModel> GetAsNoTrackingByIdAsync(int id);
        Task<int> GetBrandIdAsync(int switchModelId);
        Task<IEnumerable<string>> GetSwitchModelsNamesOfFirmwareVersionAsync(int firmwareVersionId);
        Task<IEnumerable<string>> GetSwitchModelsNamesOfProductSeriesAsync(int productSeriesId);
        void Update(SwitchModel switchModel);
    }
}