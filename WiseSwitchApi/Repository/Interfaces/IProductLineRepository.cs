using Microsoft.AspNetCore.Mvc.Rendering;
using WiseSwitchApi.Dtos.ProductLine;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface IProductLineRepository
    {
        Task<ProductLine> CreateAsync(ProductLine productLine);
        Task<ProductLine> CreateFromObjectAsync(object value);
        Task<ProductLine> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsAsync(string productLineName);
        IQueryable<ProductLine> GetAllAsNoTracking();
        Task<IEnumerable<IndexRowProductLineDto>> GetAllOrderByNameAsync();
        Task<ProductLine> GetAsNoTrackingByIdAsync(int id);
        Task<int> GetBrandIdAsync(int id);
        Task<IEnumerable<SelectListItem>> GetComboProductLinesAsync();
        Task<IEnumerable<SelectListItem>> GetComboProductLinesOfBrandAsync(int brandId);
        Task<DisplayProductLineDto> GetDisplayDtoAsync(int id);
        Task<EditProductLineDto> GetEditDtoAsync(int id);
        Task<int> GetIdFromNameAsync(string name);
        Task<IEnumerable<string>> GetProductLinesNamesOfBrandAsync(int brandId);
        ProductLine Update(ProductLine productLine);
        ProductLine UpdateFromObject(object value);
    }
}