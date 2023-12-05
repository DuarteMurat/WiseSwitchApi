using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WiseSwitchApi.Data;
using WiseSwitchApi.Dtos;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Repository
{
    public class ProductLineRepository : IProductLineRepository
    {
        private readonly DbSet<ProductLine> _productLineDbSet;

        public ProductLineRepository(DataContext context)
        {
            _productLineDbSet = context.ProductLines;
        }


        public async Task CreateAsync(ProductLine productLine)
        {
            await _productLineDbSet.AddAsync(productLine);
        }

        public async Task DeleteAsync(int id)
        {
            _productLineDbSet.Remove(
                await _productLineDbSet
                    .SingleAsync(productLine => productLine.Id == id));
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _productLineDbSet.AnyAsync(productLine => productLine.Id == id);
        }

        public async Task<bool> ExistsAsync(string productLineName)
        {
            return await _productLineDbSet.AnyAsync(productLine => productLine.Name == productLineName);
        }

        public IQueryable<ProductLine> GetAllAsNoTracking()
        {
            return _productLineDbSet.AsNoTracking();
        }

        public async Task<IEnumerable<IndexRowProductLineDto>> GetAllOrderByName()
        {
            return await _productLineDbSet
                .AsNoTracking()
                .OrderBy(productLine => productLine.Name)
                .Select(productLine => new IndexRowProductLineDto
                {
                    Id = productLine.Id,
                    Name = productLine.Name,
                    BrandName = productLine.Brand.Name,
                })
                .ToListAsync();
        }

        public async Task<ProductLine> GetAsNoTrackingByIdAsync(int id)
        {
            return await _productLineDbSet
                .AsNoTracking()
                .SingleOrDefaultAsync(productLine => productLine.Id == id);
        }

        public async Task<IEnumerable<SelectListItem>> GetComboProductLinesAsync()
        {
            return await _productLineDbSet
                .Select(productLine => new SelectListItem
                {
                    Text = productLine.Name,
                    Value = productLine.Id.ToString()
                })
                .ToListAsync();
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

        public async Task<DisplayProductLineDto> GetDisplayDtoAsync(int id)
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

        public void Update(ProductLine productLine)
        {
            _productLineDbSet.Update(productLine);
        }
    }
}
