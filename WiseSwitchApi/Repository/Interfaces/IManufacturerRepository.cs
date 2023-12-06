using Microsoft.AspNetCore.Mvc.Rendering;
using WiseSwitchApi.Dtos.Manufacturer;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface IManufacturerRepository
    {
        Task<Manufacturer> CreateAsync(Manufacturer manufacturer);
        Task<Manufacturer> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsAsync(string name);
        IQueryable<Manufacturer> GetAllAsNoTracking();
        Task<IEnumerable<Manufacturer>> GetAllOrderByName();
        Task<Manufacturer> GetAsNoTrackingByIdAsync(int id);
        Task<IEnumerable<SelectListItem>> GetComboManufacturersAsync();
        Task<DisplayManufacturerDto> GetDisplayDtoAsync(int id);
        Task<int> GetIdFromNameAsync(string name);
        Manufacturer Update(Manufacturer manufacturer);
    }
}