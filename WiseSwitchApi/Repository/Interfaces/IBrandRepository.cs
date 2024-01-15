using WiseSwitchApi.Dtos.Brand;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task<Brand> CreateFromObjectAsync(object value);
        Task<bool> ExistsAsync(string name);
        Task<IEnumerable<IndexRowBrandDto>> GetAllAsync();
        Task<IEnumerable<string>> GetBrandNamesOfManufacturerAsync(int manufacturerId);
        Task<DisplayBrandDto> GetDisplayModelAsync(int id);
        Task<EditBrandDto> GetEditModelAsync(int id);
        Task<int> GetIdFromNameAsync(string brandName);
        Brand UpdateFromObject(object value);
    }
}