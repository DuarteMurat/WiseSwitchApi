using Microsoft.AspNetCore.Mvc.Rendering;
using WiseSwitchApi.Dtos.ProductSeries;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface IProductSeriesRepository
    {
        Task<ProductSeries> CreateAsync(ProductSeries productSeries);
        Task<ProductSeries> CreateFromObjectAsync(object value);
        Task<ProductSeries> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsAsync(string productSeriesName);
        IQueryable<ProductSeries> GetAllAsNoTracking();
        Task<IEnumerable<IndexRowProductSeriesDto>> GetAllOrderByNameAsync();
        Task<ProductSeries> GetAsNoTrackingByIdAsync(int id);
        Task<IEnumerable<SelectListItem>> GetComboProductSeriesAsync();
        Task<IEnumerable<SelectListItem>> GetComboProductSeriesOfProductLineAsync(int productLineId);
        Task<DisplayProductSeriesDto> GetDisplayDtoAsync(int id);
        Task<EditProductSeriesDto> GetEditDtoAsync(int id);
        Task<ProductSeries> GetForUpdateAsync(int id);
        Task<int> GetIdFromNameAsync(string name);
        Task<IEnumerable<string>> GetProductSeriesNamesOfProductLineAsync(int productLineId);
        ProductSeries Update(ProductSeries productSeries);
        ProductSeries UpdateFromObject(object value);
    }
}