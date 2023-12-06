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
            switch (dataOperation)
            {
                // FirmwareVersion.
                case DataOperations.GetAllFirmwareVersionsOrderByVersion: return await _dataUnit.FirmwareVersions.GetAllOrderByVersionAsync();
                case DataOperations.GetComboFirmwareVersions: return await _dataUnit.FirmwareVersions.GetComboFirmwareVersionsAsync();
                case DataOperations.GetDisplayFirmwareVersion: return await _dataUnit.FirmwareVersions.GetDisplayDtoAsync((int)value);
                case DataOperations.GetExistsFirmwareVersion: return await _dataUnit.FirmwareVersions.ExistsAsync((int)value);
                case DataOperations.GetModelFirmwareVersion: return await _dataUnit.FirmwareVersions.GetAsNoTrackingByIdAsync((int)value);
                // Manufacturer.
                case DataOperations.GetAllManufacturersOrderByName: return await _dataUnit.Manufacturers.GetAllOrderByName();
                case DataOperations.GetComboManufacturers: return await _dataUnit.Manufacturers.GetComboManufacturersAsync();
                case DataOperations.GetDisplayManufacturer: return await _dataUnit.Manufacturers.GetDisplayDtoAsync((int)value);
                case DataOperations.GetExistsManufacturer: return await _dataUnit.Manufacturers.ExistsAsync((int)value);
                case DataOperations.GetModelManufacturer: return await _dataUnit.Manufacturers.GetAsNoTrackingByIdAsync((int)value);
                // Product Lines.
                case DataOperations.GetAllProductLinesOrderByName: return await _dataUnit.ProductLines.GetAllOrderByName();
                case DataOperations.GetComboProductLines: return await _dataUnit.ProductLines.GetComboProductLinesAsync();
                case DataOperations.GetDisplayProductLine: return await _dataUnit.ProductLines.GetDisplayDtoAsync((int)value);
                case DataOperations.GetExistsProductLine: return await _dataUnit.ProductLines.ExistsAsync((int)value);
                case DataOperations.GetModelProductLine: return await _dataUnit.ProductLines.GetAsNoTrackingByIdAsync((int)value);
                // Product Series.
                case DataOperations.GetAllProductSeriesOrderByName: return await _dataUnit.ProductSeries.GetAllOrderByName();
                case DataOperations.GetComboProductSeries: return await _dataUnit.ProductSeries.GetComboProductSeriesAsync();
                case DataOperations.GetDisplayProductSeries: return await _dataUnit.ProductSeries.GetDisplayDtoAsync((int)value);
                case DataOperations.GetExistsProductSeries: return await _dataUnit.ProductSeries.ExistsAsync((int)value);
                case DataOperations.GetModelProductSeries: return await _dataUnit.ProductSeries.GetAsNoTrackingByIdAsync((int)value);
                // Switch Model.
                case DataOperations.GetAllSwitchModelsOrderByName: return await _dataUnit.SwitchModels.GetAllOrderByModelNameAsync();
                case DataOperations.GetComboSwitchModels: return await _dataUnit.SwitchModels.GetComboSwitchModelsAsync();
                case DataOperations.GetDisplaySwitchModel: return await _dataUnit.SwitchModels.GetDisplayDtoAsync((int)value);
                case DataOperations.GetExistsSwitchModel: return await _dataUnit.SwitchModels.ExistsAsync((int)value);

                default: throw new InvalidOperationException(dataOperation);
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
