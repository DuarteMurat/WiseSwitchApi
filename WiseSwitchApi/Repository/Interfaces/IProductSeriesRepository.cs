using Microsoft.AspNetCore.Mvc.Rendering;
using WiseSwitchApi.Dtos.ProductSeries;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface IProductSeriesRepository : IGenericRepository<ProductSeries>
    {
        Task<ProductSeries> CreateFromObjectAsync(object value);
        Task<bool> ExistsAsync(string name);
        Task<IEnumerable<IndexRowProductSeriesDto>> GetAllAsync();
        Task<IEnumerable<SelectListItem>> GetComboProductSeriesOfProductLineAsync(int productLineId);
        Task<ProductSeriesDependencyChainIds> GetDependencyChainIdsAsync(int id);
        Task<DisplayProductSeriesDto> GetDisplayModelAsync(int id);
        Task<EditProductSeriesDto> GetEditModelAsync(int id);
        Task<int> GetIdFromNameAsync(string name);
        Task<IEnumerable<string>> GetProductSeriesNamesOfProductLineAsync(int productLineId);
        ProductSeries UpdateFromObject(object value);
    }
}