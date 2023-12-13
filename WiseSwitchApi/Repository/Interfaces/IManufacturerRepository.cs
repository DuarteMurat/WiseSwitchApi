using Microsoft.AspNetCore.Mvc.Rendering;
using WiseSwitchApi.Dtos.Manufacturer;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface IManufacturerRepository
    {
        Task<Manufacturer> CreateAsync(Manufacturer manufacturer);
        Task<Manufacturer> CreateFromObjectAsync(object value);
        Task<Manufacturer> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsAsync(string name);
        IQueryable<Manufacturer> GetAllAsNoTracking();
        Task<IEnumerable<IndexRowManufacturerDto>> GetAllOrderByNameAsync();
        Task<Manufacturer> GetAsNoTrackingByIdAsync(int id);
        Task<IEnumerable<SelectListItem>> GetComboManufacturersAsync();
        Task<DisplayManufacturerDto> GetDisplayDtoAsync(int id);
        Task<EditManufacturerDto> GetEditDtoAsync(int id);
        Task<int> GetIdFromNameAsync(string name);
        Manufacturer Update(Manufacturer manufacturer);
        Manufacturer UpdateFromObject(object value);
    }
}