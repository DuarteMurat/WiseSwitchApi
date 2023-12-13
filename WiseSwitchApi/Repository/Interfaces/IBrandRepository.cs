using Microsoft.AspNetCore.Mvc.Rendering;
using WiseSwitchApi.Dtos.Brand;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface IBrandRepository
    {
        Task<Brand> CreateAsync(Brand brand);
        Task<Brand> CreateFromObjectAsync(object value);
        Task<Brand> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsAsync(string name);
        Task<IEnumerable<IndexRowBrandDto>> GetAllOrderByNameAsync();
        Task<Brand> GetAsNoTrackingByIdAsync(int id);
        Task<IEnumerable<string>> GetBrandNamesOfManufacturerAsync(int manufacturerId);
        Task<IEnumerable<SelectListItem>> GetComboBrandsAsync();
        Task<DisplayBrandDto> GetDisplayDtoAsync(int id);
        Task<EditBrandDto> GetEditDtoAsync(int id);
        Task<int> GetIdFromNameAsync(string brandName);
        Brand Update(Brand brand);
        Brand UpdateFromObject(object value);
    }
}