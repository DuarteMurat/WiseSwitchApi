using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WiseSwitchApi.Data;
using WiseSwitchApi.Dtos;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly DbSet<Brand> _brandDbSet;

        public BrandRepository(DataContext context)
        {
            _brandDbSet = context.Brands;
        }


        public async Task<Brand> CreateAsync(Brand brand)
        {
            return (await _brandDbSet.AddAsync(brand)).Entity;
        }

        public async Task<Brand> DeleteAsync(int id)
        {
            return _brandDbSet.Remove(await _brandDbSet.FindAsync(id)).Entity;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _brandDbSet.AnyAsync(brand => brand.Id == id);
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _brandDbSet.AnyAsync(brand => brand.Name == name);
        }

        public async Task<IEnumerable<IndexRowBrandDto>> GetAllOrderByNameAsync()
        {
            return await _brandDbSet
                .OrderBy(brand => brand.Name)
                .Select(brand => new IndexRowBrandDto
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    ManufacturerName = brand.Manufacturer.Name,
                })
                .ToListAsync();
        }

        public async Task<Brand> GetAsNoTrackingByIdAsync(int id)
        {
            return await _brandDbSet.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<string>> GetBrandNamesOfManufacturerAsync(int manufacturerId)
        {
            return await _brandDbSet
                .Where(brand => brand.ManufacturerId == manufacturerId)
                .Select(brand => brand.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetComboBrandsAsync()
        {
            return await _brandDbSet
                .Select(brand => new SelectListItem
                {
                    Text = brand.Name,
                    Value = brand.Id.ToString()
                })
                .ToListAsync();
        }

        public async Task<DisplayBrandDto> GetDisplayDtoAsync(int id)
        {
            return await _brandDbSet
                .Where(brand => brand.Id == id)
                .Select(brand => new DisplayBrandDto
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    ManufacturerName = brand.Manufacturer.Name,
                    ProductLinesNames = brand.ProductLines.Select(productLine => productLine.Name),
                })
                .SingleOrDefaultAsync();
        }

        public async Task<int> GetIdFromNameAsync(string name)
        {
            return await _brandDbSet
                .Where(brand => brand.Name == name)
                .Select(brand => brand.Id)
                .SingleOrDefaultAsync();
        }

        public Brand Update(Brand brand)
        {
             return _brandDbSet.Update(brand).Entity;
        }
    }
}
