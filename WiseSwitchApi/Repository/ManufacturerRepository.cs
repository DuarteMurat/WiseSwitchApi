using Microsoft.EntityFrameworkCore;
using WiseSwitchApi.Data;
using WiseSwitchApi.Dtos.Manufacturer;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Repository
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
    {
        private readonly DbSet<Manufacturer> _manufacturerDbSet;

        public ManufacturerRepository(DataContext dataContext) : base(dataContext)
        {
            _manufacturerDbSet = dataContext.Manufacturers;
        }


        public async Task<Manufacturer> CreateFromObjectAsync(object value)
        {
            if (value is Manufacturer manufacturer) return await CreateAsync(manufacturer);

            if (value is CreateManufacturerDto createDto)
            {
                return await CreateAsync(new Manufacturer
                {
                    Name = createDto.Name,
                });
            }

            throw new NotImplementedException();
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _manufacturerDbSet.AnyAsync(manufacturer => manufacturer.Name == name);
        }

        public async Task<IEnumerable<IndexRowManufacturerDto>> GetAllAsync()
        {
            return await _manufacturerDbSet
                .Select(manufacturer => new IndexRowManufacturerDto
                {
                    Id = manufacturer.Id,
                    Name = manufacturer.Name,
                })
                .OrderBy(manufacturer => manufacturer.Name)
                .ToListAsync();
        }


        public async Task<DisplayManufacturerDto> GetDisplayModelAsync(int id)
        {
            return await _manufacturerDbSet
                .Where(manufacturer => manufacturer.Id == id)
                .Select(manufacturer => new DisplayManufacturerDto
                {
                    Id = manufacturer.Id,
                    Name = manufacturer.Name,
                    BrandsNames = manufacturer.Brands.Select(brand => brand.Name)
                })
                .SingleOrDefaultAsync();
        }

        public async Task<EditManufacturerDto> GetEditModelAsync(int id)
        {
            return await _manufacturerDbSet
                .Where(manufacturer => manufacturer.Id == id)
                .Select(manufacturer => new EditManufacturerDto
                {
                    Id = manufacturer.Id,
                    Name = manufacturer.Name,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<int> GetIdFromNameAsync(string name)
        {
            return await _manufacturerDbSet
                .Where(manufacturer => manufacturer.Name == name)
                .Select(manufacturer => manufacturer.Id)
                .SingleOrDefaultAsync();
        }

        public Manufacturer UpdateFromObject(object value)
        {
            if (value is Manufacturer manufacturer) return Update(manufacturer);

            if (value is EditManufacturerDto editDto)
            {
                return Update(new Manufacturer
                {
                    Id = editDto.Id,
                    Name = editDto.Name,
                });
            }

            throw new NotImplementedException();
        }
    }
}
