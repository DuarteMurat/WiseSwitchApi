using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WiseSwitchApi.Data;
using WiseSwitchApi.Dtos;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Repository
{
    public class ProductSeriesRepository : IProductSeriesRepository
    {
        private readonly DbSet<ProductSeries> _productSeriesDbSet;

        public ProductSeriesRepository(DataContext context)
        {
            _productSeriesDbSet = context.ProductSeries;
        }


        public async Task<ProductSeries> CreateAsync(ProductSeries productSeries)
        {
            return (await _productSeriesDbSet.AddAsync(productSeries)).Entity;
        }

        public async Task<ProductSeries> DeleteAsync(int id)
        {
            return _productSeriesDbSet.Remove(
                await _productSeriesDbSet
                    .SingleAsync(productSeries => productSeries.Id == id)).Entity;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _productSeriesDbSet.AnyAsync(productSeries => productSeries.Id == id);
        }

        public async Task<bool> ExistsAsync(string productSeriesName)
        {
            return await _productSeriesDbSet.AnyAsync(productSeries => productSeries.Name == productSeriesName);
        }

        public IQueryable<ProductSeries> GetAllAsNoTracking()
        {
            return _productSeriesDbSet.AsNoTracking();
        }

        public async Task<IEnumerable<IndexRowProductSeriesDto>> GetAllOrderByName()
        {
            return await _productSeriesDbSet
                .AsNoTracking()
                .OrderBy(productSeries => productSeries.Name)
                .Select(productSeries => new IndexRowProductSeriesDto
                {
                    Id = productSeries.Id,
                    Name = productSeries.Name,
                    ProductLineName = productSeries.ProductLine.Name,
                    BrandName = productSeries.ProductLine.Brand.Name,
                })
                .ToListAsync();
        }

        public async Task<ProductSeries> GetAsNoTrackingByIdAsync(int id)
        {
            return await _productSeriesDbSet
                .AsNoTracking()
                .SingleOrDefaultAsync(productSeries => productSeries.Id == id);
        }

        public async Task<IEnumerable<SelectListItem>> GetComboProductSeriesAsync()
        {
            return await _productSeriesDbSet
                .Select(productSeries => new SelectListItem
                {
                    Text = productSeries.Name,
                    Value = productSeries.Id.ToString()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetComboProductSeriesOfProductLineAsync(int productSeriesId)
        {
            return await _productSeriesDbSet
                .Where(productSeries => productSeries.ProductLineId == productSeriesId)
                .Select(productSeries => new SelectListItem
                {
                    Text = productSeries.Name,
                    Value = productSeries.Id.ToString()
                })
                .ToListAsync();
        }

        public async Task<ProductSeries> GetForUpdateAsync(int id)
        {
            return await _productSeriesDbSet.FindAsync(id);
        }

        public async Task<int> GetIdFromNameAsync(string name)
        {
            return await _productSeriesDbSet
                .Where(productSeries => productSeries.Name == name)
                .Select(productSeries => productSeries.Id)
                .SingleOrDefaultAsync();
        }

        public async Task<InputProductSeriesDto> GetInputViewModelAsync(int id)
        {
            return await _productSeriesDbSet
                .Where(productSeries => productSeries.Id == id)
                .Select(productSeries => new InputProductSeriesDto
                {
                    Id = productSeries.Id,
                    Name = productSeries.Name,
                    ProductLineId = productSeries.ProductLineId,
                    BrandId = productSeries.ProductLine.BrandId,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<DisplayProductSeriesDto> GetDisplayDtoAsync(int id)
        {
            return await _productSeriesDbSet
                .Where(productSeries => productSeries.Id == id)
                .Select(productSeries => new DisplayProductSeriesDto
                {
                    Id = productSeries.Id,
                    Name = productSeries.Name,
                    ProductLineName = productSeries.ProductLine.Name,
                    SwitchModelsNames = productSeries.SwitchModel.Select(productSeries => productSeries.ModelName),
                })
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<string>> GetProductSeriesNamesOfProductLineAsync(int productSeriesId)
        {
            return await _productSeriesDbSet
                .Where(productSeries => productSeries.ProductLineId == productSeriesId)
                .Select(productSeries => productSeries.Name)
                .ToListAsync();
        }

        public ProductSeries Update(ProductSeries productSeries)
        {
            return _productSeriesDbSet.Update(productSeries).Entity;
        }
    }
}
