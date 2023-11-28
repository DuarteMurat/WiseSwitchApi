using Microsoft.AspNetCore.Mvc.Rendering;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface IManufacturerRepository
    {
        Task CreateAsync(Manufacturer manufacturer);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsAsync(string manufacturerName);
        IQueryable<Manufacturer> GetAllAsNoTracking();
        Task<IEnumerable<Manufacturer>> GetAllOrderByName();
        Task<Manufacturer> GetAsNoTrackingByIdAsync(int id);
        Task<IEnumerable<SelectListItem>> GetComboManufacturersAsync();
        Task<int> GetIdFromNameAsync(string name);
        void Update(Manufacturer manufacturer);
    }
}