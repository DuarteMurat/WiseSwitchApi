using Microsoft.AspNetCore.Mvc.Rendering;
using WiseSwitchApi.Dtos;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface IBrandRepository
    {
        Task CreateAsync(Brand brand);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsAsync(string name);
        Task<IEnumerable<IndexRowBrandDto>> GetAllOrderByNameAsync();
        Task<Brand> GetAsNoTrackingByIdAsync(int id);
        Task<IEnumerable<string>> GetBrandNamesOfManufacturerAsync(int manufacturerId);
        Task<IEnumerable<SelectListItem>> GetComboBrandsAsync();
        Task<DisplayBrandDto> GetDisplayDtoAsync(int id);
        Task<int> GetIdFromNameAsync(string brandName);
        void Update(Brand brand);
    }
}