using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WiseSwitchApi.Data;
using WiseSwitchApi.Dtos.ProductSeries;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Repository
{
    public class ProductSeriesRepository : GenericRepository<ProductSeries>, IProductSeriesRepository
    {
        private readonly DbSet<ProductSeries> _productSeriesDbSet;

        public ProductSeriesRepository(DataContext dataContext) : base(dataContext)
        {
            _productSeriesDbSet = dataContext.ProductSeries;
        }


        public async Task<ProductSeries> CreateFromObjectAsync(object value)
        {
            if (value is ProductSeries productSeries) return await CreateAsync(productSeries);

            if (value is CreateProductSeriesDto createDto)
            {
                return await CreateAsync(new ProductSeries
                {
                    Name = createDto.Name,
                    ProductLineId = createDto.ProductLineId,
                });
            }

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IndexRowProductSeriesDto>> GetAllAsync()
        {
            return await _productSeriesDbSet
                .Select(productSeries => new IndexRowProductSeriesDto
                {
                    Id = productSeries.Id,
                    Name = productSeries.Name,
                    ProductLineName = productSeries.ProductLine.Name,
                    BrandName = productSeries.ProductLine.Brand.Name,
                })
                .OrderBy(productSeries => productSeries.Name)
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

        public async Task<ProductSeriesDependencyChainIds> GetDependencyChainIdsAsync(int id)
        {
            return await _productSeriesDbSet
                .Where(productSeries => productSeries.Id == id)
                .Select(productSeries => new ProductSeriesDependencyChainIds
                {
                    ProductLineId = productSeries.ProductLineId,
                    BrandId = productSeries.ProductLine.BrandId,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<DisplayProductSeriesDto> GetDisplayModelAsync(int id)
        {
            return await _productSeriesDbSet
                .Where(productSeries => productSeries.Id == id)
                .Select(productSeries => new DisplayProductSeriesDto
                {
                    Id = productSeries.Id,
                    Name = productSeries.Name,
                    ProductLineName = productSeries.ProductLine.Name,
                    BrandName = productSeries.ProductLine.Brand.Name,
                    SwitchModelsNames = productSeries.SwitchModel.Select(productSeries => productSeries.ModelName),
                })
                .SingleOrDefaultAsync();
        }

        public async Task<EditProductSeriesDto> GetEditModelAsync(int id)
        {
            return await _productSeriesDbSet
                .Where(productSeries => productSeries.Id == id)
                .Select(productSeries => new EditProductSeriesDto
                {
                    Id = productSeries.Id,
                    Name = productSeries.Name,
                    ProductLineId = productSeries.ProductLineId,
                    BrandId = productSeries.ProductLine.BrandId,
                })
                .SingleOrDefaultAsync();
        }

        public async Task<int> GetIdFromNameAsync(string name)
        {
            return await _productSeriesDbSet
                .Where(productSeries => productSeries.Name == name)
                .Select(productSeries => productSeries.Id)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<string>> GetProductSeriesNamesOfProductLineAsync(int productSeriesId)
        {
            return await _productSeriesDbSet
                .Where(productSeries => productSeries.ProductLineId == productSeriesId)
                .Select(productSeries => productSeries.Name)
                .ToListAsync();
        }

        public ProductSeries UpdateFromObject(object value)
        {
            if (value is ProductSeries productSeries) return Update(productSeries);

            if (value is EditProductSeriesDto editDto)
            {
                return Update(new ProductSeries
                {
                    Id = editDto.Id,
                    Name = editDto.Name,
                    ProductLineId = editDto.ProductLineId,
                });
            }

            throw new NotImplementedException();
        }
    }
}
