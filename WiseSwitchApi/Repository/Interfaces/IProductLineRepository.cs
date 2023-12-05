using Microsoft.AspNetCore.Mvc.Rendering;
using WiseSwitchApi.Dtos;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface IProductLineRepository
    {
        Task CreateAsync(ProductLine productLine);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsAsync(string productLineName);
        IQueryable<ProductLine> GetAllAsNoTracking();
        Task<IEnumerable<IndexRowProductLineDto>> GetAllOrderByName();
        Task<ProductLine> GetAsNoTrackingByIdAsync(int id);
        Task<IEnumerable<SelectListItem>> GetComboProductLinesAsync();
        Task<IEnumerable<SelectListItem>> GetComboProductLinesOfBrandAsync(int brandId);
        Task<int> GetIdFromNameAsync(string name);
        Task<IEnumerable<string>> GetProductLinesNamesOfBrandAsync(int brandId);
        void Update(ProductLine productLine);

        Task<DisplayProductLineDto> GetDisplayDtoAsync(int id);
    }
}