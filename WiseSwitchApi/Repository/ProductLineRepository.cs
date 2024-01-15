using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WiseSwitchApi.Data;
using WiseSwitchApi.Dtos.ProductLine;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Repository
{
    public class ProductLineRepository : GenericRepository<ProductLine>, IProductLineRepository
    {
        private readonly DbSet<ProductLine> _productLineDbSet;

        public ProductLineRepository(DataContext dataContext) : base(dataContext)
        {
            _productLineDbSet = dataContext.ProductLines;
        }


        public async Task<ProductLine> CreateFromObjectAsync(object value)
        {
            if (value is ProductLine productLine) return await CreateAsync(productLine);

            if (value is CreateProductLineDto createDto)
            {
                return await CreateAsync(new ProductLine
                {
                    Name = createDto.Name,
                    BrandId = createDto.BrandId,
                });
            }

            throw new NotImplementedException();
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _productLineDbSet.AnyAsync(productLine => productLine.Name == name);
        }

        public async Task<IEnumerable<IndexRowProductLineDto>> GetAllAsync()
        {
            return await _productLineDbSet
                .Select(productLine => new IndexRowProductLineDto
                {
                    Id = productLine.Id,
                    Name = productLine.Name,
                    BrandName = productLine.Brand.Name,
                })
                .OrderBy(productLine => productLine.Name)
                .ToListAsync();
        }

        public async Task<int> GetBrandIdAsync(int id)
        {
            return await _productLineDbSet
                .Where(productLine => productLine.Id == id)
                .Select(productLine => productLine.BrandId)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetComboProductLinesOfBrandAsync(int productLineId)
        {
            return await _productLineDbSet
                .Where(productLine => productLine.BrandId == productLineId)
                .Select(productLine => new SelectListItem
                {
                    Text = productLine.Name,
                    Value = productLine.Id.ToString()
                })
                .ToListAsync();
        }

        public async Task<DisplayProductLineDto> GetDisplayModelAsync(int id)
        {
            return await _productLineDbSet
                .Where(productLine => productLine.Id == id)
                .Select(productLine => new DisplayProductLineDto
                {
                    Id = productLine.Id,
                    Name = productLine.Name,
                    BrandName = productLine.Brand.Name,
                    ProductSeriesNames = productLine.ProductSeries.Select(productSeries => productSeries.Name),
                })
                .SingleOrDefaultAsync();
        }

        public async Task<EditProductLineDto> GetEditModelAsync(int id)
        {
            return await _productLineDbSet
                .Where(productLine => productLine.Id == id)
                .Select(productLine => new EditProductLineDto
                {
                    Id = productLine.Id,
                    Name = productLine.Name,
                    BrandId = productLine.BrandId,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<int> GetIdFromNameAsync(string name)
        {
            return await _productLineDbSet
                .Where(productLine => productLine.Name == name)
                .Select(productLine => productLine.Id)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<string>> GetProductLinesNamesOfBrandAsync(int productLineId)
        {
            return await _productLineDbSet
                .Where(productLine => productLine.BrandId == productLineId)
                .Select(productLine => productLine.Name)
                .ToListAsync();
        }

        public ProductLine UpdateFromObject(object value)
        {
            if (value is ProductLine productLine) return Update(productLine);

            if (value is EditProductLineDto editDto)
            {
                return Update(new ProductLine
                {
                    Id = editDto.Id,
                    Name = editDto.Name,
                    BrandId = editDto.BrandId,
                });
            }

            throw new NotImplementedException();
        }
    }
}
