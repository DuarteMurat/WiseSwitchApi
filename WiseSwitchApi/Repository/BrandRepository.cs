using Microsoft.EntityFrameworkCore;
using WiseSwitchApi.Data;
using WiseSwitchApi.Dtos.Brand;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Repository
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        private readonly DbSet<Brand> _brandDbSet;

        public BrandRepository(DataContext dataContext) : base(dataContext)
        {
            _brandDbSet = dataContext.Brands;
        }


        public async Task<DisplayBrandDto> CreateAsync(CreateBrandDto model)
        {
            var created = await CreateAsync(new Brand
            {
                Name = model.Name,
                ManufacturerId = model.ManufacturerId,
            });

            return await GetDisplayModelAsync(created.Id);
        }

        public async Task<Brand> CreateFromObjectAsync(object value)
        {
            if (value is Brand brand) return await CreateAsync(brand);

            if (value is CreateBrandDto createDto)
            {
                return await CreateAsync(new Brand
                {
                    Name = createDto.Name,
                    ManufacturerId = createDto.ManufacturerId,
                });
            }

            throw new NotImplementedException("Could not create entity because the model is not expected.");
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _brandDbSet.AnyAsync(brand => brand.Name == name);
        }

        public async Task<IEnumerable<IndexRowBrandDto>> GetAllAsync()
        {
            return await _brandDbSet
                .Select(brand => new IndexRowBrandDto
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    ManufacturerName = brand.Manufacturer.Name,
                })
                .OrderBy(brand => brand.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetBrandNamesOfManufacturerAsync(int manufacturerId)
        {
            return await _brandDbSet
                .Where(brand => brand.ManufacturerId == manufacturerId)
                .Select(brand => brand.Name)
                .ToListAsync();
        }

        public async Task<DisplayBrandDto> GetDisplayModelAsync(int id)
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

        public async Task<EditBrandDto> GetEditModelAsync(int id)
        {
            return await _brandDbSet
                .Where(brand => brand.Id == id)
                .Select(brand => new EditBrandDto
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    ManufacturerId = brand.ManufacturerId,
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

        public async Task<DisplayBrandDto> Update(EditBrandDto model)
        {
            var updated = Update(new Brand
            {
                Id = model.Id,
                Name = model.Name,
                ManufacturerId = model.ManufacturerId,
            });

            return await GetDisplayModelAsync(updated.Id);
        }

        public Brand UpdateFromObject(object value)
        {
            if (value is Brand brand) return Update(brand);

            if (value is EditBrandDto editDto)
            {
                return Update(new Brand
                {
                    Id = editDto.Id,
                    Name = editDto.Name,
                    ManufacturerId = editDto.ManufacturerId,
                });
            }

            throw new NotImplementedException("Could not update entity because the model is not expected.");
        }
    }
}
