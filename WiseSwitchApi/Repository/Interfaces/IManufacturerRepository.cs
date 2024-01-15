using WiseSwitchApi.Dtos.Manufacturer;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface IManufacturerRepository : IGenericRepository<Manufacturer>
    {
        Task<Manufacturer> CreateFromObjectAsync(object value);
        Task<bool> ExistsAsync(string name);
        Task<IEnumerable<IndexRowManufacturerDto>> GetAllAsync();
        Task<DisplayManufacturerDto> GetDisplayModelAsync(int id);
        Task<EditManufacturerDto> GetEditModelAsync(int id);
        Task<int> GetIdFromNameAsync(string name);
        Manufacturer UpdateFromObject(object value);
    }
}