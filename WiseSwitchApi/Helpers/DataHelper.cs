﻿using WiseSwitchApi.Data;
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
                // Brand.
                DataOperations.GetAllBrandsOrderByName => await _dataUnit.Brands.GetAllOrderByNameAsync(),
                DataOperations.GetComboBrands => await _dataUnit.Brands.GetComboBrandsAsync(),
                DataOperations.GetDisplayBrand => await _dataUnit.Brands.GetDisplayDtoAsync((int)value),
                DataOperations.GetEditModelBrand => await _dataUnit.Brands.GetEditDtoAsync((int)value),
                DataOperations.GetExistsBrand => await _dataUnit.Brands.ExistsAsync((int)value),
                DataOperations.GetModelBrand => await _dataUnit.Brands.GetAsNoTrackingByIdAsync((int)value),
                // Firmware Version.
                DataOperations.GetAllFirmwareVersionsOrderByVersion => await _dataUnit.FirmwareVersions.GetAllOrderByVersionAsync(),
                DataOperations.GetComboFirmwareVersions => await _dataUnit.FirmwareVersions.GetComboFirmwareVersionsAsync(),
                DataOperations.GetDisplayFirmwareVersion => await _dataUnit.FirmwareVersions.GetDisplayDtoAsync((int)value),
                DataOperations.GetEditModelFirmwareVersion => await _dataUnit.FirmwareVersions.GetEditDtoAsync((int)value),
                DataOperations.GetExistsFirmwareVersion => await _dataUnit.FirmwareVersions.ExistsAsync((int)value),
                DataOperations.GetModelFirmwareVersion => await _dataUnit.FirmwareVersions.GetAsNoTrackingByIdAsync((int)value),
                // Manufacturer.
                DataOperations.GetAllManufacturersOrderByName => await _dataUnit.Manufacturers.GetAllOrderByNameAsync(),
                DataOperations.GetComboManufacturers => await _dataUnit.Manufacturers.GetComboManufacturersAsync(),
                DataOperations.GetDisplayManufacturer => await _dataUnit.Manufacturers.GetDisplayDtoAsync((int)value),
                DataOperations.GetEditModelManufacturer => await _dataUnit.Manufacturers.GetEditDtoAsync((int)value),
                DataOperations.GetExistsManufacturer => await _dataUnit.Manufacturers.ExistsAsync((int)value),
                DataOperations.GetModelManufacturer => await _dataUnit.Manufacturers.GetAsNoTrackingByIdAsync((int)value),
                // Product Line.
                DataOperations.GetAllProductLinesOrderByName => await _dataUnit.ProductLines.GetAllOrderByNameAsync(),
                DataOperations.GetBrandIdOfProductLine => await _dataUnit.ProductLines.GetBrandIdAsync((int)value),
                DataOperations.GetComboProductLines => await _dataUnit.ProductLines.GetComboProductLinesAsync(),
                DataOperations.GetDisplayProductLine => await _dataUnit.ProductLines.GetDisplayDtoAsync((int)value),
                DataOperations.GetEditModelProductLine => await _dataUnit.ProductLines.GetEditDtoAsync((int)value),
                DataOperations.GetExistsProductLine => await _dataUnit.ProductLines.ExistsAsync((int)value),
                DataOperations.GetModelProductLine => await _dataUnit.ProductLines.GetAsNoTrackingByIdAsync((int)value),
                DataOperations.GetComboProductLinesOfBrand => await _dataUnit.ProductLines.GetComboProductLinesOfBrandAsync((int)value),
                // Product Series.
                DataOperations.GetAllProductSeriesOrderByName => await _dataUnit.ProductSeries.GetAllOrderByNameAsync(),
                DataOperations.GetComboProductSeries => await _dataUnit.ProductSeries.GetComboProductSeriesAsync(),
                DataOperations.GetDependencyChainIdsOfProductSeries => await _dataUnit.ProductSeries.GetDependencyChainIdsAsync((int)value),
                DataOperations.GetDisplayProductSeries => await _dataUnit.ProductSeries.GetDisplayDtoAsync((int)value),
                DataOperations.GetEditModelProductSeries => await _dataUnit.ProductSeries.GetEditDtoAsync((int)value),
                DataOperations.GetExistsProductSeries => await _dataUnit.ProductSeries.ExistsAsync((int)value),
                DataOperations.GetModelProductSeries => await _dataUnit.ProductSeries.GetAsNoTrackingByIdAsync((int)value),
                DataOperations.GetComboProductSeriesOfProductLine => await _dataUnit.ProductSeries.GetComboProductSeriesOfProductLineAsync((int)value),
                // Switch Model.
                DataOperations.GetAllSwitchModelsOrderByModelName => await _dataUnit.SwitchModels.GetAllOrderByModelNameAsync(),
                DataOperations.GetComboSwitchModels => await _dataUnit.SwitchModels.GetComboSwitchModelsAsync(),
                DataOperations.GetDisplaySwitchModel => await _dataUnit.SwitchModels.GetDisplayDtoAsync((int)value),
                DataOperations.GetEditModelSwitchModel => await _dataUnit.SwitchModels.GetEditDtoAsync((int)value),
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
