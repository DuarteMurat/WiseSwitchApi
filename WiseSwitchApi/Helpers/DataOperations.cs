﻿namespace WiseSwitchApi.Helpers
{
    public static class DataOperations
    {
        // -- Create --
        public const string CreateBrand = "CreateBrand";
        public const string CreateFirmwareVersion = "CreateFirmwareVersion";
        public const string CreateManufacturer = "CreateManufacturer";
        public const string CreateProductLine = "CreateProductLine";
        public const string CreateProductSeries = "CreateProductSeries";
        public const string CreateSwitchModel = "CreateSwitchModel";

        // -- Delete --
        public const string DeleteBrand = "DeleteBrand";
        public const string DeleteFirmwareVersion = "DeleteFirmwareVersion";
        public const string DeleteManufacturer = "DeleteManufacturer";
        public const string DeleteProductLine = "DeleteProductLine";
        public const string DeleteProductSeries = "DeleteProductSeries";
        public const string DeleteSwitchModel = "DeleteSwitchModel";

        // -- Get --

        // Brand.
        public const string GetAllBrandsCombo = "GetAllBrandsCombo";
        public const string GetAllBrandsOrderByName = "GetAllBrandsOrderByName";
        public const string GetBrand = "GetBrandModel";
        public const string GetBrandDisplay = "GetBrandDisplay";
        public const string GetBrandEditModel = "GetBrandEditModel";
        public const string GetBrandExists = "GetBrandExists";
        // Firmware Version.
        public const string GetAllFirmwareVersionsCombo = "GetAllFirmwareVersionsCombo";
        public const string GetAllFirmwareVersionsOrderByVersion = "GetAllFirmwareVersionsOrderByVersion";
        public const string GetFirmwareVersion = "GetFirmwareVersionModel";
        public const string GetFirmwareVersionDisplay = "GetFirmwareVersionDisplay";
        public const string GetFirmwareVersionEditModel = "GetFirmwareVersionEditModel";
        public const string GetFirmwareVersionExists = "GetFirmwareVersionExists";
        // Manufacturer.
        public const string GetAllManufacturersCombo = "GetAllManufacturersCombo";
        public const string GetAllManufacturersOrderByName = "GetAllManufacturersOrderByName";
        public const string GetManufacturer = "GetManufacturerModel";
        public const string GetManufacturerDisplay = "GetManufacturerDisplay";
        public const string GetManufacturerEditModel = "GetManufacturerEditModel";
        public const string GetManufacturerExists = "GetManufacturerExists";
        // Product Line.
        public const string GetAllProductLinesCombo = "GetAllProductLinesCombo";
        public const string GetAllProductLinesOrderByName = "GetAllProductLinesOrderByName";
        public const string GetBrandIdOfProductLine = "GetBrandIdOfProductLine";
        public const string GetComboProductLinesOfBrand = "GetComboProductLinesOfBrand";
        public const string GetProductLine = "GetProductLineModel";
        public const string GetProductLineDisplay = "GetProductLineDisplay";
        public const string GetProductLineEditModel = "GetProductLineEditModel";
        public const string GetProductLineExists = "GetProductLineExists";
        // Product Series.
        public const string GetAllProductSeriesCombo = "GetAllProductSeriesCombo";
        public const string GetAllProductSeriesOrderByName = "GetAllProductSeriesOrderByName";
        public const string GetComboProductSeriesOfProductLine = "GetComboProductSeriesOfProductLine";
        public const string GetDependencyChainIdsOfProductSeries = "GetDependencyChainIdsOfProductSeries";
        public const string GetProductSeries = "GetProductSeriesModel";
        public const string GetProductSeriesDisplay = "GetProductSeriesDisplay";
        public const string GetProductSeriesEditModel = "GetProductSeriesEditModel";
        public const string GetProductSeriesExists = "GetProductSeriesExists";
        // Switch Model.
        public const string GetAllSwitchModelsCombo = "GetAllSwitchModelsCombo";
        public const string GetAllSwitchModelsOrderByModelName = "GetAllSwitchModelOrderByName";
        public const string GetSwitchModel = "GetSwitchModelModel";
        public const string GetSwitchModelCreateModel = "GetSwitchModelCreateModel";
        public const string GetSwitchModelDisplay = "GetSwitchModelDisplay";
        public const string GetSwitchModelEditModel = "GetSwitchModelEditModel";
        public const string GetSwitchModelExists = "GetSwitchModelExists";


        // -- Update --
        public const string UpdateBrand = "UpdateBrand";
        public const string UpdateFirmwareVersion = "UpdateFirmwareVersion";
        public const string UpdateManufacturer = "UpdateManufacturer";
        public const string UpdateProductLine = "UpdateProductLine";
        public const string UpdateProductSeries = "UpdateProductSeries";
        public const string UpdateSwitchModel = "UpdateSwitchModel";
    }
}
