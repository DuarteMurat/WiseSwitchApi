using WiseSwitchApi.Data;
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
                DataOperations.GetAllBrandsCombo => await _dataUnit.Brands.GetComboAsync(),
                DataOperations.GetAllBrandsOrderByName => await _dataUnit.Brands.GetAllAsync(),
                DataOperations.GetBrand => await _dataUnit.Brands.GetAsNoTrackingAsync((int)value),
                DataOperations.GetBrandDisplay => await _dataUnit.Brands.GetDisplayModelAsync((int)value),
                DataOperations.GetBrandEditModel => await _dataUnit.Brands.GetEditModelAsync((int)value),
                DataOperations.GetBrandExists => await _dataUnit.Brands.ExistsAsync((int)value),
                // Firmware Version.
                DataOperations.GetAllFirmwareVersionsCombo => await _dataUnit.FirmwareVersions.GetComboAsync(),
                DataOperations.GetAllFirmwareVersionsOrderByVersion => await _dataUnit.FirmwareVersions.GetAllAsync(),
                DataOperations.GetFirmwareVersion => await _dataUnit.FirmwareVersions.GetAsNoTrackingAsync((int)value),
                DataOperations.GetFirmwareVersionDisplay => await _dataUnit.FirmwareVersions.GetDisplayModelAsync((int)value),
                DataOperations.GetFirmwareVersionEditModel => await _dataUnit.FirmwareVersions.GetEditModelAsync((int)value),
                DataOperations.GetFirmwareVersionExists => await _dataUnit.FirmwareVersions.ExistsAsync((int)value),
                // Manufacturer.
                DataOperations.GetAllManufacturersCombo => await _dataUnit.Manufacturers.GetComboAsync(),
                DataOperations.GetAllManufacturersOrderByName => await _dataUnit.Manufacturers.GetAllAsync(),
                DataOperations.GetManufacturer => await _dataUnit.Manufacturers.GetAsNoTrackingAsync((int)value),
                DataOperations.GetManufacturerDisplay => await _dataUnit.Manufacturers.GetDisplayModelAsync((int)value),
                DataOperations.GetManufacturerEditModel => await _dataUnit.Manufacturers.GetEditModelAsync((int)value),
                DataOperations.GetManufacturerExists => await _dataUnit.Manufacturers.ExistsAsync((int)value),
                // Product Line.
                DataOperations.GetAllProductLinesCombo => await _dataUnit.ProductLines.GetComboAsync(),
                DataOperations.GetAllProductLinesOrderByName => await _dataUnit.ProductLines.GetAllAsync(),
                DataOperations.GetBrandIdOfProductLine => await _dataUnit.ProductLines.GetBrandIdAsync((int)value),
                DataOperations.GetComboProductLinesOfBrand => await _dataUnit.ProductLines.GetComboProductLinesOfBrandAsync((int)value),
                DataOperations.GetProductLine => await _dataUnit.ProductLines.GetAsNoTrackingAsync((int)value),
                DataOperations.GetProductLineDisplay => await _dataUnit.ProductLines.GetDisplayModelAsync((int)value),
                DataOperations.GetProductLineEditModel => await _dataUnit.ProductLines.GetEditModelAsync((int)value),
                DataOperations.GetProductLineExists => await _dataUnit.ProductLines.ExistsAsync((int)value),
                // Product Series.
                DataOperations.GetAllProductSeriesCombo => await _dataUnit.ProductSeries.GetComboAsync(),
                DataOperations.GetAllProductSeriesOrderByName => await _dataUnit.ProductSeries.GetAllAsync(),
                DataOperations.GetComboProductSeriesOfProductLine => await _dataUnit.ProductSeries.GetComboProductSeriesOfProductLineAsync((int)value),
                DataOperations.GetDependencyChainIdsOfProductSeries => await _dataUnit.ProductSeries.GetDependencyChainIdsAsync((int)value),
                DataOperations.GetProductSeries => await _dataUnit.ProductSeries.GetAsNoTrackingAsync((int)value),
                DataOperations.GetProductSeriesDisplay => await _dataUnit.ProductSeries.GetDisplayModelAsync((int)value),
                DataOperations.GetProductSeriesEditModel => await _dataUnit.ProductSeries.GetEditModelAsync((int)value),
                DataOperations.GetProductSeriesExists => await _dataUnit.ProductSeries.ExistsAsync((int)value),
                // Switch Model.
                DataOperations.GetAllSwitchModelsCombo => await _dataUnit.SwitchModels.GetComboAsync(),
                DataOperations.GetAllSwitchModelsOrderByModelName => await _dataUnit.SwitchModels.GetAllAsync(),
                DataOperations.GetSwitchModel => await _dataUnit.SwitchModels.GetAsNoTrackingAsync((int)value),
                DataOperations.GetSwitchModelDisplay => await _dataUnit.SwitchModels.GetDisplayModelAsync((int)value),
                DataOperations.GetSwitchModelEditModel => await _dataUnit.SwitchModels.GetEditModelAsync((int)value),
                DataOperations.GetSwitchModelExists => await _dataUnit.SwitchModels.ExistsAsync((int)value),

                _ => throw new InvalidOperationException(dataOperation),
            };
        }


        // Post data.
        public async Task<IEntity> PostDataAsync(string dataOperation, object value)
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
        public async Task<IEntity> PutDataAsync(string dataOperation, object value)
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
