using WiseSwitchApi.Data;
using WiseSwitchApi.Dtos;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Helpers
{
    public class DataService
    {
        private readonly IDataUnit _dataUnit;

        public DataService(IDataUnit dataUnit)
        {
            _dataUnit = dataUnit;
        }


        // Get data.
        public async Task<object> GetDataAsync(string dataOperation, object value)
        {
            return dataOperation switch
            {
                // Brand.
                DataOperations.GetAllBrandsOrderByName => await _dataUnit.Brands.GetAllAsync(),
                DataOperations.GetAllBrandsCombo => await _dataUnit.Brands.GetComboAsync(),
                DataOperations.GetBrandDisplay => await _dataUnit.Brands.GetDisplayModelAsync((int)value),
                DataOperations.GetBrandEditModel => await _dataUnit.Brands.GetEditModelAsync((int)value),
                DataOperations.GetBrandExists => await _dataUnit.Brands.ExistsAsync((int)value),
                DataOperations.GetBrandModel => await _dataUnit.Brands.GetAsNoTrackingAsync((int)value),
                // Firmware Version.
                DataOperations.GetAllFirmwareVersionsOrderByVersion => await _dataUnit.FirmwareVersions.GetAllOrderByVersionAsync(),
                DataOperations.GetAllFirmwareVersionsCombo => await _dataUnit.FirmwareVersions.GetComboFirmwareVersionsAsync(),
                DataOperations.GetFirmwareVersionDisplay => await _dataUnit.FirmwareVersions.GetDisplayModelAsync((int)value),
                DataOperations.GetFirmwareVersionEditModel => await _dataUnit.FirmwareVersions.GetEditModelAsync((int)value),
                DataOperations.GetFirmwareVersionExists => await _dataUnit.FirmwareVersions.ExistsAsync((int)value),
                DataOperations.GetFirmwareVersionModel => await _dataUnit.FirmwareVersions.GetAsNoTrackingByIdAsync((int)value),
                // Manufacturer.
                DataOperations.GetAllManufacturersOrderByName => await _dataUnit.Manufacturers.GetAllOrderByNameAsync(),
                DataOperations.GetAllManufacturersCombo => await _dataUnit.Manufacturers.GetComboManufacturersAsync(),
                DataOperations.GetManufacturerDisplay => await _dataUnit.Manufacturers.GetDisplayDtoAsync((int)value),
                DataOperations.GetManufacturerEditModel => await _dataUnit.Manufacturers.GetEditDtoAsync((int)value),
                DataOperations.GetManufacturerExists => await _dataUnit.Manufacturers.ExistsAsync((int)value),
                DataOperations.GetManufacturerModel => await _dataUnit.Manufacturers.GetAsNoTrackingByIdAsync((int)value),
                // Product Line.
                DataOperations.GetAllProductLinesOrderByName => await _dataUnit.ProductLines.GetAllOrderByNameAsync(),
                DataOperations.GetBrandIdOfProductLine => await _dataUnit.ProductLines.GetBrandIdAsync((int)value),
                DataOperations.GetAllProductLinesCombo => await _dataUnit.ProductLines.GetComboProductLinesAsync(),
                DataOperations.GetComboProductLinesOfBrand => await _dataUnit.ProductLines.GetComboProductLinesOfBrandAsync((int)value),
                DataOperations.GetProductLineDisplay => await _dataUnit.ProductLines.GetDisplayDtoAsync((int)value),
                DataOperations.GetProductLineEditModel => await _dataUnit.ProductLines.GetEditDtoAsync((int)value),
                DataOperations.GetProductLineExists => await _dataUnit.ProductLines.ExistsAsync((int)value),
                DataOperations.GetProductLineModel => await _dataUnit.ProductLines.GetAsNoTrackingByIdAsync((int)value),
                // Product Series.
                DataOperations.GetAllProductSeriesOrderByName => await _dataUnit.ProductSeries.GetAllOrderByNameAsync(),
                DataOperations.GetAllProductSeriesCombo => await _dataUnit.ProductSeries.GetComboProductSeriesAsync(),
                DataOperations.GetComboProductSeriesOfProductLine => await _dataUnit.ProductSeries.GetComboProductSeriesOfProductLineAsync((int)value),
                DataOperations.GetDependencyChainIdsOfProductSeries => await _dataUnit.ProductSeries.GetDependencyChainIdsAsync((int)value),
                DataOperations.GetProductSeriesDisplay => await _dataUnit.ProductSeries.GetDisplayDtoAsync((int)value),
                DataOperations.GetProductSeriesEditModel => await _dataUnit.ProductSeries.GetEditDtoAsync((int)value),
                DataOperations.GetProductSeriesExists => await _dataUnit.ProductSeries.ExistsAsync((int)value),
                DataOperations.GetProductSeriesModel => await _dataUnit.ProductSeries.GetAsNoTrackingByIdAsync((int)value),
                // Switch Model.
                DataOperations.GetAllSwitchModelsOrderByModelName => await _dataUnit.SwitchModels.GetAllOrderByModelNameAsync(),
                DataOperations.GetAllSwitchModelsCombo => await _dataUnit.SwitchModels.GetComboSwitchModelsAsync(),
                DataOperations.GetSwitchModelDisplay => await _dataUnit.SwitchModels.GetDisplayDtoAsync((int)value),
                DataOperations.GetSwitchModelEditModel => await _dataUnit.SwitchModels.GetEditDtoAsync((int)value),
                DataOperations.GetSwitchModelExists => await _dataUnit.SwitchModels.ExistsAsync((int)value),
                DataOperations.GetSwitchModel => await _dataUnit.SwitchModels.GetAsNoTrackingByIdAsync((int)value),

                _ => throw new InvalidOperationException(dataOperation),
            };
        }


        // Post data.
        public async Task<IEntity> PostDataAsync(string dataOperation, ICreateModel value)
        {
            IEntity posted = dataOperation switch
            {
                DataOperations.CreateBrand => await _dataUnit.Brands.CreateFromObjectAsync(value),
                DataOperations.CreateFirmwareVersion => await _dataUnit.FirmwareVersions.CreateFromObjectAsync(value),
                DataOperations.CreateManufacturer => await _dataUnit.Manufacturers.CreateFromObjectAsync(value),
                DataOperations.CreateProductLine => await _dataUnit.ProductLines.CreateFromObjectAsync(value),
                DataOperations.CreateProductSeries => await _dataUnit.ProductSeries.CreateFromObjectAsync(value),
                DataOperations.CreateSwitchModel => await _dataUnit.SwitchModels.CreateFromObjectAsync(value),

                _ => throw new InvalidOperationException(dataOperation)
            };

            // Save changes.
            try { await _dataUnit.SaveChangesAsync(); }
            catch { throw; }

            return posted;
        }


        // Put data.
        public async Task<IEntity> PutDataAsync(string dataOperation, IEditModel value)
        {
            IEntity putted = dataOperation switch
            {
                DataOperations.UpdateBrand => _dataUnit.Brands.UpdateFromObject(value),
                DataOperations.UpdateFirmwareVersion => _dataUnit.FirmwareVersions.UpdateFromObject(value),
                DataOperations.UpdateManufacturer => _dataUnit.Manufacturers.UpdateFromObject(value),
                DataOperations.UpdateProductLine => _dataUnit.ProductLines.UpdateFromObject(value),
                DataOperations.UpdateProductSeries => _dataUnit.ProductSeries.UpdateFromObject(value),
                DataOperations.UpdateSwitchModel => _dataUnit.SwitchModels.UpdateFromObject(value),

                _ => throw new InvalidOperationException(dataOperation)
            };

            // Save changes.
            try { await _dataUnit.SaveChangesAsync(); }
            catch { throw; }

            return putted;
        }


        // Delete data.
        public async Task<IEntity> DeleteDataAsync(string dataOperation, object value)
        {
            IEntity deleted = dataOperation switch
            {
                DataOperations.DeleteBrand => await _dataUnit.Brands.DeleteAsync((int)value),
                DataOperations.DeleteFirmwareVersion => await _dataUnit.FirmwareVersions.DeleteAsync((int)value),
                DataOperations.DeleteManufacturer => await _dataUnit.Manufacturers.DeleteAsync((int)value),
                DataOperations.DeleteProductLine => await _dataUnit.ProductLines.DeleteAsync((int)value),
                DataOperations.DeleteProductSeries => await _dataUnit.ProductSeries.DeleteAsync((int)value),
                DataOperations.DeleteSwitchModel => await _dataUnit.SwitchModels.DeleteAsync((int)value),

                _ => throw new InvalidOperationException(dataOperation)
            };

            // Save changes.
            try { await _dataUnit.SaveChangesAsync(); }
            catch { throw; }

            return deleted;
        }
    }
}
