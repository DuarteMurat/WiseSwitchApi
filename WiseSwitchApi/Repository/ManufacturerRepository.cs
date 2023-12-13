using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WiseSwitchApi.Data;
using WiseSwitchApi.Dtos.Manufacturer;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Repository
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly DbSet<Manufacturer> _manufacturerDbSet;

        public ManufacturerRepository(DataContext context)
        {
            _manufacturerDbSet = context.Manufacturers;
        }


        public async Task<Manufacturer> CreateAsync(Manufacturer manufacturer)
        {
            return (await _manufacturerDbSet.AddAsync(manufacturer)).Entity;
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

        public async Task<Manufacturer> DeleteAsync(int id)
        {
            return _manufacturerDbSet.Remove(await _manufacturerDbSet.FindAsync(id)).Entity;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _manufacturerDbSet.AnyAsync(manufacturer => manufacturer.Id == id);
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _manufacturerDbSet.AnyAsync(manufacturer => manufacturer.Name == name);
        }

        public IQueryable<Manufacturer> GetAllAsNoTracking()
        {
            return _manufacturerDbSet.AsNoTracking();
        }

        public async Task<IEnumerable<IndexRowManufacturerDto>> GetAllOrderByNameAsync()
        {
            return await _manufacturerDbSet
                .OrderBy(manufacturer => manufacturer.Name)
                .Select(manufacturer => new IndexRowManufacturerDto
                {
                    Id = manufacturer.Id,
                    Name = manufacturer.Name,
                })
                .ToListAsync();
        }

        public async Task<Manufacturer> GetAsNoTrackingByIdAsync(int id)
        {
            return await _manufacturerDbSet
                .AsNoTracking()
                .SingleOrDefaultAsync(manufacturer => manufacturer.Id == id);
        }

        public async Task<IEnumerable<SelectListItem>> GetComboManufacturersAsync()
        {
            return await _manufacturerDbSet
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
                .OrderBy(x => x.Text)
                .ToListAsync();
        }

        public async Task<DisplayManufacturerDto> GetDisplayDtoAsync(int id)
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

        public async Task<EditManufacturerDto> GetEditDtoAsync(int id)
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

        public Manufacturer Update(Manufacturer manufacturer)
        {
            return _manufacturerDbSet.Update(manufacturer).Entity;
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
