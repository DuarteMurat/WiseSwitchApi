using WiseSwitchApi.Data;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Helpers
{
    public class DataHelper
    {
        private readonly IDataUnit _dataUnit;

        public DataHelper(IDataUnit dataUnit)
        {
            _dataUnit = dataUnit;
        }


        // Get data.
        public async Task<object> GetDataAsync(string dataOperation, object value)
        {
            return dataOperation switch
            {
                // Firmware Version.
                DataOperations.GetAllFirmwareVersionsOrderByVersion => await _dataUnit.FirmwareVersions.GetAllOrderByVersionAsync(),
                DataOperations.GetComboFirmwareVersions => await _dataUnit.FirmwareVersions.GetComboFirmwareVersionsAsync(),
                DataOperations.GetDisplayFirmwareVersion => await _dataUnit.FirmwareVersions.GetDisplayDtoAsync((int)value),
                DataOperations.GetExistsFirmwareVersion => await _dataUnit.FirmwareVersions.ExistsAsync((int)value),
                DataOperations.GetModelFirmwareVersion => await _dataUnit.FirmwareVersions.GetAsNoTrackingByIdAsync((int)value),
                // Manufacturer.
                DataOperations.GetAllManufacturersOrderByName => await _dataUnit.Manufacturers.GetAllOrderByName(),
                DataOperations.GetComboManufacturers => await _dataUnit.Manufacturers.GetComboManufacturersAsync(),
                DataOperations.GetDisplayManufacturer => await _dataUnit.Manufacturers.GetDisplayDtoAsync((int)value),
                DataOperations.GetExistsManufacturer => await _dataUnit.Manufacturers.ExistsAsync((int)value),
                DataOperations.GetModelManufacturer => await _dataUnit.Manufacturers.GetAsNoTrackingByIdAsync((int)value),
                // Product Line.
                DataOperations.GetAllProductLinesOrderByName => await _dataUnit.ProductLines.GetAllOrderByName(),
                DataOperations.GetComboProductLines => await _dataUnit.ProductLines.GetComboProductLinesAsync(),
                DataOperations.GetDisplayProductLine => await _dataUnit.ProductLines.GetDisplayDtoAsync((int)value),
                DataOperations.GetExistsProductLine => await _dataUnit.ProductLines.ExistsAsync((int)value),
                DataOperations.GetModelProductLine => await _dataUnit.ProductLines.GetAsNoTrackingByIdAsync((int)value),
                // Product Series.
                DataOperations.GetAllProductSeriesOrderByName => await _dataUnit.ProductSeries.GetAllOrderByName(),
                DataOperations.GetComboProductSeries => await _dataUnit.ProductSeries.GetComboProductSeriesAsync(),
                DataOperations.GetDisplayProductSeries => await _dataUnit.ProductSeries.GetDisplayDtoAsync((int)value),
                DataOperations.GetExistsProductSeries => await _dataUnit.ProductSeries.ExistsAsync((int)value),
                DataOperations.GetModelProductSeries => await _dataUnit.ProductSeries.GetAsNoTrackingByIdAsync((int)value),
                // Switch Model.
                DataOperations.GetAllSwitchModelsOrderByModelName => await _dataUnit.SwitchModels.GetAllOrderByModelNameAsync(),
                DataOperations.GetComboSwitchModels => await _dataUnit.SwitchModels.GetComboSwitchModelsAsync(),
                DataOperations.GetDisplaySwitchModel => await _dataUnit.SwitchModels.GetDisplayDtoAsync((int)value),
                DataOperations.GetExistsSwitchModel => await _dataUnit.SwitchModels.ExistsAsync((int)value),
                DataOperations.GetModelSwitchModel => await _dataUnit.SwitchModels.GetAsNoTrackingByIdAsync((int)value),

                _ => throw new InvalidOperationException(dataOperation),
            };
        }


        // Post data.
        public async Task<IEntity> PostDataAsync(string dataOperation, object value)
        {
            IEntity posted = dataOperation switch
            {
                DataOperations.CreateFirmwareVersion => await _dataUnit.FirmwareVersions.CreateAsync(value as FirmwareVersion),
                DataOperations.CreateManufacturer => await _dataUnit.Manufacturers.CreateAsync(value as Manufacturer),
                DataOperations.CreateProductLine => await _dataUnit.ProductLines.CreateAsync(value as ProductLine),
                DataOperations.CreateProductSeries => await _dataUnit.ProductSeries.CreateAsync(value as ProductSeries),
                DataOperations.CreateSwitchModel => await _dataUnit.SwitchModels.CreateAsync(value as SwitchModel),

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
                DataOperations.UpdateFirmwareVersion => _dataUnit.FirmwareVersions.Update(value as FirmwareVersion),
                DataOperations.UpdateManufacturer => _dataUnit.Manufacturers.Update(value as Manufacturer),
                DataOperations.UpdateProductLine => _dataUnit.ProductLines.Update(value as ProductLine),
                DataOperations.UpdateProductSeries => _dataUnit.ProductSeries.Update(value as ProductSeries),
                DataOperations.UpdateSwitchModel => _dataUnit.SwitchModels.Update(value as SwitchModel),

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
