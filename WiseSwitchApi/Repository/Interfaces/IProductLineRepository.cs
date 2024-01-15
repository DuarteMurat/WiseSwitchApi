using Microsoft.AspNetCore.Mvc.Rendering;
using WiseSwitchApi.Dtos.ProductLine;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface IProductLineRepository : IGenericRepository<ProductLine>
    {
        Task<ProductLine> CreateFromObjectAsync(object value);
        Task<IEnumerable<IndexRowProductLineDto>> GetAllAsync();
        Task<int> GetBrandIdAsync(int id);
        Task<IEnumerable<SelectListItem>> GetComboProductLinesOfBrandAsync(int brandId);
        Task<DisplayProductLineDto> GetDisplayModelAsync(int id);
        Task<EditProductLineDto> GetEditModelAsync(int id);
        Task<int> GetIdFromNameAsync(string name);
        Task<IEnumerable<string>> GetProductLinesNamesOfBrandAsync(int brandId);
        ProductLine UpdateFromObject(object value);
    }
}